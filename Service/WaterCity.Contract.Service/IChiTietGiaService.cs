using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.ChiTietGia;

namespace WaterCity.Contract.Service
{
    public interface IChiTietGiaService :
        Base.ICreateable<ChiTietGiaModel, string>,
        Base.IUpdateable<ChiTietGiaModel, string>,
        Base.IGetable<ChiTietGiaEntity, string>,
        Base.IDeleteable<string, bool>
    {
    }
}
