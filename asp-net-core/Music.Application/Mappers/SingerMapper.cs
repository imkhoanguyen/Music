using Music.Application.Dtos.Genres;
using Music.Application.Dtos.Singers;
using Music.Domain.Entities;
using Music.Application.Helpers;

namespace Music.Application.Mappers
{
    public class SingerMapper
    {
        public static Singer MapToEntity(CreateSingerRequest request)
        {
            return new Singer
            {
                Name = request.Name,
                Gender = request.Gender,
                Introduction = request.Introduction,
                Location = request.Location,
            };
        }

        public static SingerDto MapToDto(Singer entity)
        {
            return new SingerDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Gender = entity.Gender.GetDescription(),
                Introduction = entity.Introduction,
                Location = entity.Location,
                ImagePath = entity.ImagePath
            };
        }
    }
}
