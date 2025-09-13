using Netrilo.Infrastructure.Common.Extensions.Settings;
using Netrilo.Infrastructure.Common.Extensions.Settings.Interfaces;

namespace Netrilo.Infrastructure.Common.Extensions.UnitTests.Settings
{
    public class AppSettings(IGlobalSettings global, IWorkerSettings worker) : AppSettingsBase(global, worker)
    {
    }
}
