namespace Music.Domain.Entities.Abstractions
{
    public abstract class BaseEntityAuditSoftDelete<TId, TUserId> : BaseEntityAudit<TId, TUserId>, ISoftDelete<TUserId>
    {
        public bool IsDeleted { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
        public TUserId? DeletedBy { get; set; }
    }
}
