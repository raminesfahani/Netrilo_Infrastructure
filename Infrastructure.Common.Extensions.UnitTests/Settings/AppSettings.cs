using Infrastructure.Common.Extensions.Settings;
using Infrastructure.Common.Extensions.Settings.Interfaces;

namespace Infrastructure.Common.Extensions.UnitTests.Settings
{
    public class AppSettings(IGlobalSettings global, IWorkerSettings worker) : AppSettingsBase(global, worker)
    {
    }
}
