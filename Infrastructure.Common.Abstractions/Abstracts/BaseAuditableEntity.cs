using System;

namespace Infrastructure.Common.Abstractions.Abstracts
{

    public abstract class BaseAuditableEntity<TKey> : BaseEntity<TKey>, IBaseAuditableEntity
    {
        public DateTimeOffset Created { get; init; } = DateTime.UtcNow;
        public DateTimeOffset? LastModified { get; set; }
        public void Update()
        {
            LastModified = DateTimeOffset.UtcNow;
        }
    }
}
