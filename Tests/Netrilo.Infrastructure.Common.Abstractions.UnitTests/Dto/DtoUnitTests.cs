using Netrilo.Infrastructure.Common.Abstractions.Abstracts;
using Netrilo.Infrastructure.Common.Abstractions.Commands;
using Moq;
using Netrilo.Infrastructure.Common.Abstractions.Dto;

namespace Netrilo.Infrastructure.Common.Abstractions.UnitTests.Dto
{
    public class DtoUnitTests
    {
        private class TestDtoClass<T> : BaseDto<T>
        {
            public TestDtoClass(T id)
            {
                Id = id;
            }
        }

        /// <summary>
        /// Checking the validation of generic type and date created by BaseEntity class
        /// </summary>
        [Fact]
        public void Check_Dto_Instance_Is_Valid()
        {
            // Arrange
            TestDtoClass<Guid> entity = new(Guid.NewGuid());

            // Assert
            Assert.True(entity.Id.GetType() == typeof(Guid));
        }
    }
}