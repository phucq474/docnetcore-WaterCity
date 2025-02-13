using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.ChiSoDongHo;

namespace WaterCity.Contract.Service
{
    public interface IChiSoDongHoService :
        Base.ICreateable<ChiSoDongHoModel, string>,
        Base.IUpdateable<ChiSoDongHoModel, string>,
        Base.IGetable<ChiSoDongHoEntity, string>,
        Base.IDeleteable<string, bool>
    {

    }
}
