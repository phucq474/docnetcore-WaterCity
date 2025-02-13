using WaterCity.Contract.Repository.IBase;
using WaterCity.Contract.Repository.Models;

namespace WaterCity.Contract.Repository.Infrastructure
{
    public interface IRepository<T> : IBaseRepository<T> where T : Entity, new()
    {
    }
}
