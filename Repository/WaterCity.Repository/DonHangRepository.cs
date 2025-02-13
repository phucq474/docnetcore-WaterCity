using Invedia.DI.Attributes;
using WaterCity.Contract.Repository.Infrastructure;
using WaterCity.Contract.Repository.Interface;
using WaterCity.Contract.Repository.Models;
using WaterCity.Repository.Infrastructure;

namespace WaterCity.Repository
{
    [ScopedDependency(ServiceType = typeof(IDonHangRepository))]
    public class DonHangRepository : Repository<DonHangEntity>, IDonHangRepository
    {
        public DonHangRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}

