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
using WaterCity.Core.Models.PhiDuyTri;

namespace WaterCity.Service
{
    [ScopedDependency(ServiceType = typeof(IPhiDuyTriService))]
    public class PhiDuyTriService : Base.Service, IPhiDuyTriService
    {

        private readonly IPhiDuyTriRepository _phiDuyTriRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public PhiDuyTriService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _phiDuyTriRepository = serviceProvider.GetRequiredService<IPhiDuyTriRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(PhiDuyTriModel model, CancellationToken cancellationToken = default)
        {
            if (_phiDuyTriRepository.Get(_ => _.KeyId == model.KeyId && _.DeletedTime == null).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.KeyId);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsPhiDuyTri.PHI_DUY_TRI_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<PhiDuyTriEntity>(model);
            _phiDuyTriRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.Id);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _phiDuyTriRepository.GetTracking(x => x.KeyId == id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsPhiDuyTri.PHI_DUY_TRI_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _phiDuyTriRepository.Delete(entity, isPhysicalDelete: isPhysical);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        /*public Task<ICollection<PhiDuyTriEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var entities = _phiDuyTriRepository.Get(_ => _.DeletedTime == null).ToList();
            return Task.FromResult((ICollection<PhiDuyTriEntity>)entities);
        }

        public Task<PhiDuyTriEntity> GetByKeyIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var entity = _phiDuyTriRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return Task.FromResult(entity);
        }*/

        public ICollection<PhiDuyTriEntity> GetAllAsync()
        {
            var entities = _phiDuyTriRepository.Get(_ => _.DeletedTime == null).ToList();
            return (ICollection<PhiDuyTriEntity>)entities   ;
        }

        public PhiDuyTriEntity GetByKeyIdAsync(string id)
        {
            var entity = _phiDuyTriRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return entity;
        }

        public Task UpdateAsync(string Id, PhiDuyTriModel model, CancellationToken cancellationToken = default)
        {
            var entity = _phiDuyTriRepository.GetTracking(x => x.KeyId == Id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsPhiDuyTri.PHI_DUY_TRI_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.KeyId != Id)
            {
                var isDuplicate = _phiDuyTriRepository.GetTracking(x => x.KeyId == model.KeyId && x.DeletedTime == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsPhiDuyTri.PHI_DUY_TRI_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _phiDuyTriRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }
    }
}
