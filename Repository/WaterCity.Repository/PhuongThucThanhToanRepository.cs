using Invedia.DI.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterCity.Contract.Repository.Infrastructure;
using WaterCity.Contract.Repository.Interface;
using WaterCity.Contract.Repository.Models;
using WaterCity.Repository.Infrastructure;

namespace WaterCity.Repository
{
    [ScopedDependency(ServiceType = typeof(IPhuongThucThanhToanRepository))]
    public class PhuongThucThanhToanRepository : Repository<PhuongThucThanhToanEntity>, IPhuongThucThanhToanRepository
    {
        public PhuongThucThanhToanRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}
