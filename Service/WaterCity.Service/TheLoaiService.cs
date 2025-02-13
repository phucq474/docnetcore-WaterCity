using AutoMapper;
using Invedia.DI.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using WaterCity.Contract.Repository.Interface;
using WaterCity.Contract.Repository.Models;
using WaterCity.Contract.Service;
using WaterCity.Core.Constants;
using WaterCity.Core.Exceptions;
using WaterCity.Core.Models.TheLoai;

namespace WaterCity.Service
{
    [ScopedDependency(ServiceType = typeof(ITheLoaiService))]
    public class TheLoaiService : Base.Service, ITheLoaiService
    {

        private readonly ITheLoaiRepository _TheLoaiRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public TheLoaiService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _TheLoaiRepository = serviceProvider.GetRequiredService<ITheLoaiRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        /*public Task<ICollection<TheLoaiEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var entities = _TheLoaiRepository.Get(_ => _.DeletedTime == null).ToList();
            return Task.FromResult((ICollection<TheLoaiEntity>)entities);
        }

        public Task<TheLoaiEntity> GetByKeyIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var entity = _TheLoaiRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return Task.FromResult(entity);
        }*/

        public ICollection<TheLoaiEntity> GetAllAsync()
        {
            var entities = _TheLoaiRepository.Get(_ => _.DeletedTime == null).ToList();
            return (ICollection<TheLoaiEntity>)entities;
        }

        public TheLoaiEntity GetByKeyIdAsync(string id)
        {
            var entity = _TheLoaiRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return entity;
        }

        public Task<string> CreateAsync(TheLoaiModel model, CancellationToken cancellationToken = default)
        {
            if (_TheLoaiRepository.Get(x => x.KeyId == model.KeyId && x.DeletedTime == null).Any())
            {
                _logger.Information(ErrorCode.NotFound, model.KeyId);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsTheLoai.THELOAI_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<TheLoaiEntity>(model);
            _TheLoaiRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.Id);
        }

        public Task UpdateAsync(string Id, TheLoaiModel model, CancellationToken cancellationToken = default)
        {
            var entity = _TheLoaiRepository.GetTracking(x => x.KeyId == Id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsTheLoai.THELOAI_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.KeyId != Id)
            {
                var isDuplicate = _TheLoaiRepository.GetTracking(x => x.KeyId == model.KeyId && x.DeletedTime == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsTheLoai.THELOAI_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _TheLoaiRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _TheLoaiRepository.GetTracking(x => x.KeyId == id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsTheLoai.THELOAI_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _TheLoaiRepository.Delete(entity, isPhysicalDelete: isPhysical);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }
    }
}
