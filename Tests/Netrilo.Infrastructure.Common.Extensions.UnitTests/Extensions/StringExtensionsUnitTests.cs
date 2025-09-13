using Infrastructure.Extensions.String;

namespace Netrilo.Infrastructure.Common.Extensions.UnitTests.Extensions
{
    public class StringExtensionsUnitTests
    {
        /// <summary>
        /// Checking the validation of generic type and date created by BaseEntity class
        /// </summary>
        [Fact]
        public void Check_Dto_Instance_Is_Valid()
        {
            // Arrange
            string testCase = "hello world";

            // Act
            var camelCase = testCase.ToCamelCase();
            var kebabCase = testCase.ToKebabCase();
            var pascalCase = testCase.ToPascalCase();
            var snakeCase = testCase.ToSnakeCase();
            var trainCase = testCase.ToTrainCase();

            // Assert
            Assert.Equal("helloWorld", camelCase);
            Assert.Equal("hello-world", kebabCase);
            Assert.Equal("HelloWorld", pascalCase);
            Assert.Equal("hello_world", snakeCase);
            Assert.Equal("Hello-World", trainCase);
        }
    }
}