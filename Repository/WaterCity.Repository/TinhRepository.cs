using Invedia.DI.Attributes;
using WaterCity.Contract.Repository.Infrastructure;
using WaterCity.Contract.Repository.Interface;
using WaterCity.Contract.Repository.Models;
using WaterCity.Repository.Infrastructure;

namespace WaterCity.Repository
{
    [ScopedDependency(ServiceType = typeof(ITinhRepository))]
    public class TinhRepository : Repository<TinhEntity>, ITinhRepository
    {
        public TinhRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}

