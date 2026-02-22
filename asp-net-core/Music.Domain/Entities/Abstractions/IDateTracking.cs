namespace Music.Domain.Entities.Abstractions
{
    public interface IDateTracking<TUserId>
    {
        public DateTimeOffset? CreatedAt { get; }
        public TUserId? CreatedBy { get; }
        public DateTimeOffset? ModifiedAt { get; }
        public TUserId? ModifiedBy { get; }
    }
}
