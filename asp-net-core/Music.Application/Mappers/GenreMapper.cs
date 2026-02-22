using Music.Application.Dtos.Genres;
using Music.Domain.Entities;

namespace Music.Application.Mappers
{
    public class GenreMapper
    {
        public static Genre MapToGenre(CreateGenreRequest request)
        {
            return new Genre
            {
                Name = request.Name,
                Description = request.Description
            };
        }
    }
}
