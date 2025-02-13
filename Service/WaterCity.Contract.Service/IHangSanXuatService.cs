using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.HangSanXuat;

namespace WaterCity.Contract.Service
{
    
    public interface IHangSanXuatService :
       Base.ICreateable<HangSanXuatModel, string>,
       Base.IUpdateable<HangSanXuatModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<HangSanXuatEntity, string>
    {
    }
}
