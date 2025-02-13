
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
using WaterCity.Core.Models.NuocSanXuat;

namespace WaterCity.Service
{
    [ScopedDependency(ServiceType = typeof(INuocSanXuatService))]
    public class NuocSanXuatService : Base.Service, INuocSanXuatService
    {

        private readonly INuocSanXuatRepository _nuocSanXuatRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public NuocSanXuatService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _nuocSanXuatRepository = serviceProvider.GetRequiredService<INuocSanXuatRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(NuocSanXuatModel model, CancellationToken cancellationToken = default)
         {
            if (_nuocSanXuatRepository.Get(_ => _.KeyId == model.KeyId && _.DeletedTime == null).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.KeyId);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsNuocSanXuat.NUOCSANXUAT_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<NuocSanXuatEntity>(model);
            _nuocSanXuatRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.Id);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _nuocSanXuatRepository.GetTracking(x => x.KeyId == id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsNuocSanXuat.NUOCSANXUAT_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _nuocSanXuatRepository.Delete(entity, isPhysicalDelete: isPhysical);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<NuocSanXuatEntity> GetAllAsync()
        {
            var entities = _nuocSanXuatRepository.Get(_ => _.DeletedTime == null).ToList();
            return (ICollection<NuocSanXuatEntity>)entities;
        }

        public NuocSanXuatEntity GetByKeyIdAsync(string id)
        {
            var entity = _nuocSanXuatRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return entity;
        }

        public Task UpdateAsync(string Id, NuocSanXuatModel model, CancellationToken cancellationToken = default)
        {
            var entity = _nuocSanXuatRepository.GetTracking(x => x.KeyId == Id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsNuocSanXuat.NUOCSANXUAT_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.KeyId != Id)
            {
                var isDuplicate = _nuocSanXuatRepository.GetTracking(x => x.KeyId == model.KeyId && x.DeletedTime == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsNuocSanXuat.NUOCSANXUAT_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _nuocSanXuatRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }
    }
}
