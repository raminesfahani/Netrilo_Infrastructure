using Xunit.Abstractions;
using Infrastructure.Common.Extensions.Tests;
using Infrastructure.Common.Extensions.Tools;
using Infrastructure.Common.Extensions.Extensions.String;
using Infrastructure.Common.Extensions.Tools.Annotations;
using Infrastructure.Common.Extensions.UnitTests.DotEnvTests.Samples;

namespace Infrastructure.Common.Extensions.UnitTests.DotEnvTests
{
    public class DotEnvTests(ITestOutputHelper outputHelper, TempEnvFileFixcture tempEnvFileFixcture) : TestBase(outputHelper), IClassFixture<TempEnvFileFixcture>
    {
        public TempEnvFileFixcture TempEnvFileFixcture = tempEnvFileFixcture;
        //public TestEnvSettings TestEnvSettings;

        [Fact]
        public void LoadDotEnvTest()
        {
            DotEnv.Load(TempEnvFileFixcture.EnvFilePath);
        }

        [Fact]
        public void TestLoadDotEndTests()
        {
            // Act
            DotEnv.Load(TempEnvFileFixcture.EnvFilePath);
            string testVar1 = Environment.GetEnvironmentVariable(nameof(TestEnvSettings.TestVar1).PascalToSnakeCase());
            string testVar2 = Environment.GetEnvironmentVariable(typeof(TestEnvSettings).GetEnvName(nameof(TestEnvSettings.Var2)));

            // Assert
            Assert.Equal(TempEnvFileFixcture.VarValue1, testVar1);
            Assert.Equal(TempEnvFileFixcture.VarValue2, testVar2);
        }

        #region Test Env Vars
        private const string STRING_VALUE = "TEST";
        private const int INT_VALUE = -2147483648;
        private const uint U_INT_VALUE = 4294967295;
        private const long LONG_VALUE = 9223372036854775807;
        private const ulong U_LONG_VALUE = 18446744073709551615;

        #endregion
        [Fact]
        public void GetEnvModelType()
        {
            Environment.SetEnvironmentVariable(nameof(STRING_VALUE), STRING_VALUE);
            Environment.SetEnvironmentVariable(nameof(INT_VALUE), INT_VALUE.ToString());
            Environment.SetEnvironmentVariable(nameof(U_INT_VALUE), U_INT_VALUE.ToString());
            Environment.SetEnvironmentVariable(nameof(LONG_VALUE), LONG_VALUE.ToString());
            Environment.SetEnvironmentVariable(nameof(U_LONG_VALUE), U_LONG_VALUE.ToString());

            WorkerSettings workerSettings = DotEnv.Load<WorkerSettings>();

            Assert.Equal(STRING_VALUE, workerSettings.StringValue);
            Assert.Equal(INT_VALUE, workerSettings.IntValue);
            Assert.Equal(U_INT_VALUE, workerSettings.UIntValue);
            Assert.Equal(LONG_VALUE, workerSettings.LongValue);
            Assert.Equal(U_LONG_VALUE, workerSettings.ULongValue);
        }
    }

    public class TempEnvFileFixcture : IDisposable
    {
        public string EnvFilePath { get; set; }
        public string VarName1 = "TEST_VAR1";
        public string VarValue1 = "TEST_VALUE1";
        public string VarName2 = "TEST_VAR2";
        public string VarValue2 = "TEST_VALUE2";
        public TempEnvFileFixcture()
        {
            string testEnvs = "# COMMENT TEST\n" +
                            $"{VarName1}={VarValue1}\n" +
                            $"{VarName2}={VarValue2}\n";

            EnvFilePath = Path.GetTempPath() + ".env";
            File.WriteAllText(EnvFilePath, testEnvs);
        }
        public void Dispose()
        {
            File.Delete(EnvFilePath);
        }
    }

    public class TestEnvSettings
    {
        public string TestVar1 { get; }

        [EnvName("TEST_VAR2")]
        public string Var2 { get; }
    }
}
