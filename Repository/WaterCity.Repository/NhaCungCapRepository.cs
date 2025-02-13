﻿using Invedia.DI.Attributes;
using WaterCity.Contract.Repository.Infrastructure;
using WaterCity.Contract.Repository.Interface;
using WaterCity.Contract.Repository.Models;
using WaterCity.Repository.Infrastructure;

namespace WaterCity.Repository
{
    [ScopedDependency(ServiceType = typeof(INhaCungCapRepository))]
    public class NhaCungCapRepository : Repository<NhaCungCapEntity>, INhaCungCapRepository
    {
        public NhaCungCapRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}

