using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.ThongBao;

namespace WaterCity.Contract.Service
{
    public interface IThongBaoService :
        Base.IGetable<ThongBaoEntity, string>,
        Base.ICreateable<ThongBaoModel, string>,
        Base.IUpdateable<ThongBaoModel, string>,
        Base.IDeleteable<string, bool>
    {
    }
}