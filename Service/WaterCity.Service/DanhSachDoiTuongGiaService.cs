using AutoMapper;
using Invedia.DI.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using WaterCity.Contract.Repository.Interface;
using WaterCity.Contract.Repository.Models;
using WaterCity.Contract.Service;
using WaterCity.Core.Constants;
using WaterCity.Core.Exceptions;
using WaterCity.Core.Models.DanhSachDoiTuongGia;
using WaterCity.Core.Models.DanhSachDoiTuongGia;

namespace WaterCity.Service
{
    [ScopedDependency(ServiceType = typeof(IDanhSachDoiTuongGiaService))]
    public class DanhSachDoiTuongGiaService : Base.Service, IDanhSachDoiTuongGiaService
    {

        private readonly IDanhSachDoiTuongGiaRepository _danhSachDoiTuongGiaRepository;
        private readonly IMapper _mapper;
        ILogger _logger;
        public DanhSachDoiTuongGiaService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _danhSachDoiTuongGiaRepository = serviceProvider.GetRequiredService<IDanhSachDoiTuongGiaRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(DanhSachDoiTuongGiaModel model, CancellationToken cancellationToken = default)
        {
            if (_danhSachDoiTuongGiaRepository.Get(_ => _.KeyId == model.KeyId && _.DeletedTime == null).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.KeyId);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsDanhSachDoiTuongGia.DANH_SACH_DOI_TUONG_GIA_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<DanhSachDoiTuongGiaEntity>(model);
            _danhSachDoiTuongGiaRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.Id);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _danhSachDoiTuongGiaRepository.GetTracking(x => x.KeyId == id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsDanhSachDoiTuongGia.DANH_SACH_DOI_TUONG_GIA_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _danhSachDoiTuongGiaRepository.Delete(entity, isPhysicalDelete: isPhysical);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        /*public Task<ICollection<DanhSachDoiTuongGiaEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var entities = _danhSachDoiTuongGiaRepository.Get(_ => _.DeletedTime == null).ToList();
            return Task.FromResult((ICollection<DanhSachDoiTuongGiaEntity>)entities);
        }

        public Task<DanhSachDoiTuongGiaEntity> GetByKeyIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var entity = _danhSachDoiTuongGiaRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return Task.FromResult(entity);
        }*/

        public ICollection<DanhSachDoiTuongGiaEntity> GetAllAsync()
        {
            var entities = _danhSachDoiTuongGiaRepository.Get(_ => _.DeletedTime == null).ToList();
            return (ICollection<DanhSachDoiTuongGiaEntity>)entities;
        }

        public DanhSachDoiTuongGiaEntity GetByKeyIdAsync(string id)
        {
            var entity = _danhSachDoiTuongGiaRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return entity;
        }

        public Task UpdateAsync(string Id, DanhSachDoiTuongGiaModel model, CancellationToken cancellationToken = default)
        {
            var entity = _danhSachDoiTuongGiaRepository.GetTracking(x => x.KeyId == Id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsDanhSachDoiTuongGia.DANH_SACH_DOI_TUONG_GIA_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.KeyId != Id)
            {
                var isDuplicate = _danhSachDoiTuongGiaRepository.GetTracking(x => x.KeyId == model.KeyId && x.DeletedTime == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsDanhSachDoiTuongGia.DANH_SACH_DOI_TUONG_GIA_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _danhSachDoiTuongGiaRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }
    }
}
