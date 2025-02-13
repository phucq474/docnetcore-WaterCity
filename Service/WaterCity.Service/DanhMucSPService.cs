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
using WaterCity.Core.Models.DanhMucSP;

namespace WaterCity.Service
{
    [ScopedDependency(ServiceType = typeof(IDanhMucSPService))]
    public class DanhMucSPService : Base.Service, IDanhMucSPService
    {

        private readonly IDanhMucSPRepository _DanhMucSPRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public DanhMucSPService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _DanhMucSPRepository = serviceProvider.GetRequiredService<IDanhMucSPRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        /*public Task<ICollection<DanhMucSPEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var entities = _DanhMucSPRepository.Get(_ => _.DeletedTime == null).ToList();
            return Task.FromResult((ICollection<DanhMucSPEntity>)entities);
        }

        public Task<DanhMucSPEntity> GetByKeyIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var entity = _DanhMucSPRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return Task.FromResult(entity);
        }*/

        public ICollection<DanhMucSPEntity> GetAllAsync()
        {
            var entities = _DanhMucSPRepository.Get(_ => _.DeletedTime == null).ToList();
            return (ICollection<DanhMucSPEntity>)entities;
        }

        public DanhMucSPEntity GetByKeyIdAsync(string id)
        {
            var entity = _DanhMucSPRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return entity;
        }

        public Task<string> CreateAsync(DanhMucSPModel model, CancellationToken cancellationToken = default)
        {
            if (_DanhMucSPRepository.Get(x => x.KeyId == model.KeyId && x.DeletedTime == null).Any())
            {
                _logger.Information(ErrorCode.NotFound, model.KeyId);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsDanhMucSP.DANHMUCSP_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<DanhMucSPEntity>(model);
            _DanhMucSPRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.Id);
        }

        public Task UpdateAsync(string Id, DanhMucSPModel model, CancellationToken cancellationToken = default)
        {
            var entity = _DanhMucSPRepository.GetTracking(x => x.KeyId == Id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsDanhMucSP.DANHMUCSP_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.KeyId != Id)
            {
                var isDuplicate = _DanhMucSPRepository.GetTracking(x => x.KeyId == model.KeyId && x.DeletedTime == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsDanhMucSP.DANHMUCSP_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _DanhMucSPRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _DanhMucSPRepository.GetTracking(x => x.KeyId == id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsDanhMucSP.DANHMUCSP_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _DanhMucSPRepository.Delete(entity, isPhysicalDelete: isPhysical);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }
    }
}
