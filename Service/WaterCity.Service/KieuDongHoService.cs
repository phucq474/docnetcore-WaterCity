
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
using WaterCity.Core.Models.KieuDongHo;

namespace WaterCity.Service
{
    [ScopedDependency(ServiceType = typeof(IKieuDongHoService))]
    public class KieuDongHoService : Base.Service, IKieuDongHoService
    {

        private readonly IKieuDongHoRepository _kieuDongHoRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public KieuDongHoService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _kieuDongHoRepository = serviceProvider.GetRequiredService<IKieuDongHoRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(KieuDongHoModel model, CancellationToken cancellationToken = default)
         {
            if (_kieuDongHoRepository.Get(_ => _.KeyId == model.KeyId && _.DeletedTime == null).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.KeyId);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsKieuDongHo.KIEUDONGHO_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<KieuDongHoEntity>(model);
            _kieuDongHoRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.Id);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _kieuDongHoRepository.GetTracking(x => x.KeyId == id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsKieuDongHo.KIEUDONGHO_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _kieuDongHoRepository.Delete(entity, isPhysicalDelete: isPhysical);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<KieuDongHoEntity> GetAllAsync()
        {
            var entities = _kieuDongHoRepository.Get(_ => _.DeletedTime == null).ToList();
            return (ICollection<KieuDongHoEntity>)entities;
        }

        public KieuDongHoEntity GetByKeyIdAsync(string id)
        {
            var entity = _kieuDongHoRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return entity;
        }

        public Task UpdateAsync(string Id, KieuDongHoModel model, CancellationToken cancellationToken = default)
        {
            var entity = _kieuDongHoRepository.GetTracking(x => x.KeyId == Id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsKieuDongHo.KIEUDONGHO_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.KeyId != Id)
            {
                var isDuplicate = _kieuDongHoRepository.GetTracking(x => x.KeyId == model.KeyId && x.DeletedTime == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsKieuDongHo.KIEUDONGHO_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _kieuDongHoRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }
    }
}
