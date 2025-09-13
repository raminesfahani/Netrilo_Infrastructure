using System;

namespace Netrilo.Infrastructure.Common.Persistence.NoSql.MongoDB.Abstractions
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class BsonCollectionAttribute(string collectionName) : Attribute
    {
        public string CollectionName { get; } = collectionName;
    }
}
