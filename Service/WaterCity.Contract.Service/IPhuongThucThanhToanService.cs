using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.PhuongThucThanhToan;

namespace WaterCity.Contract.Service
{
    public interface IPhuongThucThanhToanService :
        Base.IGetable<PhuongThucThanhToanEntity, string>,
        Base.ICreateable<PhuongThucThanhToanModel, string>,
        Base.IUpdateable<PhuongThucThanhToanModel, string>,
        Base.IDeleteable<string, bool>
    { 

    }
}
