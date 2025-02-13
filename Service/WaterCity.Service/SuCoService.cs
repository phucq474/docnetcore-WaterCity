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
using WaterCity.Core.Models.SuCo;

namespace WaterCity.Service
{
    [ScopedDependency(ServiceType = typeof(ISuCoService))]
    public class SuCoService : Base.Service, ISuCoService
    {

        private readonly ISuCoRepository _suCoRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public SuCoService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _suCoRepository = serviceProvider.GetRequiredService<ISuCoRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(SuCoModel model, CancellationToken cancellationToken = default)
        {
            if (_suCoRepository.Get(_ => _.KeyId == model.KeyId && _.DeletedTime == null).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.KeyId);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsSuCo.SU_CO_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<SuCoEntity>(model);
            _suCoRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.Id);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _suCoRepository.GetTracking(x => x.KeyId == id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsSuCo.SU_CO_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _suCoRepository.Delete(entity, isPhysicalDelete: isPhysical);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        /*public Task<ICollection<SuCoEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var entities = _suCoRepository.Get(_ => _.DeletedTime == null).ToList();
            return Task.FromResult((ICollection<SuCoEntity>)entities);
        }

        public Task<SuCoEntity> GetByKeyIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var entity = _suCoRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return Task.FromResult(entity);
        }*/

        public ICollection<SuCoEntity> GetAllAsync()
        {
            var entities = _suCoRepository.Get(_ => _.DeletedTime == null).ToList();
            return (ICollection<SuCoEntity>)entities;
        }

        public SuCoEntity GetByKeyIdAsync(string id)
        {
            var entity = _suCoRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return entity;
        }

        public Task UpdateAsync(string Id, SuCoModel model, CancellationToken cancellationToken = default)
        {
            var entity = _suCoRepository.GetTracking(x => x.KeyId == Id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsSuCo.SU_CO_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.KeyId != Id)
            {
                var isDuplicate = _suCoRepository.GetTracking(x => x.KeyId == model.KeyId && x.DeletedTime == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsSuCo.SU_CO_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _suCoRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }
    }
}
