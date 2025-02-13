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
using WaterCity.Core.Models.ChiTietDonHang;

namespace WaterCity.Service
{
    [ScopedDependency(ServiceType = typeof(IChiTietDonHangService))]
    public class ChiTietDonHangService : Base.Service, IChiTietDonHangService
    {

        private readonly IChiTietDonHangRepository _ChiTietDonHangRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public ChiTietDonHangService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _ChiTietDonHangRepository = serviceProvider.GetRequiredService<IChiTietDonHangRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        /*public Task<ICollection<ChiTietDonHangEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var entities = _ChiTietDonHangRepository.Get(_ => _.DeletedTime == null).ToList();
            return Task.FromResult((ICollection<ChiTietDonHangEntity>)entities);
        }

        public Task<ChiTietDonHangEntity> GetByKeyIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var entity = _ChiTietDonHangRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return Task.FromResult(entity);
        }*/

        public ICollection<ChiTietDonHangEntity> GetAllAsync()
        {
            var entities = _ChiTietDonHangRepository.Get(_ => _.DeletedTime == null).ToList();
            return (ICollection<ChiTietDonHangEntity>)entities;
        }

        public ChiTietDonHangEntity GetByKeyIdAsync(string id)
        {
            var entity = _ChiTietDonHangRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return entity;
        }

        public Task<string> CreateAsync(ChiTietDonHangModel model, CancellationToken cancellationToken = default)
        {
            if (_ChiTietDonHangRepository.Get(x => x.KeyId == model.KeyId && x.DeletedTime == null).Any())
            {
                _logger.Information(ErrorCode.NotFound, model.KeyId);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsChiTietDonHang.CHITIETDONHANG_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<ChiTietDonHangEntity>(model);
            _ChiTietDonHangRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.Id);
        }

        public Task UpdateAsync(string Id, ChiTietDonHangModel model, CancellationToken cancellationToken = default)
        {
            var entity = _ChiTietDonHangRepository.GetTracking(x => x.KeyId == Id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsChiTietDonHang.CHITIETDONHANG_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.KeyId != Id)
            {
                var isDuplicate = _ChiTietDonHangRepository.GetTracking(x => x.KeyId == model.KeyId && x.DeletedTime == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsChiTietDonHang.CHITIETDONHANG_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _ChiTietDonHangRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _ChiTietDonHangRepository.GetTracking(x => x.KeyId == id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsChiTietDonHang.CHITIETDONHANG_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _ChiTietDonHangRepository.Delete(entity, isPhysicalDelete: isPhysical);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }
    }
}
