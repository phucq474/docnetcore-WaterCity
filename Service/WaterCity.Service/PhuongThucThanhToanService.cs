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
using WaterCity.Core.Models.PhuongThucThanhToan;

namespace WaterCity.Service
{
    [ScopedDependency(ServiceType = typeof(IPhuongThucThanhToanService))]
    public class PhuongThucThanhToanService : Base.Service, IPhuongThucThanhToanService
    {
        private readonly IPhuongThucThanhToanRepository _PhuongThucThanhToanRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public PhuongThucThanhToanService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _PhuongThucThanhToanRepository = serviceProvider.GetRequiredService<IPhuongThucThanhToanRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }


        /*public Task<ICollection<PhuongThucThanhToanEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var entities = _PhuongThucThanhToanRepository.Get(_ => _.DeletedTime == null).ToList();
            return Task.FromResult((ICollection<PhuongThucThanhToanEntity>)entities);
        }

        public Task<PhuongThucThanhToanEntity> GetByKeyIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var entity = _PhuongThucThanhToanRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return Task.FromResult(entity);
        }*/

        public ICollection<PhuongThucThanhToanEntity> GetAllAsync()
        {
            var entities = _PhuongThucThanhToanRepository.Get(_ => _.DeletedTime == null).ToList();
            return (ICollection<PhuongThucThanhToanEntity>)entities;
        }

        public PhuongThucThanhToanEntity GetByKeyIdAsync(string id)
        {
            var entity = _PhuongThucThanhToanRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return entity;
        }

        public Task<string> CreateAsync(PhuongThucThanhToanModel model, CancellationToken cancellationToken = default)
        {
            if (_PhuongThucThanhToanRepository.Get(x => x.KeyId == model.KeyId &&
                x.DeletedTime == null
                ).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.KeyId);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsPhuongThucThanhToan.PHUONG_THUC_THANH_TOAN_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<PhuongThucThanhToanEntity>(model);
            _PhuongThucThanhToanRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.Id);
        }

        public Task UpdateAsync(string Id, PhuongThucThanhToanModel model, CancellationToken cancellationToken = default)
        {
            var entity = _PhuongThucThanhToanRepository.GetTracking(x => x.KeyId == Id &&
                x.DeletedTime == null
                ).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsPhuongThucThanhToan.PHUONG_THUC_THANH_TOAN_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.KeyId != Id)
            {
                var isDuplicate = _PhuongThucThanhToanRepository.GetTracking(x => x.KeyId == model.KeyId && x.DeletedTime == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsPhuongThucThanhToan.PHUONG_THUC_THANH_TOAN_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _PhuongThucThanhToanRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _PhuongThucThanhToanRepository.GetTracking(x => x.KeyId == id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsPhuongThucThanhToan.PHUONG_THUC_THANH_TOAN_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _PhuongThucThanhToanRepository.Delete(entity, isPhysicalDelete: isPhysical);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

    }
}
