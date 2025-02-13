using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.KyGhiChiSo;

namespace WaterCity.Contract.Service
{
    public interface IKyGhiChiSoService :
        Base.ICreateable<KyGhiChiSoModel, string>,
        Base.IUpdateable<KyGhiChiSoModel, string>,
        Base.IGetable<KyGhiChiSoEntity, string>,
        Base.IDeleteable<string, bool>
    {
    }
}
