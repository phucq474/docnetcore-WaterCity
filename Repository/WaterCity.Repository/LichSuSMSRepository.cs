using Invedia.DI.Attributes;
using WaterCity.Contract.Repository.Infrastructure;
using WaterCity.Contract.Repository.Interface;
using WaterCity.Contract.Repository.Models;
using WaterCity.Repository.Infrastructure;

namespace WaterCity.Repository
{

    [ScopedDependency(ServiceType = typeof(ILichSuSMSRepository))]
    public class LichSuSMSRepository : Repository<LichSuSMSEntity>, ILichSuSMSRepository
    {
        public LichSuSMSRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}
