using Invedia.DI.Attributes;
using WaterCity.Contract.Repository.Infrastructure;
using WaterCity.Contract.Repository.Interface;
using WaterCity.Contract.Repository.Models;
using WaterCity.Repository.Infrastructure;

namespace WaterCity.Repository
{
    [ScopedDependency(ServiceType = typeof(ITrangThaiGhiRepository))]
    public class TrangThaiGhiRepository : Repository<TrangThaiGhiEntity>, ITrangThaiGhiRepository
    {
        public TrangThaiGhiRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}

