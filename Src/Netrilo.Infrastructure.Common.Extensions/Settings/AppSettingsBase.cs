using Infrastructure.Common.Extensions.Settings.Interfaces;

namespace Infrastructure.Common.Extensions.Settings
{
    public abstract class AppSettingsBase(IGlobalSettings global, IWorkerSettings worker) : IAppSettings
    {
        public IGlobalSettings Global { get; set; } = global;
        public IWorkerSettings Worker { get; set; } = worker;
    }
}
