namespace Infrastructure.Common.Extensions.Settings.Interfaces
{
    interface IAppSettings
    {
        IGlobalSettings Global { get; set; }
        IWorkerSettings Worker { get; set; }
    }
}
