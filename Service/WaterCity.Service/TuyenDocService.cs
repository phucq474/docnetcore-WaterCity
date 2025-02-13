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
using WaterCity.Core.Models.TuyenDoc;
using WaterCity.Core.Utils;

namespace WaterCity.Service
{
    [ScopedDependency(ServiceType = typeof(ITuyenDocService))]
    public class TuyenDocService : Base.Service, ITuyenDocService
    {

        private readonly ITuyenDocRepository _tuyenDocRepository;
        /*private readonly IKhuVucRepository _khuVucRepository;*/
        private readonly IMapper _mapper;
        ILogger _logger;

        public TuyenDocService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _tuyenDocRepository = serviceProvider.GetRequiredService<ITuyenDocRepository>();
           /* _khuVucRepository = serviceProvider.GetRequiredService<IKhuVucRepository>();*/
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(TuyenDocModel model, CancellationToken cancellationToken = default)
        {
            if (_tuyenDocRepository.Get(_ => _.KeyId == model.KeyId && _.DeletedTime == null).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.KeyId);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsTuyenDoc.TUYEN_DOC_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<TuyenDocEntity>(model);
            _tuyenDocRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.Id);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _tuyenDocRepository.GetTracking(x => x.KeyId == id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsTuyenDoc.TUYEN_DOC_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _tuyenDocRepository.Delete(entity, isPhysicalDelete: isPhysical);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        /*public Task<ICollection<TuyenDocEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var entities = _tuyenDocRepository.Get(_ => _.DeletedTime == null).ToList();
            return Task.FromResult((ICollection<TuyenDocEntity>)entities);
        }

        public Task<TuyenDocEntity> GetByKeyIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var entity = _tuyenDocRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return Task.FromResult(entity);
        }*/

        public ICollection<TuyenDocEntity> GetAllAsync()
        {
            var entities = _tuyenDocRepository.Get(_ => _.DeletedTime == null).ToList();
            /*var entities = _tuyenDocRepository.Get(_ => _.DeletedTime == null)
                .Join(
                    _khuVucRepository.Get(_ => _.DeletedTime == null),
                    TuyenDoc => TuyenDoc.KhuVucId,
                    KhuVuc => KhuVuc.Id,
                    (TuyenDoc, KhuVuc) => new
                    {
                        TuyenDoc 
                    }
                ).ToList();*/

            return (ICollection<TuyenDocEntity>)entities;
        }

        public TuyenDocEntity GetByKeyIdAsync(string id)
        {
            var entity = _tuyenDocRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            
            return entity;
        }

        public Task UpdateAsync(string Id, TuyenDocModel model, CancellationToken cancellationToken = default)
        {
            var entity = _tuyenDocRepository.GetTracking(x => x.KeyId == Id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsTuyenDoc.TUYEN_DOC_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.KeyId != Id)
            {
                var isDuplicate = _tuyenDocRepository.GetTracking(x => x.KeyId == model.KeyId && x.DeletedTime == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsTuyenDoc.TUYEN_DOC_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _tuyenDocRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }
    }
}
