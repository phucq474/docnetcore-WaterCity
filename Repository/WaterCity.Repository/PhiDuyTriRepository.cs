using Invedia.DI.Attributes;
using WaterCity.Contract.Repository.Infrastructure;
using WaterCity.Contract.Repository.Interface;
using WaterCity.Contract.Repository.Models;
using WaterCity.Repository.Infrastructure;

namespace WaterCity.Repository
{
    [ScopedDependency(ServiceType = typeof(IPhiDuyTriRepository))]
    public class PhiDuyTriRepository : Repository<PhiDuyTriEntity>, IPhiDuyTriRepository
    {
        public PhiDuyTriRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
