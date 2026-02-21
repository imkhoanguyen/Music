namespace Music.Domain.Entities.Abstractions
{
    public abstract class BaseEntityAuditSoftDelete<T> : BaseEntityAudit<T>, ISoftDelete<T>
    {
        public bool IsDeleted { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
        public T? DeletedBy { get; set; }
    }
}
