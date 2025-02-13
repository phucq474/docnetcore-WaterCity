using Invedia.DI.Attributes;
using WaterCity.Contract.Repository.Infrastructure;
using WaterCity.Contract.Repository.Interface;
using WaterCity.Contract.Repository.Models;
using WaterCity.Repository.Infrastructure;

namespace WaterCity.Repository
{
    [ScopedDependency(ServiceType = typeof(IKhachHangRepository))]
    public class KhachHangRepository : Repository<KhachHangEntity>, IKhachHangRepository
    {
        public KhachHangRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}

