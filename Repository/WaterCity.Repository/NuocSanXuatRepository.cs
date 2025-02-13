using Invedia.DI.Attributes;
using WaterCity.Contract.Repository.Infrastructure;
using WaterCity.Contract.Repository.Interface;
using WaterCity.Contract.Repository.Models;
using WaterCity.Repository.Infrastructure;

namespace WaterCity.Repository
{
    [ScopedDependency(ServiceType = typeof(INuocSanXuatRepository))]
    public class NuocSanXuatRepository : Repository<NuocSanXuatEntity>, INuocSanXuatRepository
    {
        public NuocSanXuatRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}

