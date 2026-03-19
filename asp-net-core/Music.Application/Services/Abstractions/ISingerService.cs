using Music.Application.Dtos;
using Music.Application.Dtos.Singers;
using Music.Domain.Entities;

namespace Music.Application.Services.Abstractions
{
    public interface ISingerService
    {
        TData<SingerDto> Create(CreateSingerRequest request);
        TData<SingerDto> Update(UpdateSingerRequest request);
        TData<SingerDto> GetById(int id);
        TData<IEnumerable<SingerDto>> GetAll();
        TData Delete(int id);
    }
}
