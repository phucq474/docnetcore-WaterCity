using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.DonHang;

namespace WaterCity.Contract.Service
{
    public interface IDonHangService :
      Base.ICreateable<DonHangModel, string>,
      Base.IUpdateable<DonHangModel, string>,
      Base.IDeleteable<string, bool>,
      Base.IGetable<DonHangEntity, string>
    {
    }
}
