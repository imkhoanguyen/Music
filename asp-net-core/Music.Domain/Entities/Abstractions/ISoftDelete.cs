namespace Music.Domain.Entities.Abstractions
{
    public interface ISoftDelete<T>
    {
        public bool IsDeleted { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
        public T? DeletedBy { get; set; }
    }
}
