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
using WaterCity.Core.Models.ChiTietGia;

namespace WaterCity.Service
{
    [ScopedDependency(ServiceType = typeof(IChiTietGiaService))]
    public class ChiTietGiaService : Base.Service, IChiTietGiaService
    {

        private readonly IChiTietGiaRepository _chiTietGiaRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public ChiTietGiaService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _chiTietGiaRepository = serviceProvider.GetRequiredService<IChiTietGiaRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(ChiTietGiaModel model, CancellationToken cancellationToken = default)
        {
            if (_chiTietGiaRepository.Get(_ => _.KeyId == model.KeyId && _.DeletedTime == null).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.KeyId);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsChiTietGia.CHI_TIET_GIA_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<ChiTietGiaEntity>(model);
            _chiTietGiaRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.Id);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _chiTietGiaRepository.GetTracking(x => x.KeyId == id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsChiTietGia.CHI_TIET_GIA_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _chiTietGiaRepository.Delete(entity, isPhysicalDelete: isPhysical);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        /*public Task<ICollection<ChiTietGiaEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var entities = _chiTietGiaRepository.Get(_ => _.DeletedTime == null).ToList();
            return Task.FromResult((ICollection<ChiTietGiaEntity>)entities);
        }

        public Task<ChiTietGiaEntity> GetByKeyIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var entity = _chiTietGiaRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return Task.FromResult(entity);
        }*/

        public ICollection<ChiTietGiaEntity> GetAllAsync()
        {
            var entities = _chiTietGiaRepository.Get(_ => _.DeletedTime == null).ToList();
            return (ICollection<ChiTietGiaEntity>)entities;
        }

        public ChiTietGiaEntity GetByKeyIdAsync(string id)
        {
            var entity = _chiTietGiaRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return entity;
        }

        public Task UpdateAsync(string Id, ChiTietGiaModel model, CancellationToken cancellationToken = default)
        {
            var entity = _chiTietGiaRepository.GetTracking(x => x.KeyId == Id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsChiTietGia.CHI_TIET_GIA_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.KeyId != Id)
            {
                var isDuplicate = _chiTietGiaRepository.GetTracking(x => x.KeyId == model.KeyId && x.DeletedTime == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsChiTietGia.CHI_TIET_GIA_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }
            }

            _mapper.Map(model, entity);
            _chiTietGiaRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }
    }
}
