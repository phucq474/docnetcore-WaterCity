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
using WaterCity.Core.Models.KhuVuc;

namespace WaterCity.Service
{
    [ScopedDependency(ServiceType = typeof(IKhuVucService))]
    public class KhuVucService : Base.Service, IKhuVucService
    {

        private readonly IKhuVucRepository _khuVucRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public KhuVucService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _khuVucRepository = serviceProvider.GetRequiredService<IKhuVucRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        /*public Task<ICollection<KhuVucEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var entities = _khuVucRepository.Get(_ => _.DeletedTime == null).ToList();
            return Task.FromResult((ICollection<KhuVucEntity>)entities);
        }

        public Task<KhuVucEntity> GetByKeyIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var entity = _khuVucRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return Task.FromResult(entity);
        }*/

        public ICollection<KhuVucEntity> GetAllAsync()
        {
            var entities = _khuVucRepository.Get(_ => _.DeletedTime == null).ToList();
            return (ICollection<KhuVucEntity>)entities;
        }

        public KhuVucEntity GetByKeyIdAsync(string id)
        {
            var entity = _khuVucRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return entity;
        }

        public Task<string> CreateAsync(KhuVucModel model, CancellationToken cancellationToken = default)
        {
            if (_khuVucRepository.Get(x => x.KeyId == model.KeyId &&
                x.DeletedTime == null
                ).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.KeyId);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsKhuVuc.KHU_VUC_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<KhuVucEntity>(model);
            _khuVucRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.Id);
        }

        public Task UpdateAsync(string Id, KhuVucModel model, CancellationToken cancellationToken = default)
        {
            var entity = _khuVucRepository.GetTracking(x => x.KeyId == Id &&
                x.DeletedTime == null
                ).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsKhuVuc.KHU_VUC_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.KeyId != Id)
            {
                var isDuplicate = _khuVucRepository.GetTracking(x => x.KeyId == model.KeyId && x.DeletedTime == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsKhuVuc.KHU_VUC_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _khuVucRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _khuVucRepository.GetTracking(x => x.KeyId == id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsKhuVuc.KHU_VUC_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _khuVucRepository.Delete(entity, isPhysicalDelete: isPhysical);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }
    }
}
