namespace Music.Domain.Entities.Abstractions
{
    public abstract class BaseEntityAuditSoftDelete<TId, TUserId> : BaseEntityAudit<TId, TUserId>, ISoftDelete<TUserId>
    {
        public bool IsDeleted { get; private set; }
        public DateTimeOffset? DeletedAt { get; private set; }
        public TUserId? DeletedBy { get; private set; }

        public void SoftDelete(TUserId deletedBy)
        {
            if (IsDeleted)
                return;

            IsDeleted = true;
            DeletedAt = DateTimeOffset.UtcNow;
            DeletedBy = deletedBy;
        }

        public void Restore()
        {
            IsDeleted = false;
            DeletedAt = null;
            DeletedBy = default;
        }
    }
}
