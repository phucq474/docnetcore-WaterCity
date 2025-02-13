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
using WaterCity.Core.Models.TrangThaiGhi;

namespace WaterCity.Service
{
    [ScopedDependency(ServiceType = typeof(ITrangThaiGhiService))]
    public class TrangThaiGhiService : Base.Service, ITrangThaiGhiService
    {

        private readonly ITrangThaiGhiRepository _trangThaiGhiRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public TrangThaiGhiService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _trangThaiGhiRepository = serviceProvider.GetRequiredService<ITrangThaiGhiRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(TrangThaiGhiModel model, CancellationToken cancellationToken = default)
        {
            if (_trangThaiGhiRepository.Get(_ => _.KeyId == model.KeyId && _.DeletedTime == null).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.KeyId);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsTrangThaiGhi.TRANG_THAI_GHI_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<TrangThaiGhiEntity>(model);
            _trangThaiGhiRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.Id);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _trangThaiGhiRepository.GetTracking(x => x.KeyId == id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsTrangThaiGhi.TRANG_THAI_GHI_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _trangThaiGhiRepository.Delete(entity, isPhysicalDelete: isPhysical);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        /*public Task<ICollection<TrangThaiGhiEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var entities = _trangThaiGhiRepository.Get(_ => _.DeletedTime == null).ToList();
            return Task.FromResult((ICollection<TrangThaiGhiEntity>)entities);
        }

        public Task<TrangThaiGhiEntity> GetByKeyIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var entity = _trangThaiGhiRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return Task.FromResult(entity);
        }*/

        public ICollection<TrangThaiGhiEntity> GetAllAsync()
        {
            var entities = _trangThaiGhiRepository.Get(_ => _.DeletedTime == null).ToList();
            return (ICollection<TrangThaiGhiEntity>)entities;
        }

        public TrangThaiGhiEntity GetByKeyIdAsync(string id)
        {
            var entity = _trangThaiGhiRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return entity;
        }

        public Task UpdateAsync(string Id, TrangThaiGhiModel model, CancellationToken cancellationToken = default)
        {
            var entity = _trangThaiGhiRepository.GetTracking(x => x.KeyId == Id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsTrangThaiGhi.TRANG_THAI_GHI_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.KeyId != Id)
            {
                var isDuplicate = _trangThaiGhiRepository.GetTracking(x => x.KeyId == model.KeyId && x.DeletedTime == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsTrangThaiGhi.TRANG_THAI_GHI_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _trangThaiGhiRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }
    }
}
