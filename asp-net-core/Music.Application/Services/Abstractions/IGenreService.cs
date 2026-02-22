using Music.Application.Dtos;
using Music.Application.Dtos.Genres;
using Music.Domain.Entities;

namespace Music.Application.Services.Abstractions
{
    public interface IGenreService
    {
        TData<Genre> Create(CreateGenreRequest request);
        TData<Genre> Update(UpdateGenreRequest request);
        TData<Genre> GetById(int id);
        TData<IEnumerable<Genre>> GetAll();
        TData Delete(int id);
    }
}