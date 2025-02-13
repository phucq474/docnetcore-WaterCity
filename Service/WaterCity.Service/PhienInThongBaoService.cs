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
using WaterCity.Core.Models.PhienInThongBao;

namespace WaterCity.Service
{
    [ScopedDependency(ServiceType = typeof(IPhienInThongBaoService))]
    public class PhienInThongBaoService : Base.Service, IPhienInThongBaoService
    {

        private readonly IPhienInThongBaoRepository _phienInThongBaoRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public PhienInThongBaoService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _phienInThongBaoRepository = serviceProvider.GetRequiredService<IPhienInThongBaoRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(PhienInThongBaoModel model, CancellationToken cancellationToken = default)
        {
            if (_phienInThongBaoRepository.Get(_ => _.KeyId == model.KeyId && _.DeletedTime == null).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.KeyId);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsPhienInThongBao.PHIEN_IN_THONG_BAO_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<PhienInThongBaoEntity>(model);
            _phienInThongBaoRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.Id);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _phienInThongBaoRepository.GetTracking(x => x.KeyId == id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsPhienInThongBao.PHIEN_IN_THONG_BAO_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _phienInThongBaoRepository.Delete(entity, isPhysicalDelete: isPhysical);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        /*public Task<ICollection<PhienInThongBaoEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var entities = _phienInThongBaoRepository.Get(_ => _.DeletedTime == null).ToList();
            return Task.FromResult((ICollection<PhienInThongBaoEntity>)entities);
        }

        public Task<PhienInThongBaoEntity> GetByKeyIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var entity = _phienInThongBaoRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return Task.FromResult(entity);
        }*/

        public ICollection<PhienInThongBaoEntity> GetAllAsync()
        {
            var entities = _phienInThongBaoRepository.Get(_ => _.DeletedTime == null).ToList();
            return (ICollection<PhienInThongBaoEntity>)entities;
        }

        public PhienInThongBaoEntity GetByKeyIdAsync(string id)
        {
            var entity = _phienInThongBaoRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return entity;
        }

        public Task UpdateAsync(string Id, PhienInThongBaoModel model, CancellationToken cancellationToken = default)
        {
            var entity = _phienInThongBaoRepository.GetTracking(x => x.KeyId == Id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsPhienInThongBao.PHIEN_IN_THONG_BAO_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.KeyId != Id)
            {
                var isDuplicate = _phienInThongBaoRepository.GetTracking(x => x.KeyId == model.KeyId && x.DeletedTime == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsPhienInThongBao.PHIEN_IN_THONG_BAO_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _phienInThongBaoRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }
    }
}
