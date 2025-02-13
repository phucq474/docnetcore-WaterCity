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
using WaterCity.Core.Models.SoDocChiSo;

namespace WaterCity.Service
{
    [ScopedDependency(ServiceType = typeof(ISoDocChiSoService))]
    public class SoDocChiSoService : Base.Service, ISoDocChiSoService
    {

        private readonly ISoDocChiSoRepository _soDocChiSoRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public SoDocChiSoService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _soDocChiSoRepository = serviceProvider.GetRequiredService<ISoDocChiSoRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(SoDocChiSoModel model, CancellationToken cancellationToken = default)
        {
            if (_soDocChiSoRepository.Get(_ => _.KeyId == model.KeyId && _.DeletedTime == null).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.KeyId);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsSoDocChiSo.SO_DOC_CHI_SO_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<SoDocChiSoEntity>(model);
            _soDocChiSoRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.Id);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _soDocChiSoRepository.GetTracking(x => x.KeyId == id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsSoDocChiSo.SO_DOC_CHI_SO_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _soDocChiSoRepository.Delete(entity, isPhysicalDelete: isPhysical);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        /*public Task<ICollection<SoDocChiSoEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var entities = _soDocChiSoRepository.Get(_ => _.DeletedTime == null).ToList();
            return Task.FromResult((ICollection<SoDocChiSoEntity>)entities);
        }

        public Task<SoDocChiSoEntity> GetByKeyIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var entity = _soDocChiSoRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return Task.FromResult(entity);
        }*/

        public ICollection<SoDocChiSoEntity> GetAllAsync()
        {
            var entities = _soDocChiSoRepository.Get(_ => _.DeletedTime == null).ToList();
            return (ICollection<SoDocChiSoEntity>)entities;
        }

        public SoDocChiSoEntity GetByKeyIdAsync(string id)
        {
            var entity = _soDocChiSoRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return entity;
        }

        public Task UpdateAsync(string Id, SoDocChiSoModel model, CancellationToken cancellationToken = default)
        {
            var entity = _soDocChiSoRepository.GetTracking(x => x.KeyId == Id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsSoDocChiSo.SO_DOC_CHI_SO_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.KeyId != Id)
            {
                var isDuplicate = _soDocChiSoRepository.GetTracking(x => x.KeyId == model.KeyId && x.DeletedTime == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsSoDocChiSo.SO_DOC_CHI_SO_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _soDocChiSoRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }
    }
}
