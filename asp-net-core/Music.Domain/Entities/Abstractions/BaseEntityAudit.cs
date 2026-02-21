namespace Music.Domain.Entities.Abstractions
{
    public abstract class BaseEntityAudit<T> : BaseEntity<T>, IDateTracking<T>
    {
        public DateTimeOffset? CreatedAt { get ; set; }
        public T? CreatedBy { get; set; }
        public DateTimeOffset? ModifiedAt { get; set; }
        public T? ModifiedBy { get; set; }
    }
}
