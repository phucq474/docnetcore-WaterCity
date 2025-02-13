
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
using WaterCity.Core.Models.LyDoHuy;

namespace WaterCity.Service
{
    [ScopedDependency(ServiceType = typeof(ILyDoHuyService))]
    public class LyDoHuyService : Base.Service, ILyDoHuyService
    {

        private readonly ILyDoHuyRepository _LyDoHuyRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public LyDoHuyService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _LyDoHuyRepository = serviceProvider.GetRequiredService<ILyDoHuyRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(LyDoHuyModel model, CancellationToken cancellationToken = default)
         {
            if (_LyDoHuyRepository.Get(_ => _.KeyId == model.KeyId && _.DeletedTime == null).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.KeyId);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsLyDoHuy.LYDOHUY_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<LyDoHuyEntity>(model);
            _LyDoHuyRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.Id);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _LyDoHuyRepository.GetTracking(x => x.KeyId == id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsLyDoHuy.LYDOHUY_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _LyDoHuyRepository.Delete(entity, isPhysicalDelete: isPhysical);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<LyDoHuyEntity> GetAllAsync()
        {
            var entities = _LyDoHuyRepository.Get(_ => _.DeletedTime == null).ToList();
            return (ICollection<LyDoHuyEntity>)entities;
        }

        public LyDoHuyEntity GetByKeyIdAsync(string id)
        {
            var entity = _LyDoHuyRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return entity;
        }

        public Task UpdateAsync(string Id, LyDoHuyModel model, CancellationToken cancellationToken = default)
        {
            var entity = _LyDoHuyRepository.GetTracking(x => x.KeyId == Id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsLyDoHuy.LYDOHUY_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.KeyId != Id)
            {
                var isDuplicate = _LyDoHuyRepository.GetTracking(x => x.KeyId == model.KeyId && x.DeletedTime == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsLyDoHuy.LYDOHUY_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _LyDoHuyRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }
    }
}
