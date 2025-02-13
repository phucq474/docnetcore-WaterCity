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
using WaterCity.Core.Models.SanPham;

namespace WaterCity.Service
{
    [ScopedDependency(ServiceType = typeof(ISanPhamService))]
    public class SanPhamService : Base.Service, ISanPhamService
    {

        private readonly ISanPhamRepository _SanPhamRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public SanPhamService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _SanPhamRepository = serviceProvider.GetRequiredService<ISanPhamRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        /*public Task<ICollection<SanPhamEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var entities = _SanPhamRepository.Get(_ => _.DeletedTime == null).ToList();
            return Task.FromResult((ICollection<SanPhamEntity>)entities);
        }

        public Task<SanPhamEntity> GetByKeyIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var entity = _SanPhamRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return Task.FromResult(entity);
        }*/

        public ICollection<SanPhamEntity> GetAllAsync()
        {
            var entities = _SanPhamRepository.Get(_ => _.DeletedTime == null).ToList();
            return (ICollection<SanPhamEntity>)entities;
        }

        public SanPhamEntity GetByKeyIdAsync(string id)
        {
            var entity = _SanPhamRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return entity;
        }

        public Task<string> CreateAsync(SanPhamModel model, CancellationToken cancellationToken = default)
        {
            if (_SanPhamRepository.Get(x => x.KeyId == model.KeyId && x.DeletedTime == null).Any())
            {
                _logger.Information(ErrorCode.NotFound, model.KeyId);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsSanPham.SANPHAM_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<SanPhamEntity>(model);
            _SanPhamRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.Id);
        }

        public Task UpdateAsync(string Id, SanPhamModel model, CancellationToken cancellationToken = default)
        {
            var entity = _SanPhamRepository.GetTracking(x => x.KeyId == Id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsSanPham.SANPHAM_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.KeyId != Id)
            {
                var isDuplicate = _SanPhamRepository.GetTracking(x => x.KeyId == model.KeyId && x.DeletedTime == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsSanPham.SANPHAM_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _SanPhamRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _SanPhamRepository.GetTracking(x => x.KeyId == id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsSanPham.SANPHAM_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _SanPhamRepository.Delete(entity, isPhysicalDelete: isPhysical);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }
    }
}
