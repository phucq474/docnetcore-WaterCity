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
using WaterCity.Core.Models.DongHoNuocSuCo;
using WaterCity.Core.Models.DongHoNuocSuCo;

namespace WaterCity.Service
{
    [ScopedDependency(ServiceType = typeof(IDongHoNuocSuCoService))]
    public class DongHoNuocSuCoService : Base.Service, IDongHoNuocSuCoService
    {

        private readonly IDongHoNuocSuCoRepository _DongHoNuocSuCoRepository;
        private readonly IMapper _mapper;
        ILogger _logger;
        public DongHoNuocSuCoService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _DongHoNuocSuCoRepository = serviceProvider.GetRequiredService<IDongHoNuocSuCoRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(DongHoNuocSuCoModel model, CancellationToken cancellationToken = default)
        {
            if (_DongHoNuocSuCoRepository.Get(_ => _.KeyId == model.KeyId && _.DeletedTime == null).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.KeyId);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsDongHoNuocSuCo.DONG_HO_NUOC_SU_CO_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<DongHoNuocSuCoEntity>(model);
            _DongHoNuocSuCoRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.Id);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _DongHoNuocSuCoRepository.GetTracking(x => x.KeyId == id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsDongHoNuocSuCo.DONG_HO_NUOC_SU_CO_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _DongHoNuocSuCoRepository.Delete(entity, isPhysicalDelete: isPhysical);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        /*public Task<ICollection<DongHoNuocSuCoEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var entities = _DongHoNuocSuCoRepository.Get(_ => _.DeletedTime == null).ToList();
            return Task.FromResult((ICollection<DongHoNuocSuCoEntity>)entities);
        }

        public Task<DongHoNuocSuCoEntity> GetByKeyIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var entity = _DongHoNuocSuCoRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return Task.FromResult(entity);
        }*/

        public ICollection<DongHoNuocSuCoEntity> GetAllAsync()
        {
            var entities = _DongHoNuocSuCoRepository.Get(_ => _.DeletedTime == null).ToList();
            return (ICollection<DongHoNuocSuCoEntity>)entities;
        }

        public DongHoNuocSuCoEntity GetByKeyIdAsync(string id)
        {
            var entity = _DongHoNuocSuCoRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return entity;
        }

        public Task UpdateAsync(string Id, DongHoNuocSuCoModel model, CancellationToken cancellationToken = default)
        {
            var entity = _DongHoNuocSuCoRepository.GetTracking(x => x.KeyId == Id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsDongHoNuocSuCo.DONG_HO_NUOC_SU_CO_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.KeyId != Id)
            {
                var isDuplicate = _DongHoNuocSuCoRepository.GetTracking(x => x.KeyId == model.KeyId && x.DeletedTime == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsDongHoNuocSuCo.DONG_HO_NUOC_SU_CO_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _DongHoNuocSuCoRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }
    }
}
