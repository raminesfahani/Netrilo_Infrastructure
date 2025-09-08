using System;

namespace Infrastructure.Common.Abstractions.Abstracts
{

    public abstract class BaseAuditableEntity<TKey> : BaseEntity<TKey>, IBaseAuditableEntity
    {
        public DateTimeOffset Created { get; set; } = DateTime.UtcNow;

        public int? CreatedBy { get; set; }

        public DateTimeOffset LastModified { get; set; }

        public int? LastModifiedBy { get; set; }
    }
}
