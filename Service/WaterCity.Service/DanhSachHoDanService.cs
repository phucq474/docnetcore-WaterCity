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
using WaterCity.Core.Models.DanhSachHoDan;

namespace WaterCity.Service
{
    [ScopedDependency(ServiceType = typeof(IDanhSachHoDanService))]
    public class DanhSachHoDanService : Base.Service, IDanhSachHoDanService
    {
        private readonly IDanhSachHoDanRepository _DanhSachHoDanRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public DanhSachHoDanService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _DanhSachHoDanRepository = serviceProvider.GetRequiredService<IDanhSachHoDanRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        /*public Task<ICollection<DanhSachHoDanEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var entities = _DanhSachHoDanRepository.Get(_ => _.DeletedTime == null).ToList();
            return Task.FromResult((ICollection<DanhSachHoDanEntity>)entities);
        }

        public Task<DanhSachHoDanEntity> GetByKeyIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var entity = _DanhSachHoDanRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return Task.FromResult(entity);
        }*/

        public ICollection<DanhSachHoDanEntity> GetAllAsync()
        {
            var entities = _DanhSachHoDanRepository.Get(_ => _.DeletedTime == null).ToList();
            return (ICollection<DanhSachHoDanEntity>)entities;
        }

        public DanhSachHoDanEntity GetByKeyIdAsync(string id)
        {
            var entity = _DanhSachHoDanRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return entity;
        }

        public Task<string> CreateAsync(DanhSachHoDanModel model, CancellationToken cancellationToken = default)
        {
            if (_DanhSachHoDanRepository.Get(x => x.KeyId == model.KeyId &&
                x.DeletedTime == null
                ).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.KeyId);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsDanhSachHoDan.DANH_SACH_HO_DAN_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<DanhSachHoDanEntity>(model);
            _DanhSachHoDanRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.Id);
        }

        public Task UpdateAsync(string Id, DanhSachHoDanModel model, CancellationToken cancellationToken = default)
        {
            var entity = _DanhSachHoDanRepository.GetTracking(x => x.KeyId == Id &&
                x.DeletedTime == null
                ).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsDanhSachHoDan.DANH_SACH_HO_DAN_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.KeyId != Id)
            {
                var isDuplicate = _DanhSachHoDanRepository.GetTracking(x => x.KeyId == model.KeyId && x.DeletedTime == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsDanhSachHoDan.DANH_SACH_HO_DAN_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _DanhSachHoDanRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _DanhSachHoDanRepository.GetTracking(x => x.KeyId == id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsDanhSachHoDan.DANH_SACH_HO_DAN_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _DanhSachHoDanRepository.Delete(entity, isPhysicalDelete: isPhysical);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }
    }
}
