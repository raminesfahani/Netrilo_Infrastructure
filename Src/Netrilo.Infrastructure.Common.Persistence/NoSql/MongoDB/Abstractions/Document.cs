using MongoDB.Bson;

namespace Infrastructure.Common.Persistence.NoSql.MongoDB.Abstractions
{
    public abstract class Document : IDocument
    {
        public ObjectId Id { get; set; }

        public DateTime CreatedAt => Id.CreationTime;
    }
}
