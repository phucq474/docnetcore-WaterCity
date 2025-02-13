using Invedia.DI.Attributes;
using WaterCity.Contract.Repository.Infrastructure;
using WaterCity.Contract.Repository.Interface;
using WaterCity.Contract.Repository.Models;
using WaterCity.Repository.Infrastructure;

namespace WaterCity.Repository
{
    [ScopedDependency(ServiceType = typeof(ITuyenDocRepository))]
    public class TuyenDocRepository : Repository<TuyenDocEntity>, ITuyenDocRepository
    {
        public TuyenDocRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}

