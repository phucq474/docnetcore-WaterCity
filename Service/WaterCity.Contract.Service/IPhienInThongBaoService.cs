using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.PhienInThongBao;

namespace WaterCity.Contract.Service
{
    public interface IPhienInThongBaoService :
       Base.IGetable<PhienInThongBaoEntity, string>,
       Base.ICreateable<PhienInThongBaoModel, string>,
       Base.IUpdateable<PhienInThongBaoModel, string>,
       Base.IDeleteable<string, bool>
    {
    }
}
