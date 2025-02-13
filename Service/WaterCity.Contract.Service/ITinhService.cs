using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.Tinh;

namespace WaterCity.Contract.Service
{
    
    public interface ITinhService :
       Base.ICreateable<TinhModel, string>,
       Base.IUpdateable<TinhModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<TinhEntity, string>
    {
    }
}
