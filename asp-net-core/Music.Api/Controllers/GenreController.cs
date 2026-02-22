using Microsoft.AspNetCore.Mvc;
using Music.Application.Dtos;
using Music.Application.Dtos.Genres;
using Music.Application.Services.Abstractions;
using Music.Domain.Entities;

namespace Music.Api.Controllers
{
    [Route("api/genre")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpPost("add")]
        public TData<Genre> Create(CreateGenreRequest request)
        {
            var result = _genreService.Create(request);
            return result;
        }

        [HttpPost("update")]
        public TData<Genre> Update(UpdateGenreRequest request)
        {
            var result = _genreService.Update(request);
            return result;
        }

        [HttpGet("detail")]
        public TData<Genre> GetById(int id)
        {
            var result = _genreService.GetById(id);
            return result;
        }

        [HttpGet]
        public TData<IEnumerable<Genre>> GetAll()
        {
            var result = _genreService.GetAll();
            return result;
        }

        [HttpDelete("delete")]
        public TData Delete(int id)
        {
            var result = _genreService.Delete(id);
            return result;
        }
    }
}
