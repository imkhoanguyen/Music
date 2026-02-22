namespace Music.Domain.Entities.Abstractions
{
    public interface ISoftDelete<TUserId>
    {
        public bool IsDeleted { get; }
        public DateTimeOffset? DeletedAt { get; }
        public TUserId? DeletedBy { get; }
    }
}
