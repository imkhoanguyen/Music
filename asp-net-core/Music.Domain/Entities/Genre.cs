using Music.Domain.Entities.Abstractions;

namespace Music.Domain.Entities
{
    public class Genre : BaseEntityAuditSoftDelete<int, string>
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
