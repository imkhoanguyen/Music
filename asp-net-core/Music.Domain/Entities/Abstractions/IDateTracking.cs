namespace Music.Domain.Entities.Abstractions
{
    public interface IDateTracking<TUserId>
    {
        public DateTimeOffset? CreatedAt { get; set; }
        public TUserId? CreatedBy { get; set; }
        public DateTimeOffset? ModifiedAt { get; set; }
        public TUserId? ModifiedBy { get; set; }
    }
}
