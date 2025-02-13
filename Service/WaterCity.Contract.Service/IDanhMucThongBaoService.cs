using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.DanhMucThongBao;

namespace WaterCity.Contract.Service
{
    public interface IDanhMucThongBaoService :
        Base.IGetable<DanhMucThongBaoEntity, string>,
        Base.ICreateable<DanhMucThongBaoModel, string>,
        Base.IUpdateable<DanhMucThongBaoModel, string>,
        Base.IDeleteable<string, bool>
    {
    }
}
