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
using WaterCity.Core.Models.MauTinSMS;

namespace WaterCity.Service
{
    [ScopedDependency(ServiceType = typeof(IMauTinSMSService))]
    public class MauTinSMSService : Base.Service, IMauTinSMSService
    {
        private readonly IMauTinSMSRepository _MauTinSMSRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public MauTinSMSService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _MauTinSMSRepository = serviceProvider.GetRequiredService<IMauTinSMSRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        /*public Task<ICollection<MauTinSMSEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var entities = _MauTinSMSRepository.Get(_ => _.DeletedTime == null).ToList();
            return Task.FromResult((ICollection<MauTinSMSEntity>)entities);
        }

        public Task<MauTinSMSEntity> GetByKeyIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var entity = _MauTinSMSRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return Task.FromResult(entity);
        }*/

        public ICollection<MauTinSMSEntity> GetAllAsync()
        {
            var entities = _MauTinSMSRepository.Get(_ => _.DeletedTime == null).ToList();
            return (ICollection<MauTinSMSEntity>)entities;
        }

        public MauTinSMSEntity GetByKeyIdAsync(string id)
        {
            var entity = _MauTinSMSRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return entity;
        }

        public Task<string> CreateAsync(MauTinSMSModel model, CancellationToken cancellationToken = default)
        {
            if (_MauTinSMSRepository.Get(x => x.KeyId == model.KeyId &&
                x.DeletedTime == null
                ).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.KeyId);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsMauTinSMS.MAU_TIN_SMS_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<MauTinSMSEntity>(model);
            _MauTinSMSRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.Id);
        }

        public Task UpdateAsync(string Id, MauTinSMSModel model, CancellationToken cancellationToken = default)
        {
            var entity = _MauTinSMSRepository.GetTracking(x => x.KeyId == Id &&
                x.DeletedTime == null
                ).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsMauTinSMS.MAU_TIN_SMS_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.KeyId != Id)
            {
                var isDuplicate = _MauTinSMSRepository.GetTracking(x => x.KeyId == model.KeyId && x.DeletedTime == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsMauTinSMS.MAU_TIN_SMS_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _MauTinSMSRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _MauTinSMSRepository.GetTracking(x => x.KeyId == id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsMauTinSMS.MAU_TIN_SMS_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _MauTinSMSRepository.Delete(entity, isPhysicalDelete: isPhysical);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

    }
}
