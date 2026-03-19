using Music.Domain.Enum;

namespace Music.Application.Dtos.Singers
{
    public class SingerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string? Introduction { get; set; }
        public string? Location { get; set; }
        public string? ImagePath { get; set; }
    }
}
