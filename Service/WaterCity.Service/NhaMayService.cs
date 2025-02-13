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
using WaterCity.Core.Models.NhaMay;

namespace WaterCity.Service
{
    [ScopedDependency(ServiceType = typeof(INhaMayService))]
    public class NhaMayService : Base.Service, INhaMayService
    {

        private readonly INhaMayRepository _nhaMayRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public NhaMayService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _nhaMayRepository = serviceProvider.GetRequiredService<INhaMayRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        /*public Task<ICollection<NhaMayEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var entities = _nhaMayRepository.Get(_ => _.DeletedTime == null).ToList();
            return Task.FromResult((ICollection<NhaMayEntity>)entities);
        }

        public Task<NhaMayEntity> GetByKeyIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var entity = _nhaMayRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return Task.FromResult(entity);
        }*/

        public ICollection<NhaMayEntity> GetAllAsync()
        {
            var entities = _nhaMayRepository.Get(_ => _.DeletedTime == null).ToList();
            return (ICollection<NhaMayEntity>)entities;
        }

        public NhaMayEntity GetByKeyIdAsync(string id)
        {
            var entity = _nhaMayRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return entity;
        }

        public Task<string> CreateAsync(NhaMayModel model, CancellationToken cancellationToken = default)
        {
            if (_nhaMayRepository.Get(x => x.KeyId == model.KeyId &&
                x.DeletedTime == null
                ).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.KeyId);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsNhaMay.NHA_MAY_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<NhaMayEntity>(model);
            _nhaMayRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.Id);
        }

        public Task UpdateAsync(string Id, NhaMayModel model, CancellationToken cancellationToken = default)
        {
            var entity = _nhaMayRepository.GetTracking(x => x.KeyId == Id &&
                x.DeletedTime == null
                ).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsNhaMay.NHA_MAY_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.KeyId != Id)
            {
                var isDuplicate = _nhaMayRepository.GetTracking(x => x.KeyId == model.KeyId && x.DeletedTime == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsNhaMay.NHA_MAY_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _nhaMayRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _nhaMayRepository.GetTracking(x => x.KeyId == id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsNhaMay.NHA_MAY_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _nhaMayRepository.Delete(entity, isPhysicalDelete: isPhysical);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }
    }
}
