using Microsoft.AspNetCore.Http;
using Music.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Music.Application.Dtos.Singers
{
    public class CreateSingerRequest
    {
        [Required]
        public string Name { get; set; }
        public Gender Gender { get; set; }
        [Required]
        public string? Introduction { get; set; }
        [Required]
        public string? Location { get; set; }
        public IFormFile? Image { get; set; }
    }
}
