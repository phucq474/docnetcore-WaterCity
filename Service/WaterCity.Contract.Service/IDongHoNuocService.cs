using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.DongHoNuoc;

namespace WaterCity.Contract.Service
{
     public interface IDongHoNuocService :
       Base.ICreateable<DongHoNuocModel, string>,
       Base.IUpdateable<DongHoNuocModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<DongHoNuocEntity, string>
    {
    }
}
