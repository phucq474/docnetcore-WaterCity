using WaterCity.Contract.Repository.IBase;
using WaterCity.Contract.Repository.Infrastructure;
using WaterCity.Contract.Repository.Models;
using WaterCity.Repository.Base;

namespace WaterCity.Repository.Infrastructure
{
    public abstract class Repository<T> : BaseRepository<T>, IRepository<T> ,IBaseRepository<T> where T : Entity, new()
    {
        public Repository(IDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}
