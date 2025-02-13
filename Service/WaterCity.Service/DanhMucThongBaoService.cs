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
using WaterCity.Core.Models.DanhMucThongBao;

namespace WaterCity.Service
{
    [ScopedDependency(ServiceType = typeof(IDanhMucThongBaoService))]
    public class DanhMucThongBaoService : Base.Service, IDanhMucThongBaoService
    {

        private readonly IDanhMucThongBaoRepository _danhMucThongBaoRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public DanhMucThongBaoService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _danhMucThongBaoRepository = serviceProvider.GetRequiredService<IDanhMucThongBaoRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        /*public Task<ICollection<DanhMucThongBaoEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var entities = _danhMucThongBaoRepository.Get(_ => _.DeletedTime == null).ToList();
            return Task.FromResult((ICollection<DanhMucThongBaoEntity>)entities);
        }

        public Task<DanhMucThongBaoEntity> GetByKeyIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var entity = _danhMucThongBaoRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return Task.FromResult(entity);
        }*/

        public ICollection<DanhMucThongBaoEntity> GetAllAsync()
        {
            var entities = _danhMucThongBaoRepository.Get(_ => _.DeletedTime == null).ToList();
            return (ICollection<DanhMucThongBaoEntity>)entities;
        }

        public DanhMucThongBaoEntity GetByKeyIdAsync(string id)
        {
            var entity = _danhMucThongBaoRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return entity;

        }
        public Task<string> CreateAsync(DanhMucThongBaoModel model, CancellationToken cancellationToken = default)
        {
            if (_danhMucThongBaoRepository.Get(x => x.KeyId == model.KeyId && x.DeletedTime == null).Any())
            {
                _logger.Information(ErrorCode.NotFound, model.KeyId);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsDanhMucThongBao.DANH_MUC_THONG_BAO_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<DanhMucThongBaoEntity>(model);
            _danhMucThongBaoRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.Id);
        }

        public Task UpdateAsync(string Id, DanhMucThongBaoModel model, CancellationToken cancellationToken = default)
        {
            var entity = _danhMucThongBaoRepository.GetTracking(x => x.KeyId == Id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsDanhMucThongBao.DANH_MUC_THONG_BAO_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.KeyId != Id)
            {
                var isDuplicate = _danhMucThongBaoRepository.GetTracking(x => x.KeyId == model.KeyId && x.DeletedTime == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsDanhMucThongBao.DANH_MUC_THONG_BAO_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _danhMucThongBaoRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _danhMucThongBaoRepository.GetTracking(x => x.KeyId == id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsDanhMucThongBao.DANH_MUC_THONG_BAO_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _danhMucThongBaoRepository.Delete(entity, isPhysicalDelete: isPhysical);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }
    }
}
