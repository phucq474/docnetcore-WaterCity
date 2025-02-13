using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.ChiTietDonHang;

namespace WaterCity.Contract.Service
{
    public interface IChiTietDonHangService :
      Base.ICreateable<ChiTietDonHangModel, string>,
      Base.IUpdateable<ChiTietDonHangModel, string>,
      Base.IDeleteable<string, bool>,
      Base.IGetable<ChiTietDonHangEntity, string>
    {
    }
}
