namespace Music.Application.Dtos.Genres
{
    public class CreateGenreRequest
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
