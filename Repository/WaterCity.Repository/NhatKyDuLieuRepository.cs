using Invedia.DI.Attributes;
using WaterCity.Contract.Repository.Infrastructure;
using WaterCity.Contract.Repository.Interface;
using WaterCity.Contract.Repository.Models;
using WaterCity.Repository.Infrastructure;

namespace WaterCity.Repository
{
    [ScopedDependency(ServiceType = typeof(INhatKyDuLieuRepository))]
    public class NhatKyDuLieuRepository : Repository<NhatKyDuLieuEntity>, INhatKyDuLieuRepository
    {
        public NhatKyDuLieuRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}

