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
using WaterCity.Core.Models.LichSuSMS;

namespace WaterCity.Service
{
    [ScopedDependency(ServiceType = typeof(ILichSuSMSService))]
    public class LichSuSMSService : Base.Service, ILichSuSMSService
    {
        private readonly ILichSuSMSRepository _LichSuSMSRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public LichSuSMSService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _LichSuSMSRepository = serviceProvider.GetRequiredService<ILichSuSMSRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        /*public Task<ICollection<LichSuSMSEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var entities = _LichSuSMSRepository.Get(_ => _.DeletedTime == null).ToList();
            return Task.FromResult((ICollection<LichSuSMSEntity>)entities);
        }

        public Task<LichSuSMSEntity> GetByKeyIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var entity = _LichSuSMSRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return Task.FromResult(entity);
        }*/

        public ICollection<LichSuSMSEntity> GetAllAsync()
        {
            var entities = _LichSuSMSRepository.Get(_ => _.DeletedTime == null).ToList();
            return (ICollection<LichSuSMSEntity>)entities;
        }

        public LichSuSMSEntity GetByKeyIdAsync(string id)
        {
            var entity = _LichSuSMSRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return entity;
        }

        public Task<string> CreateAsync(LichSuSMSModel model, CancellationToken cancellationToken = default)
        {
            if (_LichSuSMSRepository.Get(x => x.KeyId == model.KeyId &&
                x.DeletedTime == null
                ).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.KeyId);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsLichSuSMS.LICH_SU_SMS_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<LichSuSMSEntity>(model);
            _LichSuSMSRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.Id);
        }

        public Task UpdateAsync(string Id, LichSuSMSModel model, CancellationToken cancellationToken = default)
        {
            var entity = _LichSuSMSRepository.GetTracking(x => x.KeyId == Id &&
                x.DeletedTime == null
                ).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsLichSuSMS.LICH_SU_SMS_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.KeyId != Id)
            {
                var isDuplicate = _LichSuSMSRepository.GetTracking(x => x.KeyId == model.KeyId && x.DeletedTime == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsLichSuSMS.LICH_SU_SMS_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _LichSuSMSRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _LichSuSMSRepository.GetTracking(x => x.KeyId == id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsLichSuSMS.LICH_SU_SMS_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _LichSuSMSRepository.Delete(entity, isPhysicalDelete: isPhysical);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

    }
}
