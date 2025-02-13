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
using WaterCity.Core.Models.NguoiDung;

namespace WaterCity.Service
{
    [ScopedDependency(ServiceType = typeof(INguoiDungService))]
    public class NguoiDungService : Base.Service, INguoiDungService
    {

        private readonly INguoiDungRepository _nguoiDungRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public NguoiDungService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _nguoiDungRepository = serviceProvider.GetRequiredService<INguoiDungRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        /*public Task<ICollection<NguoiDungEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var entities = _nguoiDungRepository.Get(_ => _.DeletedTime == null).ToList();
            return Task.FromResult((ICollection<NguoiDungEntity>)entities);
        }

        public Task<NguoiDungEntity> GetByKeyIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var entity = _nguoiDungRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return Task.FromResult(entity);
        }*/

        public ICollection<NguoiDungEntity> GetAllAsync()
        {
            var entities = _nguoiDungRepository.Get(_ => _.DeletedTime == null).ToList();
            return (ICollection<NguoiDungEntity>)entities;
        }

        public NguoiDungEntity GetByKeyIdAsync(string id)
        {
            var entity = _nguoiDungRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return entity;
        }

        public Task<string> CreateAsync(NguoiDungModel model, CancellationToken cancellationToken = default)
        {
            if (_nguoiDungRepository.Get(x => x.KeyId == model.KeyId &&
                x.DeletedTime == null
                ).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.KeyId);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsNguoiDung.NGUOI_DUNG_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<NguoiDungEntity>(model);
            //Set tai khoan dang nhap
            entity.DangNhapId = model.KeyId;
            _nguoiDungRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.Id);
        }

        public Task UpdateAsync(string Id, NguoiDungModel model, CancellationToken cancellationToken = default)
        {
            var entity = _nguoiDungRepository.GetTracking(x => x.KeyId == Id &&
                x.DeletedTime == null
                ).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsNguoiDung.NGUOI_DUNG_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.KeyId != Id)
            {
                var isDuplicate = _nguoiDungRepository.GetTracking(x => x.KeyId == model.KeyId && x.DeletedTime == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsNguoiDung.NGUOI_DUNG_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            //set tai khoan dang nhap
            entity.DangNhapId = model.KeyId;
            _nguoiDungRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _nguoiDungRepository.GetTracking(x => x.KeyId == id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsNguoiDung.NGUOI_DUNG_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _nguoiDungRepository.Delete(entity, isPhysicalDelete: isPhysical);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }
    }
}
