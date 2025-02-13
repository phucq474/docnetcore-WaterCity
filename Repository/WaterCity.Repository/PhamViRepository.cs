using Invedia.DI.Attributes;
using WaterCity.Contract.Repository.Infrastructure;
using WaterCity.Contract.Repository.Interface;
using WaterCity.Contract.Repository.Models;
using WaterCity.Repository.Infrastructure;

namespace WaterCity.Repository
{
    [ScopedDependency(ServiceType = typeof(IPhamViRepository))]
    public class PhamViRepository : Repository<PhamViEntity>, IPhamViRepository
    {
        public PhamViRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}

