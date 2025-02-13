using Invedia.DI.Attributes;
using WaterCity.Contract.Repository.Infrastructure;
using WaterCity.Contract.Repository.Interface;
using WaterCity.Contract.Repository.Models;
using WaterCity.Repository.Infrastructure;

namespace WaterCity.Repository
{
    [ScopedDependency(ServiceType = typeof(ISoDocChiSoRepository))]
    public class SoDocChiSoRepository : Repository<SoDocChiSoEntity>, ISoDocChiSoRepository
    {
        public SoDocChiSoRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}

