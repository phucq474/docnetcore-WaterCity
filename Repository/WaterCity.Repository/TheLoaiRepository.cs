using Invedia.DI.Attributes;
using WaterCity.Contract.Repository.Infrastructure;
using WaterCity.Contract.Repository.Interface;
using WaterCity.Contract.Repository.Models;
using WaterCity.Repository.Infrastructure;

namespace WaterCity.Repository
{
    [ScopedDependency(ServiceType = typeof(ITheLoaiRepository))]
    public class TheLoaiRepository : Repository<TheLoaiEntity>, ITheLoaiRepository
    {
        public TheLoaiRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}

