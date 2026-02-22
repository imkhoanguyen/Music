using Music.Application.Dtos;
using Music.Application.Dtos.Genres;
using Music.Application.Mappers;
using Music.Application.Services.Abstractions;
using Music.Domain.Entities;
using Music.Domain.Repositories;

namespace Music.Application.Services.Implementations
{
    public class GenreService : IGenreService
    {
        private readonly IUnitOfWork _unit;

        public GenreService(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public TData<Genre> Create(CreateGenreRequest request)
        {
            var obj = new TData<Genre>();

            var genre = GenreMapper.MapToGenre(request);

            genre.SetCreated("admin"); // TODO: Get the user from the context

            _unit.GetRepository<Genre>().Add(genre);

            if (_unit.SaveChanges())
            {
                obj.SetSuccess(genre);
                return obj;
            }

            obj.SetError();
            return obj;
        }

        public TData<Genre> Update(UpdateGenreRequest request)
        {
            var obj = new TData<Genre>();
            var genre = _unit.GetRepository<Genre>().Query().FirstOrDefault(x => x.Id == request.Id);
            if (genre == null)
            {
                obj.SetNotFound();
                return obj;
            }
            genre.Name = request.Name;
            genre.Description = request.Description;
            genre.SetModified("admin"); // TODO: Get the user from the context
            if (_unit.SaveChanges())
            {
                obj.SetSuccess(genre);
                return obj;
            }
            obj.SetError();
            return obj;
        }

        public TData<Genre> GetById(int id)
        {
            var obj = new TData<Genre>();
            var genre = _unit.GetRepository<Genre>().Query().FirstOrDefault(x => x.Id == id && !x.IsDeleted);
            if (genre == null)
            {
                obj.SetNotFound();
                return obj;
            }
            obj.SetSuccess(genre);
            return obj;
        }

        public TData<IEnumerable<Genre>> GetAll()
        {
            var obj = new TData<IEnumerable<Genre>>();
            var genres = _unit.GetRepository<Genre>().Query().Where(x => !x.IsDeleted).ToList();
            obj.SetSuccess(genres);
            return obj;
        }

        public TData Delete(int id)
        {
            var obj = new TData();
            var genre = _unit.GetRepository<Genre>().Query().FirstOrDefault(x => x.Id == id);
            if (genre == null)
            {
                obj.SetNotFound();
                return obj;
            }
            _unit.GetRepository<Genre>().Remove(genre);
            if (_unit.SaveChanges())
            {
                obj.SetSuccess();
                return obj;
            }
            obj.SetError();
            return obj;
        }
    }
}
