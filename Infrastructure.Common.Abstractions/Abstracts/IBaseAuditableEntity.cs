namespace Infrastructure.Common.Abstractions.Abstracts
{
    public interface IBaseAuditableEntity
    {
        public DateTimeOffset Created { get; init; }
        public DateTimeOffset? LastModified { get; set; }
    }
}
