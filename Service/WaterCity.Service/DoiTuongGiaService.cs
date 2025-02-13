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
using WaterCity.Core.Models.DoiTuongGia;
using WaterCity.Core.Models.DoiTuongGia;

namespace WaterCity.Service
{
    [ScopedDependency(ServiceType = typeof(IDoiTuongGiaService))]
    public class DoiTuongGiaService : Base.Service, IDoiTuongGiaService
    {

        private readonly IDoiTuongGiaRepository _doiTuongGiaRepository;
        private readonly IMapper _mapper;
        ILogger _logger;
        public DoiTuongGiaService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _doiTuongGiaRepository = serviceProvider.GetRequiredService<IDoiTuongGiaRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(DoiTuongGiaModel model, CancellationToken cancellationToken = default)
        {
            if (_doiTuongGiaRepository.Get(_ => _.KeyId == model.KeyId && _.DeletedTime == null).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.KeyId);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsDoiTuongGia.DOI_TUONG_GIA_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<DoiTuongGiaEntity>(model);
            _doiTuongGiaRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.Id);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _doiTuongGiaRepository.GetTracking(x => x.KeyId == id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsDoiTuongGia.DOI_TUONG_GIA_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _doiTuongGiaRepository.Delete(entity, isPhysicalDelete: isPhysical);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        /*public Task<ICollection<DoiTuongGiaEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var entities = _doiTuongGiaRepository.Get(_ => _.DeletedTime == null).ToList();
            return Task.FromResult((ICollection<DoiTuongGiaEntity>)entities);
        }

        public Task<DoiTuongGiaEntity> GetByKeyIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var entity = _doiTuongGiaRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return Task.FromResult(entity);
        }*/
        public ICollection<DoiTuongGiaEntity> GetAllAsync()
        {
            var entities = _doiTuongGiaRepository.Get(_ => _.DeletedTime == null).ToList();
            return (ICollection<DoiTuongGiaEntity>)entities;
        }

        public DoiTuongGiaEntity GetByKeyIdAsync(string id)
        {
            var entity = _doiTuongGiaRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return entity;
        }

        public Task UpdateAsync(string Id, DoiTuongGiaModel model, CancellationToken cancellationToken = default)
        {
            var entity = _doiTuongGiaRepository.GetTracking(x => x.KeyId == Id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsDoiTuongGia.DOI_TUONG_GIA_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.KeyId != Id)
            {
                var isDuplicate = _doiTuongGiaRepository.GetTracking(x => x.KeyId == model.KeyId && x.DeletedTime == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsDoiTuongGia.DOI_TUONG_GIA_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _doiTuongGiaRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }
    }
}
