
#region VungCu
/*using AutoMapper;
using Invedia.DI.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using WaterCity.Contract.Repository.Interface;
using WaterCity.Contract.Repository.Models;
using WaterCity.Contract.Service;
using WaterCity.Core.Constants;
using WaterCity.Core.Models.Vung;

namespace WaterCity.Service
{
    [ScopedDependency(ServiceType = typeof(IVungService))]
    public class VungService : Base.Service, IVungService
    {
        private readonly IVungRepository _vungRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public VungService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _vungRepository = serviceProvider.GetRequiredService<IVungRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        #region Create
        /// <summary>
        /// Base CreateAsync
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<string> CreateAsync(VungEntity model, CancellationToken cancellationToken = default)
        {
            var checkVung = GetVungById(model.Id);
            if (checkVung != null)
            {
                return await Task.FromResult(checkVung.Id);
            }

            _vungRepository.Add(model);
            await UnitOfWork.SaveChangeAsync();
            return await Task.FromResult(model.Id);
        }

        /// <summary>
        /// Create by VungModel
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<string> CreateVungAsync(VungModel model, CancellationToken cancellationToken = default)
        {
            var entity = _mapper.Map<VungEntity>(model);
            await CreateAsync(entity, cancellationToken);
            return await Task.FromResult(entity.Id);
        }
        #endregion Create

        #region Get Vung By Id
        /// <summary>
        /// Get Vung by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public VungEntity GetVungById(string Id)
        {
            return _vungRepository.GetSingle(_ => _.Id == Id && _.DeletedTime == null);
        }
        #endregion Get Vung By Id

        #region Get All Vung    
        /// <summary>
        /// Get all vung
        /// </summary>
        /// <returns></returns>
        public ICollection<VungModel> GetAllVung()
        {
            var entity = _vungRepository.Get(_ => _.DeletedTime == null).Include(x => x.KhuVuc).ToList();
            return _mapper.Map<ICollection<VungModel>>(entity);
        }
        #endregion Get All Vung

        #region Update
        /// <summary>
        /// Base Update
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task UpdateAsync(VungEntity model, CancellationToken cancellationToken = default)
        {
            try
            {
                _vungRepository.Update(model);
                UnitOfWork.SaveChange();
                return Task.CompletedTask;
            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message, model);
                return Task.FromException(e);
            }
        }

        /// <summary>
        /// Update Vung
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task UpdateVung(VungModel model, CancellationToken cancellationToken = default)
        {
            try
            {
                var entity = GetVungById(model.Id);
                if (entity != null)
                {
                    _mapper.Map(model, entity);
                    return UpdateAsync(entity, cancellationToken);
                }

                _logger.Information(ErrorCode.NotFound, model.Id);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message, model);
                return Task.FromException(ex);
            }
        }
        #endregion Update

        #region Delete Vung
        /// <summary>
        /// Delete Vung
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isPhysical"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task DeleteVung(string id, bool isPhysical = false, CancellationToken cancellationToken = default)
        {
            try
            {
                var entity = GetVungById(id);
                if (entity != null)
                {
                    _vungRepository.Delete(entity, isPhysical);
                    UnitOfWork.SaveChange();
                    return Task.CompletedTask;
                }

                _logger.Information(ErrorCode.NotFound, id);
                return Task.CompletedTask;

            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message, id);
                return Task.FromException(ex);
            }
        }

        public Task UpdateAsync(string key, VungEntity model, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
        #endregion Delete Vung
    }
}
// nhớ chăm ghi log nhiều zo nha mấy ba!*/
#endregion

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
using WaterCity.Core.Models.Vung;

namespace WaterCity.Service
{
    [ScopedDependency(ServiceType = typeof(IVungService))]
    public class VungService : Base.Service, IVungService
    {

        private readonly IVungRepository _vungRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public VungService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _vungRepository = serviceProvider.GetRequiredService<IVungRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(VungModel model, CancellationToken cancellationToken = default)
        {
            if (_vungRepository.Get(_ => _.KeyId == model.KeyId && _.DeletedTime == null).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.KeyId);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsVung.VUNG_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<VungEntity>(model);
            _vungRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.Id);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _vungRepository.GetTracking(x => x.KeyId == id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsVung.VUNG_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _vungRepository.Delete(entity, isPhysicalDelete: isPhysical);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        /*public Task<ICollection<VungEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var entities = _vungRepository.Get(_ => _.DeletedTime == null).ToList();
            return Task.FromResult((ICollection<VungEntity>)entities);
        }

        public Task<VungEntity> GetByKeyIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var entity = _vungRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return Task.FromResult(entity);
        }*/

        public ICollection<VungEntity> GetAllAsync()
        {
            var entities = _vungRepository.Get(_ => _.DeletedTime == null).ToList();
            return (ICollection<VungEntity>)entities;
        }

        public VungEntity GetByKeyIdAsync(string id)
        {
            var entity = _vungRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return entity;
        }

        public Task UpdateAsync(string Id, VungModel model, CancellationToken cancellationToken = default)
        {
            var entity = _vungRepository.GetTracking(x => x.KeyId == Id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsVung.VUNG_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.KeyId != Id)
            {
                var isDuplicate = _vungRepository.GetTracking(x => x.KeyId == model.KeyId && x.DeletedTime == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsVung.VUNG_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _vungRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }
    }
}
