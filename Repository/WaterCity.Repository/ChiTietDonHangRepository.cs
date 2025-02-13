using Invedia.DI.Attributes;
using WaterCity.Contract.Repository.Infrastructure;
using WaterCity.Contract.Repository.Interface;
using WaterCity.Contract.Repository.Models;
using WaterCity.Repository.Infrastructure;

namespace WaterCity.Repository
{
    [ScopedDependency(ServiceType = typeof(IChiTietDonHangRepository))]
    public class ChiTietDonHangRepository : Repository<ChiTietDonHangEntity>, IChiTietDonHangRepository
    {
        public ChiTietDonHangRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}

