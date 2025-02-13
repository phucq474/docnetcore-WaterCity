using Invedia.DI.Attributes;
using WaterCity.Contract.Repository.Infrastructure;
using WaterCity.Contract.Repository.Interface;
using WaterCity.Contract.Repository.Models;
using WaterCity.Repository.Infrastructure;

namespace WaterCity.Repository
{
    [ScopedDependency(ServiceType = typeof(INhaMayRepository))]
    public class NhaMayRepository : Repository<NhaMayEntity>, INhaMayRepository
    {
        public NhaMayRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}

