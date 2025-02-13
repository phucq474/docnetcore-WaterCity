using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.SoDocChiSo;

namespace WaterCity.Contract.Service
{
    public interface ISoDocChiSoService :
        Base.ICreateable<SoDocChiSoModel, string>,
        Base.IUpdateable<SoDocChiSoModel, string>,
        Base.IGetable<SoDocChiSoEntity, string>,
        Base.IDeleteable<string, bool>
    {

    }
}
