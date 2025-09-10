using Xunit.Abstractions;
using Newtonsoft.Json;
using Infrastructure.Common.Extensions.Tests;

namespace Infrastructure.Common.Extensions.UnitTests.JsonConverters
{
    public class JsonConverterTests(ITestOutputHelper outputHelper) : TestBase(outputHelper)
    {
        private static char Ds => Path.DirectorySeparatorChar;

        [Fact]
        public void ParseMailAddressTest()
        {
            string jsonFile = File.ReadAllText($"JsonConverters{Ds}JsonConverterSample.json");
            JsonConverterSample sample = JsonConvert.DeserializeObject<JsonConverterSample>(jsonFile);

            Output.WriteLine($"Sample json file was parsed to email: " + sample.Email);
            Assert.NotNull(sample.Email);
            Assert.True(sample.Email.ToString().Length > 0);
        }
    }
}
