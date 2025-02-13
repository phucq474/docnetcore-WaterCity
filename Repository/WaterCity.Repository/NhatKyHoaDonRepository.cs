using Invedia.DI.Attributes;
using WaterCity.Contract.Repository.Infrastructure;
using WaterCity.Contract.Repository.Interface;
using WaterCity.Contract.Repository.Models;
using WaterCity.Repository.Infrastructure;

namespace WaterCity.Repository
{
    [ScopedDependency(ServiceType = typeof(INhatKyHoaDonRepository))]
    public class NhatKyHoaDonRepository : Repository<NhatKyHoaDonEntity>, INhatKyHoaDonRepository
    {
        public NhatKyHoaDonRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}

