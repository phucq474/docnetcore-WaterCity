using Invedia.DI.Attributes;
using WaterCity.Contract.Repository.Infrastructure;
using WaterCity.Contract.Repository.Interface;
using WaterCity.Contract.Repository.Models;
using WaterCity.Repository.Infrastructure;

namespace WaterCity.Repository
{
    [ScopedDependency(ServiceType = typeof(IPhienInThongBaoRepository))]
    public class PhienInThongBaoRepository : Repository<PhienInThongBaoEntity>, IPhienInThongBaoRepository
    {
        public PhienInThongBaoRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}

