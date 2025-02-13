using Invedia.DI.Attributes;
using WaterCity.Contract.Repository.Infrastructure;
using WaterCity.Contract.Repository.Interface;
using WaterCity.Contract.Repository.Models;
using WaterCity.Repository.Infrastructure;

namespace WaterCity.Repository
{
    [ScopedDependency(ServiceType = typeof(IHopDongRepository))]
    public class HopDongRepository : Repository<HopDongEntity>, IHopDongRepository
    {
        public HopDongRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}

