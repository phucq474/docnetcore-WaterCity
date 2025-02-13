using Invedia.DI.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using WaterCity.Contract.Repository.Infrastructure;
using WaterCity.Repository.Base;
using System.Reflection;
using WaterCity.Core.Utils;
using WaterCity.Core.Configs;

namespace WaterCity.Repository.Infrastructure
{
    [ScopedDependency(ServiceType = typeof(IDbContext))]
    public sealed partial class AppDbContext : BaseDbContext
    {
        public static readonly ILoggerFactory LoggerFactory = Microsoft.Extensions.Logging.LoggerFactory.Create(
            builder =>
            {
                builder
                    .AddFilter((category, level) =>
                        category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information)
                    .AddConsole();
            });

        public readonly int CommandTimeoutInSecond = 20 * 60;

        public AppDbContext()
        {
            Database.SetCommandTimeout(CommandTimeoutInSecond);
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.SetCommandTimeout(CommandTimeoutInSecond);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                /*  var configuration = new ConfigurationBuilder()
                      .SetBasePath(Directory.GetCurrentDirectory())
                      .AddJsonFile("appsettings.Development.json")
                      .Build();
                  var connectionString = configuration.GetConnectionString("DefaultConnection");*/

                var connectionString = SystemHelper.AppDb;
                connectionString = "Data Source=DESKTOP-1I0RUOA\\TRINHDB;Initial Catalog=QL_SPham;user=sa;pwd=123;Trusted_Connection=True;Trust Server Certificate=True; Integrated Security=false";

                optionsBuilder.UseSqlServer(connectionString, sqlServerOptionsAction =>
                {
                    sqlServerOptionsAction.MigrationsAssembly(
                        typeof(AppDbContext).GetTypeInfo().Assembly.GetName().Name);

                    sqlServerOptionsAction.MigrationsHistoryTable("Migration");
                });
                optionsBuilder.UseLoggerFactory(LoggerFactory);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
