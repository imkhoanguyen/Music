using Microsoft.AspNetCore.Mvc;
using Music.Application.Dtos;
using Music.Application.Dtos.Singers;
using Music.Application.Services.Abstractions;
using Music.Domain.Entities;

namespace Music.Api.Controllers
{
    [Route("api/singer")]
    [ApiController]
    public class SingerController : ControllerBase
    {
        private readonly ISingerService _singerService;

        public SingerController(ISingerService singerService)
        {
            _singerService = singerService;
        }

        [HttpPost("add")]
        public TData<SingerDto> Create([FromForm] CreateSingerRequest request)
        {
            var result = _singerService.Create(request);
            return result;
        }

        [HttpPost("update")]
        public TData<SingerDto> Update([FromForm] UpdateSingerRequest request)
        {
            var result = _singerService.Update(request);
            return result;
        }

        [HttpGet("detail")]
        public TData<SingerDto> GetById(int id)
        {
            var result = _singerService.GetById(id);
            return result;
        }

        [HttpGet]
        public TData<IEnumerable<SingerDto>> GetAll()
        {
            var result = _singerService.GetAll();
            return result;
        }

        [HttpDelete("delete")]
        public TData Delete(int id)
        {
            var result = _singerService.Delete(id);
            return result;
        }
    }
}
