namespace Music.Domain.Entities.Abstractions
{
    public abstract class BaseEntity<T> : IBaseEntity<T>
    {
        public required T Id { get ; set; }
    }
}
