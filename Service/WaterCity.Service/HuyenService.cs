
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
using WaterCity.Core.Models.Huyen;

namespace WaterCity.Service
{
    [ScopedDependency(ServiceType = typeof(IHuyenService))]
    public class HuyenService : Base.Service, IHuyenService
    {

        private readonly IHuyenRepository _huyenRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public HuyenService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _huyenRepository = serviceProvider.GetRequiredService<IHuyenRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(HuyenModel model, CancellationToken cancellationToken = default)
         {
            if (_huyenRepository.Get(_ => _.KeyId == model.KeyId && _.DeletedTime == null).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.KeyId);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsHuyen.HUYEN_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<HuyenEntity>(model);
            _huyenRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.Id);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _huyenRepository.GetTracking(x => x.KeyId == id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsHuyen.HUYEN_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _huyenRepository.Delete(entity, isPhysicalDelete: isPhysical);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<HuyenEntity> GetAllAsync()
        {
            var entities = _huyenRepository.Get(_ => _.DeletedTime == null).ToList();
            return (ICollection<HuyenEntity>)entities;
        }

        public HuyenEntity GetByKeyIdAsync(string id)
        {
            var entity = _huyenRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return entity;
        }

        public Task UpdateAsync(string Id, HuyenModel model, CancellationToken cancellationToken = default)
        {
            var entity = _huyenRepository.GetTracking(x => x.KeyId == Id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsHuyen.HUYEN_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.KeyId != Id)
            {
                var isDuplicate = _huyenRepository.GetTracking(x => x.KeyId == model.KeyId && x.DeletedTime == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsHuyen.HUYEN_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _huyenRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }
    }
}
