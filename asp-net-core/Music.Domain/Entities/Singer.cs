using Music.Domain.Entities.Abstractions;
using Music.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Music.Domain.Entities
{
    public class Singer : BaseEntityAuditSoftDelete<int, string>
    {
        [Required]
        public string Name { get; set; }
        public Gender Gender { get; set; }
        [Required]
        public string? Introduction { get; set; }
        [Required]
        public string? Location { get; set; }
        public string? ImagePath { get; set; }
    }
}
