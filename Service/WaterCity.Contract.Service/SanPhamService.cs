using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.SanPham;

namespace WaterCity.Contract.Service
{
    public interface ISanPhamService :
      Base.ICreateable<SanPhamModel, string>,
      Base.IUpdateable<SanPhamModel, string>,
      Base.IDeleteable<string, bool>,
      Base.IGetable<SanPhamEntity, string>
    {
    }
}
