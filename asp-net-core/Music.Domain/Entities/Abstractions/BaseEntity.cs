namespace Music.Domain.Entities.Abstractions
{
    public abstract class BaseEntity<TId> : IBaseEntity<TId>
    {
        public required TId Id { get ; set; }
    }
}
