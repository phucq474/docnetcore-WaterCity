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
using WaterCity.Core.Models.DongHoNuoc;
using WaterCity.Core.Models.DongHoNuoc;

namespace WaterCity.Service
{
    [ScopedDependency(ServiceType = typeof(IDongHoNuocService))]
    public class DongHoNuocService : Base.Service, IDongHoNuocService
    {

        private readonly IDongHoNuocRepository _dongHoNuocRepository;
        private readonly IMapper _mapper;
        ILogger _logger;
        public DongHoNuocService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _dongHoNuocRepository = serviceProvider.GetRequiredService<IDongHoNuocRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(DongHoNuocModel model, CancellationToken cancellationToken = default)
        {
            if (_dongHoNuocRepository.Get(_ => _.KeyId == model.KeyId && _.DeletedTime == null).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.KeyId);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsDongHoNuoc.DONG_HO_NUOC_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<DongHoNuocEntity>(model);
            _dongHoNuocRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.Id);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _dongHoNuocRepository.GetTracking(x => x.KeyId == id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsDongHoNuoc.DONG_HO_NUOC_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _dongHoNuocRepository.Delete(entity, isPhysicalDelete: isPhysical);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        /*public Task<ICollection<DongHoNuocEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var entities = _dongHoNuocRepository.Get(_ => _.DeletedTime == null).ToList();
            return Task.FromResult((ICollection<DongHoNuocEntity>)entities);
        }

        public Task<DongHoNuocEntity> GetByKeyIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var entity = _dongHoNuocRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return Task.FromResult(entity);
        }*/

        public ICollection<DongHoNuocEntity> GetAllAsync()
        {
            var entities = _dongHoNuocRepository.Get(_ => _.DeletedTime == null).ToList();
            return (ICollection<DongHoNuocEntity>)entities;
        }

        public DongHoNuocEntity GetByKeyIdAsync(string id)
        {
            var entity = _dongHoNuocRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return entity;
        }

        public Task UpdateAsync(string Id, DongHoNuocModel model, CancellationToken cancellationToken = default)
        {
            var entity = _dongHoNuocRepository.GetTracking(x => x.KeyId == Id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsDongHoNuoc.DONG_HO_NUOC_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.KeyId != Id)
            {
                var isDuplicate = _dongHoNuocRepository.GetTracking(x => x.KeyId == model.KeyId && x.DeletedTime == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsDongHoNuoc.DONG_HO_NUOC_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _dongHoNuocRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }
    }
}
