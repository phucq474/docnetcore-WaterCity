using Invedia.DI.Attributes;
using WaterCity.Contract.Repository.Infrastructure;
using WaterCity.Contract.Repository.Interface;
using WaterCity.Contract.Repository.Models;
using WaterCity.Repository.Infrastructure;

namespace WaterCity.Repository
{
    [ScopedDependency(ServiceType = typeof(IThatThoatRepository))]
    public class ThatThoatRepository : Repository<ThatThoatEntity>, IThatThoatRepository
    {
        public ThatThoatRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}

