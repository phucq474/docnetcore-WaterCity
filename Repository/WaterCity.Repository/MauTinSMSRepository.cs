using Invedia.DI.Attributes;
using WaterCity.Contract.Repository.Infrastructure;
using WaterCity.Contract.Repository.Interface;
using WaterCity.Contract.Repository.Models;
using WaterCity.Repository.Infrastructure;

namespace WaterCity.Repository
{
    [ScopedDependency(ServiceType = typeof(IMauTinSMSRepository))]
    public class MauTinSMSRepository : Repository<MauTinSMSEntity>, IMauTinSMSRepository
    {
        public MauTinSMSRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}
