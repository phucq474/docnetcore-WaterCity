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
using WaterCity.Core.Models.DanhMucSeriHoaDon;

namespace WaterCity.Service
{
    [ScopedDependency(ServiceType = typeof(IDanhMucSeriHoaDonService))]
    public class DanhMucSeriHoaDonService : Base.Service, IDanhMucSeriHoaDonService
    {

        private readonly IDanhMucSeriHoaDonRepository _DanhMucSeriHoaDonRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public DanhMucSeriHoaDonService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _DanhMucSeriHoaDonRepository = serviceProvider.GetRequiredService<IDanhMucSeriHoaDonRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        /*public Task<ICollection<DanhMucSeriHoaDonEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var entities = _DanhMucSeriHoaDonRepository.Get(_ => _.DeletedTime == null).ToList();
            return Task.FromResult((ICollection<DanhMucSeriHoaDonEntity>)entities);
        }

        public Task<DanhMucSeriHoaDonEntity> GetByKeyIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var entity = _DanhMucSeriHoaDonRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return Task.FromResult(entity);
        }*/

        public ICollection<DanhMucSeriHoaDonEntity> GetAllAsync()
        {
            var entities = _DanhMucSeriHoaDonRepository.Get(_ => _.DeletedTime == null).ToList();
            return (ICollection<DanhMucSeriHoaDonEntity>)entities;
        }

        public DanhMucSeriHoaDonEntity GetByKeyIdAsync(string id)
        {
            var entity = _DanhMucSeriHoaDonRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return entity;
        }

        public Task<string> CreateAsync(DanhMucSeriHoaDonModel model, CancellationToken cancellationToken = default)
        {
            if (_DanhMucSeriHoaDonRepository.Get(x => x.KeyId == model.KeyId && x.DeletedTime == null).Any())
            {
                _logger.Information(ErrorCode.NotFound, model.KeyId);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsDanhMucSeriHoaDon.DANH_MUC_SERI_HOA_DON_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<DanhMucSeriHoaDonEntity>(model);
            _DanhMucSeriHoaDonRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.Id);
        }

        public Task UpdateAsync(string Id, DanhMucSeriHoaDonModel model, CancellationToken cancellationToken = default)
        {
            var entity = _DanhMucSeriHoaDonRepository.GetTracking(x => x.KeyId == Id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsDanhMucSeriHoaDon.DANH_MUC_SERI_HOA_DON_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.KeyId != Id)
            {
                var isDuplicate = _DanhMucSeriHoaDonRepository.GetTracking(x => x.KeyId == model.KeyId && x.DeletedTime == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsDanhMucSeriHoaDon.DANH_MUC_SERI_HOA_DON_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _DanhMucSeriHoaDonRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _DanhMucSeriHoaDonRepository.GetTracking(x => x.KeyId == id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsDanhMucSeriHoaDon.DANH_MUC_SERI_HOA_DON_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _DanhMucSeriHoaDonRepository.Delete(entity, isPhysicalDelete: isPhysical);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }
    }
}
