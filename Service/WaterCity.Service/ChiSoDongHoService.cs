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
using WaterCity.Core.Models.ChiSoDongHo;

namespace WaterCity.Service
{
    [ScopedDependency(ServiceType = typeof(IChiSoDongHoService))]
    public class ChiSoDongHoService : Base.Service, IChiSoDongHoService
    {

        private readonly IChiSoDongHoRepository _chiSoDongHoRepository;
        private readonly IMapper _mapper;
        Serilog.ILogger _logger;

        public ChiSoDongHoService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _chiSoDongHoRepository = serviceProvider.GetRequiredService<IChiSoDongHoRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(ChiSoDongHoModel model, CancellationToken cancellationToken = default)
        {
            if (_chiSoDongHoRepository.Get(_ => _.KeyId == model.KeyId && _.DeletedTime == null).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.KeyId);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsChiSoDongHo.CHI_SO_DONG_HO_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<ChiSoDongHoEntity>(model);
            _chiSoDongHoRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.Id);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _chiSoDongHoRepository.GetTracking(x => x.KeyId == id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsChiSoDongHo.CHI_SO_DONG_HO_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _chiSoDongHoRepository.Delete(entity, isPhysicalDelete: isPhysical);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        /*public Task<ICollection<ChiSoDongHoEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var entities = _chiSoDongHoRepository.Get(_ => _.DeletedTime == null).ToList();
            return Task.FromResult((ICollection<ChiSoDongHoEntity>)entities);
        }

        public Task<ChiSoDongHoEntity> GetByKeyIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var entity = _chiSoDongHoRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return Task.FromResult(entity);
        }*/

        public ICollection<ChiSoDongHoEntity> GetAllAsync()
        {
            var entities = _chiSoDongHoRepository.Get(_ => _.DeletedTime == null).ToList();
            return (ICollection<ChiSoDongHoEntity>)entities;
        }

        public ChiSoDongHoEntity GetByKeyIdAsync(string id)
        {
            var entity = _chiSoDongHoRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return entity;
        }

        public Task UpdateAsync(string Id, ChiSoDongHoModel model, CancellationToken cancellationToken = default)
        {
            var entity = _chiSoDongHoRepository.GetTracking(x => x.KeyId == Id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsChiSoDongHo.CHI_SO_DONG_HO_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.KeyId != Id)
            {
                var isDuplicate = _chiSoDongHoRepository.GetTracking(x => x.KeyId == model.KeyId && x.DeletedTime == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsChiSoDongHo.CHI_SO_DONG_HO_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _chiSoDongHoRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }
    }
}
