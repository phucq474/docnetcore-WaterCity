using Invedia.DI.Attributes;
using WaterCity.Contract.Repository.Infrastructure;
using WaterCity.Contract.Repository.Interface;
using WaterCity.Contract.Repository.Models;
using WaterCity.Repository.Infrastructure;

namespace WaterCity.Repository
{
    [ScopedDependency(ServiceType = typeof(ISanPhamRepository))]
    public class SanPhamRepository : Repository<SanPhamEntity>, ISanPhamRepository
    {
        public SanPhamRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}

