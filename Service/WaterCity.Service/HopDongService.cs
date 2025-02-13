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
using WaterCity.Core.Models.HopDong;

namespace WaterCity.Service
{
    [ScopedDependency(ServiceType = typeof(IHopDongService))]
    public class HopDongService : Base.Service, IHopDongService
    {

        private readonly IHopDongRepository _hopDongRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public HopDongService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _hopDongRepository = serviceProvider.GetRequiredService<IHopDongRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        /*public Task<ICollection<HopDongEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var entities = _hopDongRepository.Get(_ => _.DeletedTime == null).ToList();
            return Task.FromResult((ICollection<HopDongEntity>)entities);
        }

        public Task<HopDongEntity> GetByKeyIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var entity = _hopDongRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return Task.FromResult(entity);
        }*/

        public ICollection<HopDongEntity> GetAllAsync()
        {
            var entities = _hopDongRepository.Get(_ => _.DeletedTime == null).ToList();
            return (ICollection<HopDongEntity>)entities;
        }

        public HopDongEntity GetByKeyIdAsync(string id)
        {
            var entity = _hopDongRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return entity;
        }
        public HopDongEntity GetByIdAsync(string id)
        {
            var entity = _hopDongRepository.GetSingle(_ => _.Id == id && _.DeletedTime == null);
            return entity;
        }
        
        public Task<string> CreateAsync(HopDongModel model, CancellationToken cancellationToken = default)
        {
            if (_hopDongRepository.Get(x => x.KeyId == model.KeyId && x.DeletedTime == null).Any())
            {
                _logger.Information(ErrorCode.NotFound, model.KeyId);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsHopDong.HOP_DONG_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<HopDongEntity>(model);
            _hopDongRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.Id);
        }

        public Task UpdateAsync(string Id, HopDongModel model, CancellationToken cancellationToken = default)
        {
            var entity = _hopDongRepository.GetTracking(x => x.KeyId == Id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsHopDong.HOP_DONG_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.KeyId != Id)
            {
                var isDuplicate = _hopDongRepository.GetTracking(x => x.KeyId == model.KeyId && x.DeletedTime == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsHopDong.HOP_DONG_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _hopDongRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _hopDongRepository.GetTracking(x => x.KeyId == id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsHopDong.HOP_DONG_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _hopDongRepository.Delete(entity, isPhysicalDelete: isPhysical);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        
    }
}
