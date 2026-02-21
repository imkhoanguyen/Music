namespace Music.Domain.Entities.Abstractions
{
    public interface IDateTracking<T>
    {
        public DateTimeOffset? CreatedAt { get; set; }
        public T? CreatedBy { get; set; }
        public DateTimeOffset? ModifiedAt { get; set; }
        public T? ModifiedBy { get; set; }
    }
}
