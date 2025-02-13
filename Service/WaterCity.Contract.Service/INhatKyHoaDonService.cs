using WaterCity.Contract.Repository.Models;
using WaterCity.Contract.Service.Base;
using WaterCity.Core.Models.NhatKyHoaDon;

namespace WaterCity.Contract.Service
{
    public interface INhatKyHoaDonService :
        IGetable<NhatKyHoaDonEntity, string>,
        ICreateable<NhatKyHoaDonModel, string>,
        IUpdateable<NhatKyHoaDonModel, string>,
        IDeleteable<string, bool>
    {

    }
}
