﻿using AutoMapper;
using Invedia.DI.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using WaterCity.Contract.Repository.Interface;
using WaterCity.Contract.Repository.Models;
using WaterCity.Contract.Service;
using WaterCity.Core.Constants;
using WaterCity.Core.Exceptions;
using WaterCity.Core.Models.DonHang;

namespace WaterCity.Service
{
    [ScopedDependency(ServiceType = typeof(IDonHangService))]
    public class DonHangService : Base.Service, IDonHangService
    {

        private readonly IDonHangRepository _DonHangRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public DonHangService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _DonHangRepository = serviceProvider.GetRequiredService<IDonHangRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        /*public Task<ICollection<DonHangEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var entities = _DonHangRepository.Get(_ => _.DeletedTime == null).ToList();
            return Task.FromResult((ICollection<DonHangEntity>)entities);
        }

        public Task<DonHangEntity> GetByKeyIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var entity = _DonHangRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return Task.FromResult(entity);
        }*/

        public ICollection<DonHangEntity> GetAllAsync()
        {
            var entities = _DonHangRepository.Get(_ => _.DeletedTime == null).ToList();
            return (ICollection<DonHangEntity>)entities;
        }

        public DonHangEntity GetByKeyIdAsync(string id)
        {
            var entity = _DonHangRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return entity;
        }

        public Task<string> CreateAsync(DonHangModel model, CancellationToken cancellationToken = default)
        {
            if (_DonHangRepository.Get(x => x.KeyId == model.KeyId && x.DeletedTime == null).Any())
            {
                _logger.Information(ErrorCode.NotFound, model.KeyId);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsDonHang.DONHANG_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<DonHangEntity>(model);
            _DonHangRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.Id);
        }

        public Task UpdateAsync(string Id, DonHangModel model, CancellationToken cancellationToken = default)
        {
            var entity = _DonHangRepository.GetTracking(x => x.KeyId == Id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsDonHang.DONHANG_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.KeyId != Id)
            {
                var isDuplicate = _DonHangRepository.GetTracking(x => x.KeyId == model.KeyId && x.DeletedTime == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsDonHang.DONHANG_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _DonHangRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _DonHangRepository.GetTracking(x => x.KeyId == id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsDonHang.DONHANG_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _DonHangRepository.Delete(entity, isPhysicalDelete: isPhysical);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }
    }
}
