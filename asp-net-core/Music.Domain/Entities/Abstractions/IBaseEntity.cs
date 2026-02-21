namespace Music.Domain.Entities.Abstractions
{
    public interface IBaseEntity<TId>
    {
        public TId Id { get; set; }
    }
}
