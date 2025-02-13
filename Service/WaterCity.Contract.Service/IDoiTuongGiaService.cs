using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.DoiTuongGia;

namespace WaterCity.Contract.Service
{
     public interface IDoiTuongGiaService :
        Base.IGetable<DoiTuongGiaEntity, string>,
        Base.ICreateable<DoiTuongGiaModel, string>,
        Base.IUpdateable<DoiTuongGiaModel, string>,
        Base.IDeleteable<string, bool>
    {
    }
}
