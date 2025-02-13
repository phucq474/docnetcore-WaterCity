using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.NhatKyDuLieu;

namespace WaterCity.Contract.Service
{
    public interface INhatKyDuLieuService : 
        Base.ICreateable<NhatKyDuLieuModel, string>, 
        Base.IUpdateable<NhatKyDuLieuModel, string>, 
        Base.IDeleteable<string, bool>,
        Base.IGetable<NhatKyDuLieuEntity, string>
    {
       
    }
}
