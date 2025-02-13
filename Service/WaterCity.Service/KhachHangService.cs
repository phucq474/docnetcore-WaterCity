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
using WaterCity.Core.Models.KhachHang;

namespace WaterCity.Service
{
    [ScopedDependency(ServiceType = typeof(IKhachHangService))]
    public class KhachHangService : Base.Service, IKhachHangService
    {

        private readonly IKhachHangRepository _KhachHangRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public KhachHangService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _KhachHangRepository = serviceProvider.GetRequiredService<IKhachHangRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        /*public Task<ICollection<KhachHangEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var entities = _KhachHangRepository.Get(_ => _.DeletedTime == null).ToList();
            return Task.FromResult((ICollection<KhachHangEntity>)entities);
        }

        public Task<KhachHangEntity> GetByKeyIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var entity = _KhachHangRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return Task.FromResult(entity);
        }*/

        public ICollection<KhachHangEntity> GetAllAsync()
        {
            var entities = _KhachHangRepository.Get(_ => _.DeletedTime == null).ToList();
            return (ICollection<KhachHangEntity>)entities   ;
        }

        public KhachHangEntity GetByKeyIdAsync(string id)
        {
            var entity = _KhachHangRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return entity;
        }

        public Task<string> CreateAsync(KhachHangModel model, CancellationToken cancellationToken = default)
        {
            if (_KhachHangRepository.Get(x => x.KeyId == model.KeyId &&
                x.DeletedTime == null
                ).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.KeyId);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsKhachHang.KHACH_HANG_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<KhachHangEntity>(model);
            _KhachHangRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.Id);
        }

        public Task UpdateAsync(string Id, KhachHangModel model, CancellationToken cancellationToken = default)
        {
            var entity = _KhachHangRepository.GetTracking(x => x.KeyId == Id &&
                x.DeletedTime == null
                ).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsKhachHang.KHACH_HANG_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.KeyId != Id)
            {
                var isDuplicate = _KhachHangRepository.GetTracking(x => x.KeyId == model.KeyId && x.DeletedTime == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsKhachHang.KHACH_HANG_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _KhachHangRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _KhachHangRepository.GetTracking(x => x.KeyId == id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsKhachHang.KHACH_HANG_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _KhachHangRepository.Delete(entity, isPhysicalDelete: isPhysical);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

       /* public Task<object> CreateAsyncaaa(KhachHangModel model, CancellationToken cancellationToken = default)
        {
            if (_KhachHangRepository.Get(x => x.KeyId == model.KeyId &&
                x.DeletedTime == null
                ).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.KeyId);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsKhachHang.KHACH_HANG_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<KhachHangEntity>(model);
            _KhachHangRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(new {entity.Id, entity.KeyId});
        }*/
    }
}
