namespace Music.Domain.Entities.Abstractions
{
    public interface IBaseEntity<T>
    {
        public T Id { get; set; }
    }
}
