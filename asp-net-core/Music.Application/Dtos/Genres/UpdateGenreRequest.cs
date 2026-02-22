namespace Music.Application.Dtos.Genres
{
    public class UpdateGenreRequest
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
