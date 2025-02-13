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
using WaterCity.Core.Models.ChiTietHoaDon;

namespace WaterCity.Service
{
    [ScopedDependency(ServiceType = typeof(IChiTietHoaDonService))]
    public class ChiTietHoaDonService : Base.Service, IChiTietHoaDonService
    {

        private readonly IChiTietHoaDonRepository _ChiTietHoaDonRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public ChiTietHoaDonService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _ChiTietHoaDonRepository = serviceProvider.GetRequiredService<IChiTietHoaDonRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        /*public Task<ICollection<ChiTietHoaDonEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var entities = _ChiTietHoaDonRepository.Get(_ => _.DeletedTime == null).ToList();
            return Task.FromResult((ICollection<ChiTietHoaDonEntity>)entities);
        }

        public Task<ChiTietHoaDonEntity> GetByKeyIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var entity = _ChiTietHoaDonRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return Task.FromResult(entity);
        }*/

        public ICollection<ChiTietHoaDonEntity> GetAllAsync()
        {
            var entities = _ChiTietHoaDonRepository.Get(_ => _.DeletedTime == null).ToList();
            return (ICollection<ChiTietHoaDonEntity>)entities;
        }

        public ChiTietHoaDonEntity GetByKeyIdAsync(string id)
        {
            var entity = _ChiTietHoaDonRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return entity;
        }

        public Task<string> CreateAsync(ChiTietHoaDonModel model, CancellationToken cancellationToken = default)
        {
            if (_ChiTietHoaDonRepository.Get(x => x.KeyId == model.KeyId &&
                x.DeletedTime == null
                ).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.KeyId);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsChiTietHoaDon.CHI_TIET_HOA_DON_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<ChiTietHoaDonEntity>(model);
            _ChiTietHoaDonRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.Id);
        }

        public Task UpdateAsync(string Id, ChiTietHoaDonModel model, CancellationToken cancellationToken = default)
        {
            var entity = _ChiTietHoaDonRepository.GetTracking(x => x.KeyId == Id &&
                x.DeletedTime == null
                ).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsChiTietHoaDon.CHI_TIET_HOA_DON_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.KeyId != Id)
            {
                var isDuplicate = _ChiTietHoaDonRepository.GetTracking(x => x.KeyId == model.KeyId && x.DeletedTime == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsChiTietHoaDon.CHI_TIET_HOA_DON_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _ChiTietHoaDonRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _ChiTietHoaDonRepository.GetTracking(x => x.KeyId == id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsChiTietHoaDon.CHI_TIET_HOA_DON_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _ChiTietHoaDonRepository.Delete(entity, isPhysicalDelete: isPhysical);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }
    }
}
