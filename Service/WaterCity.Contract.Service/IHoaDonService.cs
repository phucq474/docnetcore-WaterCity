using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.HoaDon;

namespace WaterCity.Contract.Service
{
    public interface IHoaDonService :
        Base.IGetable<HoaDonEntity, string>,
        Base.ICreateable<HoaDonModel, string>,
        Base.IUpdateable<HoaDonModel, string>,
        Base.IDeleteable<string, bool>
    {
    }
}