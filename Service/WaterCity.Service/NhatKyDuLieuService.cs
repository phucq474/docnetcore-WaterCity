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
using WaterCity.Core.Models.NhatKyDuLieu;

namespace WaterCity.Service
{
    [ScopedDependency(ServiceType = typeof(INhatKyDuLieuService))]
    public class NhatKyDuLieuService : Base.Service, INhatKyDuLieuService
    {

        private readonly INhatKyDuLieuRepository _nhatKyDuLieuRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public NhatKyDuLieuService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _nhatKyDuLieuRepository = serviceProvider.GetRequiredService<INhatKyDuLieuRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        /*public Task<ICollection<NhatKyDuLieuEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var entities = _nhatKyDuLieuRepository.Get(_ => _.DeletedTime == null).ToList();
            return Task.FromResult((ICollection<NhatKyDuLieuEntity>)entities);
        }

        public Task<NhatKyDuLieuEntity> GetByKeyIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var entity = _nhatKyDuLieuRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return Task.FromResult(entity);
        }*/

        public ICollection<NhatKyDuLieuEntity> GetAllAsync()
        {
            var entities = _nhatKyDuLieuRepository.Get(_ => _.DeletedTime == null).ToList();
            return (ICollection<NhatKyDuLieuEntity>)entities;
        }

        public NhatKyDuLieuEntity GetByKeyIdAsync(string id)
        {
            var entity = _nhatKyDuLieuRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return entity;
        }

        public Task<string> CreateAsync(NhatKyDuLieuModel model, CancellationToken cancellationToken = default)
        {
            if (_nhatKyDuLieuRepository.Get(x => x.KeyId == model.KeyId &&
                x.DeletedTime == null
                ).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.KeyId);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsNhatKyDuLieu.NHAT_KY_DU_LIEU_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<NhatKyDuLieuEntity>(model);
            _nhatKyDuLieuRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.Id);
        }

        public Task UpdateAsync(string Id, NhatKyDuLieuModel model, CancellationToken cancellationToken = default)
        {
            var entity = _nhatKyDuLieuRepository.GetTracking(x => x.KeyId == Id &&
                x.DeletedTime == null
                ).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsNhatKyDuLieu.NHAT_KY_DU_LIEU_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.KeyId != Id)
            {
                var isDuplicate = _nhatKyDuLieuRepository.GetTracking(x => x.KeyId == model.KeyId && x.DeletedTime == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsNhatKyDuLieu.NHAT_KY_DU_LIEU_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _nhatKyDuLieuRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _nhatKyDuLieuRepository.GetTracking(x => x.KeyId == id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsNhatKyDuLieu.NHAT_KY_DU_LIEU_EXISTED, statusCode: StatusCodes.Status404NotFound);
            }
            _nhatKyDuLieuRepository.Delete(entity, isPhysicalDelete: isPhysical);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }
    }
}
