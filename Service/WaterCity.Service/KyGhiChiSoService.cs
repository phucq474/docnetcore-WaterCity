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
using WaterCity.Core.Models.KyGhiChiSo;

namespace WaterCity.Service
{
    [ScopedDependency(ServiceType = typeof(IKyGhiChiSoService))]
    public class KyGhiChiSoService : Base.Service, IKyGhiChiSoService
    {

        private readonly IKyGhiChiSoRepository _kyGhiChiSoRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public KyGhiChiSoService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _kyGhiChiSoRepository = serviceProvider.GetRequiredService<IKyGhiChiSoRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        /*public Task<ICollection<KyGhiChiSoEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var entities = _kyGhiChiSoRepository.Get(_ => _.DeletedTime == null).ToList();
            return Task.FromResult((ICollection<KyGhiChiSoEntity>)entities);
        }

        public Task<KyGhiChiSoEntity> GetByKeyIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var entity = _kyGhiChiSoRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return Task.FromResult(entity);
        }*/

        public ICollection<KyGhiChiSoEntity> GetAllAsync()
        {
            var entities = _kyGhiChiSoRepository.Get(_ => _.DeletedTime == null).ToList();
            return (ICollection<KyGhiChiSoEntity>)entities;
        }

        public KyGhiChiSoEntity GetByKeyIdAsync(string id)
        {
            var entity = _kyGhiChiSoRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return entity;
        }

        public Task<string> CreateAsync(KyGhiChiSoModel model, CancellationToken cancellationToken = default)
        {
            if (_kyGhiChiSoRepository.Get(x => x.KeyId == model.KeyId &&
                x.DeletedTime == null
                ).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.KeyId);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsKyGhiChiSo.KY_GHI_CHI_SO_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<KyGhiChiSoEntity>(model);
            _kyGhiChiSoRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.Id);
        }

        public Task UpdateAsync(string Id, KyGhiChiSoModel model, CancellationToken cancellationToken = default)
        {
            var entity = _kyGhiChiSoRepository.GetTracking(x => x.KeyId == Id &&
                x.DeletedTime == null
                ).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsKyGhiChiSo.KY_GHI_CHI_SO_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.KeyId != Id)
            {
                var isDuplicate = _kyGhiChiSoRepository.GetTracking(x => x.KeyId == model.KeyId && x.DeletedTime == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsKyGhiChiSo.KY_GHI_CHI_SO_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _kyGhiChiSoRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _kyGhiChiSoRepository.GetTracking(x => x.KeyId == id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsKyGhiChiSo.KY_GHI_CHI_SO_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _kyGhiChiSoRepository.Delete(entity, isPhysicalDelete: isPhysical);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }
    }
}
