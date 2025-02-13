using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.KieuDongHo;

namespace WaterCity.Contract.Service
{
    
    public interface IKieuDongHoService :
       Base.ICreateable<KieuDongHoModel, string>,
       Base.IUpdateable<KieuDongHoModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<KieuDongHoEntity, string>
    {
    }
}
