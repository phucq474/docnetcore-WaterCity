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
using WaterCity.Core.Models.NhatKyHoaDon;

namespace WaterCity.Service
{
    [ScopedDependency(ServiceType = typeof(INhatKyHoaDonService))]
    public class NhatKyHoaDonService : Base.Service, INhatKyHoaDonService
    {

        private readonly INhatKyHoaDonRepository _nhatKyHoaDonRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public NhatKyHoaDonService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _nhatKyHoaDonRepository = serviceProvider.GetRequiredService<INhatKyHoaDonRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        /*public Task<ICollection<NhatKyHoaDonEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var entities = _nhatKyHoaDonRepository.Get(_ => _.DeletedTime == null).ToList();
            return Task.FromResult((ICollection<NhatKyHoaDonEntity>)entities);
        }

        public Task<NhatKyHoaDonEntity> GetByKeyIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var entity = _nhatKyHoaDonRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return Task.FromResult(entity);
        }*/

        public ICollection<NhatKyHoaDonEntity> GetAllAsync()
        {
            var entities = _nhatKyHoaDonRepository.Get(_ => _.DeletedTime == null).ToList();
            return (ICollection<NhatKyHoaDonEntity>)entities;
        }

        public NhatKyHoaDonEntity GetByKeyIdAsync(string id)
        {
            var entity = _nhatKyHoaDonRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return entity;
        }

        public Task<string> CreateAsync(NhatKyHoaDonModel model, CancellationToken cancellationToken = default)
        {
            if (_nhatKyHoaDonRepository.Get(x => x.KeyId == model.KeyId &&
                x.DeletedTime == null
                ).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.KeyId);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsNhatKyHoaDon.NHAT_KY_HOA_DON_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<NhatKyHoaDonEntity>(model);
            _nhatKyHoaDonRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.Id);
        }

        public Task UpdateAsync(string Id, NhatKyHoaDonModel model, CancellationToken cancellationToken = default)
        {
            var entity = _nhatKyHoaDonRepository.GetTracking(x => x.KeyId == Id &&
                x.DeletedTime == null
                ).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsNhatKyHoaDon.NHAT_KY_HOA_DON_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.KeyId != Id)
            {
                var isDuplicate = _nhatKyHoaDonRepository.GetTracking(x => x.KeyId == model.KeyId && x.DeletedTime == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsNhatKyHoaDon.NHAT_KY_HOA_DON_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _nhatKyHoaDonRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _nhatKyHoaDonRepository.GetTracking(x => x.KeyId == id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsNhatKyHoaDon.NHAT_KY_HOA_DON_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _nhatKyHoaDonRepository.Delete(entity, isPhysicalDelete: isPhysical);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }
    }
}
