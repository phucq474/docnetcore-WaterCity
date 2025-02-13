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
using WaterCity.Core.Models.ThatThoat;

namespace WaterCity.Service
{
    [ScopedDependency(ServiceType = typeof(IThatThoatService))]
    public class ThatThoatService : Base.Service, IThatThoatService
    {

        private readonly IThatThoatRepository _thatThoatRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public ThatThoatService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _thatThoatRepository = serviceProvider.GetRequiredService<IThatThoatRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(ThatThoatModel model, CancellationToken cancellationToken = default)
        {
            if (_thatThoatRepository.Get(_ => _.KeyId == model.KeyId && _.DeletedTime == null).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.KeyId);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsThatThoat.THAT_THOAT_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<ThatThoatEntity>(model);
            _thatThoatRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.Id);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _thatThoatRepository.GetTracking(x => x.KeyId == id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsThatThoat.THAT_THOAT_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _thatThoatRepository.Delete(entity, isPhysicalDelete: isPhysical);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        /*public Task<ICollection<ThatThoatEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var entities = _thatThoatRepository.Get(_ => _.DeletedTime == null).ToList();
            return Task.FromResult((ICollection<ThatThoatEntity>)entities);
        }

        public Task<ThatThoatEntity> GetByKeyIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var entity = _thatThoatRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return Task.FromResult(entity);
        }*/

        public ICollection<ThatThoatEntity> GetAllAsync()
        {
            var entities = _thatThoatRepository.Get(_ => _.DeletedTime == null).ToList();
            return (ICollection<ThatThoatEntity>)entities;
        }

        public ThatThoatEntity GetByKeyIdAsync(string id)
        {
            var entity = _thatThoatRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return entity;
        }

        public Task UpdateAsync(string Id, ThatThoatModel model, CancellationToken cancellationToken = default)
        {
            var entity = _thatThoatRepository.GetTracking(x => x.KeyId == Id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsThatThoat.THAT_THOAT_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.KeyId != Id)
            {
                var isDuplicate = _thatThoatRepository.GetTracking(x => x.KeyId == model.KeyId && x.DeletedTime == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsThatThoat.THAT_THOAT_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _thatThoatRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }
    }
}
