using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.DanhSachHoDan;

namespace WaterCity.Contract.Service
{
    public interface IDanhSachHoDanService :
        Base.IGetable<DanhSachHoDanEntity, string>,
        Base.ICreateable<DanhSachHoDanModel, string>,
        Base.IUpdateable<DanhSachHoDanModel, string>,
        Base.IDeleteable<string, bool>
    {
    }
}
