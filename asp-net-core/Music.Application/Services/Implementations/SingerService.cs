using Microsoft.AspNetCore.Hosting;
using Music.Application.Dtos;
using Music.Application.Dtos.Singers;
using Music.Application.Helpers;
using Music.Application.Mappers;
using Music.Application.Services.Abstractions;
using Music.Domain.Entities;
using Music.Domain.Enum;
using Music.Domain.Repositories;
using System.IO;

namespace Music.Application.Services.Implementations
{
    public class SingerService : ISingerService
    {
        private readonly IUnitOfWork _unit;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SingerService(IUnitOfWork unit, IWebHostEnvironment webHostEnvironment)
        {
            _unit = unit;
            _webHostEnvironment = webHostEnvironment;
        }

        public TData<SingerDto> Create(CreateSingerRequest request)
        {
            var obj = new TData<SingerDto>();

            var singer = SingerMapper.MapToEntity(request);

            if (request.Image != null)
            {
                string webRootPath = _webHostEnvironment.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                var saveResult = FileHelper.SaveImageAsync(request.Image, webRootPath, "singers").GetAwaiter().GetResult();
                
                if (saveResult.Status != ResultStatus.Success)
                {
                    var errorObj = new TData<SingerDto>();
                    errorObj.SetError(saveResult.Message);
                    return errorObj;
                }

                singer.ImagePath = saveResult.Data;
            }

            singer.SetCreated("admin"); // TODO: Get the user from the context

            _unit.GetRepository<Singer>().Add(singer);

            if (_unit.SaveChanges())
            {
                obj.SetSuccess(SingerMapper.MapToDto(singer));
                return obj;
            }

            obj.SetError();
            return obj;
        }

        public TData<SingerDto> Update(UpdateSingerRequest request)
        {
            var obj = new TData<SingerDto>();
            var singer = _unit.GetRepository<Singer>().Query().FirstOrDefault(x => x.Id == request.Id);
            if (singer == null)
            {
                obj.SetNotFound();
                return obj;
            }
            
            singer.Name = request.Name;
            singer.Gender = request.Gender;
            singer.Introduction = request.Introduction;
            singer.Location = request.Location;
            
            if (request.Image != null)
            {
                string webRootPath = _webHostEnvironment.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                var saveResult = FileHelper.SaveImageAsync(request.Image, webRootPath, "singers").GetAwaiter().GetResult();
                
                if (saveResult.Status != ResultStatus.Success)
                {
                    obj.SetError(saveResult.Message);
                    return obj;
                }

                singer.ImagePath = saveResult.Data;
            }
            
            singer.SetModified("admin"); // TODO: Get the user from the context
            if (_unit.SaveChanges())
            {
                obj.SetSuccess(SingerMapper.MapToDto(singer));
                return obj;
            }
            obj.SetError();
            return obj;
        }

        public TData<SingerDto> GetById(int id)
        {
            var obj = new TData<SingerDto>();
            var singer = _unit.GetRepository<Singer>().Query().FirstOrDefault(x => x.Id == id && !x.IsDeleted);
            if (singer == null)
            {
                obj.SetNotFound();
                return obj;
            }
            obj.SetSuccess(SingerMapper.MapToDto(singer));
            return obj;
        }

        public TData<IEnumerable<SingerDto>> GetAll()
        {
            var obj = new TData<IEnumerable<SingerDto>>();
            var singers = _unit.GetRepository<Singer>().Query().Where(x => !x.IsDeleted).ToList();
            var singerDtos = singers.Select(s => SingerMapper.MapToDto(s));
            obj.SetSuccess(singerDtos);
            return obj;
        }

        public TData Delete(int id)
        {
            var obj = new TData();
            var singer = _unit.GetRepository<Singer>().Query().FirstOrDefault(x => x.Id == id);
            if (singer == null)
            {
                obj.SetNotFound();
                return obj;
            }
            _unit.GetRepository<Singer>().Remove(singer);
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
