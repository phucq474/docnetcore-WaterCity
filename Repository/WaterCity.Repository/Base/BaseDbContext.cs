using Microsoft.EntityFrameworkCore;
using WaterCity.Contract.Repository.Infrastructure;

namespace WaterCity.Repository.Base
{
    public abstract class BaseDbContext : DbContext, IDbContext
    {
        protected BaseDbContext()
        {
            //Database.MigrateAsync(new CancellationToken()).Wait();
        }

        protected BaseDbContext(DbContextOptions options)
            : base(options)
        {
            //Database.MigrateAsync(new CancellationToken()).Wait();
        }
    }
}
