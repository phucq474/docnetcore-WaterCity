using WaterCity.Contract.Repository.Models;
using WaterCity.Contract.Service.Base;
using WaterCity.Core.Models.ChiTietHoaDon;

namespace WaterCity.Contract.Service
{
    public interface IChiTietHoaDonService :
        IGetable<ChiTietHoaDonEntity, string>,
        ICreateable<ChiTietHoaDonModel, string>,
        IUpdateable<ChiTietHoaDonModel, string>,
        IDeleteable<string, bool>
    {
    }
}
