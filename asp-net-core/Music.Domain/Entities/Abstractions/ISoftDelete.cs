namespace Music.Domain.Entities.Abstractions
{
    public interface ISoftDelete<TUserId>
    {
        public bool IsDeleted { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
        public TUserId? DeletedBy { get; set; }
    }
}
