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
using WaterCity.Core.Models.HoaDon;

namespace WaterCity.Service
{
    [ScopedDependency(ServiceType = typeof(IHoaDonService))]
    public class HoaDonService : Base.Service, IHoaDonService
    {

        private readonly IHoaDonRepository _hoaDonRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public HoaDonService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _hoaDonRepository = serviceProvider.GetRequiredService<IHoaDonRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        /*public Task<ICollection<HoaDonEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var entities = _hoaDonRepository.Get(_ => _.DeletedTime == null).ToList();
            return Task.FromResult((ICollection<HoaDonEntity>)entities);
        }

        public Task<HoaDonEntity> GetByKeyIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var entity = _hoaDonRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return Task.FromResult(entity);
        }*/

        public ICollection<HoaDonEntity> GetAllAsync()
        {
            var entities = _hoaDonRepository.Get(_ => _.DeletedTime == null).ToList();
            return (ICollection<HoaDonEntity>)entities;
        }

        public HoaDonEntity GetByKeyIdAsync(string id)
        {
            var entity = _hoaDonRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return entity;
        }

        public Task<string> CreateAsync(HoaDonModel model, CancellationToken cancellationToken = default)
        {
            if (_hoaDonRepository.Get(x => x.KeyId == model.KeyId && x.DeletedTime == null).Any())
            {
                _logger.Information(ErrorCode.NotFound, model.KeyId);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsHoaDon.HOA_DON_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<HoaDonEntity>(model);
            _hoaDonRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.Id);
        }

        public Task UpdateAsync(string Id, HoaDonModel model, CancellationToken cancellationToken = default)
        {
            var entity = _hoaDonRepository.GetTracking(x => x.KeyId == Id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsHoaDon.HOA_DON_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.KeyId != Id)
            {
                var isDuplicate = _hoaDonRepository.GetTracking(x => x.KeyId == model.KeyId && x.DeletedTime == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsHoaDon.HOA_DON_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _hoaDonRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _hoaDonRepository.GetTracking(x => x.KeyId == id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsHoaDon.HOA_DON_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _hoaDonRepository.Delete(entity, isPhysicalDelete: isPhysical);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }
    }
}
