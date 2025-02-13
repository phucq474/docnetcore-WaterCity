using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.Huyen;
using WaterCity.Core.Models.Tinh;

namespace WaterCity.Contract.Service
{
    
    public interface IHuyenService :
       Base.ICreateable<HuyenModel, string>,
       Base.IUpdateable<HuyenModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<HuyenEntity, string>
    {
    }
}
