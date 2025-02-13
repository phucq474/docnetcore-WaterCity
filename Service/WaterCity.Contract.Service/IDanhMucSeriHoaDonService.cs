using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.DanhMucSeriHoaDon;

namespace WaterCity.Contract.Service
{
    public interface IDanhMucSeriHoaDonService :
        Base.IGetable<DanhMucSeriHoaDonEntity, string>,
        Base.ICreateable<DanhMucSeriHoaDonModel, string>,
        Base.IUpdateable<DanhMucSeriHoaDonModel, string>,
        Base.IDeleteable<string, bool>
    {
    }
}
