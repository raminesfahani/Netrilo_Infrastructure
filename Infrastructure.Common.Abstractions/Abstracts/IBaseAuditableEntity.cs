namespace Infrastructure.Common.Abstractions.Abstracts
{
    public interface IBaseAuditableEntity
    {
        public DateTimeOffset Created { get; set; }

        public int? CreatedBy { get; set; }

        public DateTimeOffset LastModified { get; set; }

        public int? LastModifiedBy { get; set; }
    }
}
