namespace Infrastructure.Common.Bus.EventStores.Stores.MongoDb
{
    public class MongoDbEventStoreOptions
    {
        public string CollectionName { get; set; } = "Events";
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; } = "EventStore";
    }
}
