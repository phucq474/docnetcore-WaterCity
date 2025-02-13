using Invedia.DI.Attributes;
using WaterCity.Contract.Repository.Infrastructure;
using WaterCity.Contract.Repository.Interface;
using WaterCity.Contract.Repository.Models;
using WaterCity.Repository.Infrastructure;

namespace WaterCity.Repository
{
    [ScopedDependency(ServiceType = typeof(IHuyenRepository))]
    public class HuyenRepository : Repository<HuyenEntity>, IHuyenRepository
    {
        public HuyenRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}

