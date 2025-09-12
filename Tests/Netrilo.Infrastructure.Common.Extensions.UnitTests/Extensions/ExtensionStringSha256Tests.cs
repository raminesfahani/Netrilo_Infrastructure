using Infrastructure.Common.Extensions.Extensions.String;
using Xunit.Abstractions;

namespace Infrastructure.Common.Extensions.UnitTests.Extensions
{
    public class ExtensionStringSha256Tests
    {
        private ITestOutputHelper OutputHelper { get; }

        public ExtensionStringSha256Tests(ITestOutputHelper outputHelper)
        {
            OutputHelper = outputHelper;
        }

        [Theory]
        [InlineData("test", "9f86d081884c7d659a2feaa0c55ad015a3bf4f1b2b0b822cd15d6c15b0f00a08")]
        [InlineData("ComplexTestString!@#$5^7891234", "bfccc4e552d7641c39978cbad557f5035973082116a015b130181185f32d96ee")]
        public void TestStringToSha256(string text, string expectedHash)
        {
            string sha256 = text.GetSha256();
            OutputHelper.WriteLine($"Input: {text} hash rate is {sha256}");
            Assert.Equal(expectedHash, sha256);
        }

    }
}
