
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
using WaterCity.Core.Models.HangSanXuat;

namespace WaterCity.Service
{
    [ScopedDependency(ServiceType = typeof(IHangSanXuatService))]
    public class HangSanXuatService : Base.Service, IHangSanXuatService
    {

        private readonly IHangSanXuatRepository _hangSanXuatRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public HangSanXuatService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _hangSanXuatRepository = serviceProvider.GetRequiredService<IHangSanXuatRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(HangSanXuatModel model, CancellationToken cancellationToken = default)
         {
            if (_hangSanXuatRepository.Get(_ => _.KeyId == model.KeyId && _.DeletedTime == null).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.KeyId);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsHangSanXuat.HANGSANXUAT_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<HangSanXuatEntity>(model);
            _hangSanXuatRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.Id);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _hangSanXuatRepository.GetTracking(x => x.KeyId == id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsHangSanXuat.HANGSANXUAT_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _hangSanXuatRepository.Delete(entity, isPhysicalDelete: isPhysical);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<HangSanXuatEntity> GetAllAsync()
        {
            var entities = _hangSanXuatRepository.Get(_ => _.DeletedTime == null).ToList();
            return (ICollection<HangSanXuatEntity>)entities;
        }

        public HangSanXuatEntity GetByKeyIdAsync(string id)
        {
            var entity = _hangSanXuatRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return entity;
        }

        public Task UpdateAsync(string Id, HangSanXuatModel model, CancellationToken cancellationToken = default)
        {
            var entity = _hangSanXuatRepository.GetTracking(x => x.KeyId == Id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsHangSanXuat.HANGSANXUAT_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.KeyId != Id)
            {
                var isDuplicate = _hangSanXuatRepository.GetTracking(x => x.KeyId == model.KeyId && x.DeletedTime == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsHangSanXuat.HANGSANXUAT_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _hangSanXuatRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }
    }
}
