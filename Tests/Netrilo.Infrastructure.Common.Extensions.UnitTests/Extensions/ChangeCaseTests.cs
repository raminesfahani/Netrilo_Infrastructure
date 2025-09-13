using Netrilo.Infrastructure.Common.Extensions.Extensions.String;
using Netrilo.Infrastructure.Common.Extensions.Tests;
using Xunit.Abstractions;

namespace Netrilo.Infrastructure.Common.Extensions.UnitTests.Extensions
{
    public class StringUtilityTests(ITestOutputHelper output) : TestBase(output)
    {
        [Theory]
        [InlineData("ToSnakeCaseBest", "to_snake_case_best")]
        [InlineData("secondSnakeCaseTry.", "second_snake_case_try")]
        public void PascalToSnakeCase(string original, string expected)
        {
            string calculated = original.PascalToSnakeCase();
            Output.WriteLine($"Original: {original}, calculated: {calculated} | expected: {expected}");
            Assert.Equal(expected, calculated);
        }

        [Theory]
        [InlineData("To Snake Case Best", "to_snake_case_best")]
        [InlineData("second Snake Case Try.", "second_snake_case_try")]
        public void StringToSnakeCase(string original, string expected)
        {
            string calculated = original.StringToSnakeCase();
            Output.WriteLine($"Original: {original}, calculated: {calculated} | expected: {expected}");
            Assert.Equal(expected, calculated);
        }

        [Theory]
        [InlineData("BITCOIN_ETHEREUM_COINS", "Bitcoin Ethereum Coins")]
        [InlineData("_1BITCOIN_ETHEREUM_COINS", "1Bitcoin Ethereum Coins")]
        public void ToConstantCase(string expected, string original)
        {
            string calculated = original.ToConstantCase(true);
            Output.WriteLine($"Original: {original}, calculated: {calculated} | expected: {expected}");
            Assert.Equal(expected, calculated);
        }
    }
}
