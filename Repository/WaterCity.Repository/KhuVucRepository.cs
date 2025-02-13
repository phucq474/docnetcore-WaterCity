using Invedia.DI.Attributes;
using WaterCity.Contract.Repository.Infrastructure;
using WaterCity.Contract.Repository.Interface;
using WaterCity.Contract.Repository.Models;
using WaterCity.Repository.Infrastructure;

namespace WaterCity.Repository
{
    [ScopedDependency(ServiceType = typeof(IKhuVucRepository))]
    public class KhuVucRepository : Repository<KhuVucEntity>, IKhuVucRepository
    {
        public KhuVucRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}

