
using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.DongHoNuocSuCo;

namespace WaterCity.Contract.Service
{
     public interface IDongHoNuocSuCoService :
       Base.ICreateable<DongHoNuocSuCoModel, string>,
       Base.IUpdateable<DongHoNuocSuCoModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<DongHoNuocSuCoEntity, string>
    {
    }
}
