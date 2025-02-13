using Invedia.DI.Attributes;
using WaterCity.Contract.Repository.Infrastructure;
using WaterCity.Contract.Repository.Interface;
using WaterCity.Contract.Repository.Models;
using WaterCity.Repository.Infrastructure;

namespace WaterCity.Repository
{
    [ScopedDependency(ServiceType = typeof(IKieuDongHoRepository))]
    public class KieuDongHoRepository : Repository<KieuDongHoEntity>, IKieuDongHoRepository
    {
        public KieuDongHoRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}

