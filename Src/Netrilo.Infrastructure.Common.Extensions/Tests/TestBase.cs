using Infrastructure.Common.Extensions.Tools;
using Xunit.Abstractions;

namespace Infrastructure.Common.Extensions.Tests
{
    public abstract class TestBase(ITestOutputHelper outputHelper)
    {
        protected static string EnvPath => ".env";
        protected ITestOutputHelper Output { get; } = outputHelper;

        protected void LoadEnv()
        {
            DotEnv.Load(EnvPath);
        }
    }
}
