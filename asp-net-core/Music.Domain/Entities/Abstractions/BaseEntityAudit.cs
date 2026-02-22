namespace Music.Domain.Entities.Abstractions
{
    public abstract class BaseEntityAudit<TId, TUserId> : BaseEntity<TId>, IDateTracking<TUserId>
    {
        public DateTimeOffset? CreatedAt { get ; private set; }
        public TUserId? CreatedBy { get; private set; }
        public DateTimeOffset? ModifiedAt { get; private set; }
        public TUserId? ModifiedBy { get; set; }

        public void SetCreated(TUserId createdBy)
        {
            CreatedAt = DateTimeOffset.UtcNow;
            CreatedBy = createdBy;
        }

        public void SetModified(TUserId modifiedBy)
        {
            ModifiedAt = DateTimeOffset.UtcNow;
            ModifiedBy = modifiedBy;
        }
    }
}
