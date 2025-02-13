using Invedia.DI.Attributes;
using WaterCity.Contract.Repository.Infrastructure;
using WaterCity.Contract.Repository.Interface;
using WaterCity.Contract.Repository.Models;
using WaterCity.Repository.Infrastructure;

namespace WaterCity.Repository
{
    [ScopedDependency(ServiceType = typeof(IDanhMucSPRepository))]
    public class DanhMucSPRepository : Repository<DanhMucSPEntity>, IDanhMucSPRepository
    {
        public DanhMucSPRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}

