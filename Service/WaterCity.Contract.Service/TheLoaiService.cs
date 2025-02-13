using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.TheLoai;

namespace WaterCity.Contract.Service
{
    public interface ITheLoaiService :
        Base.IGetable<TheLoaiEntity, string>,
        Base.ICreateable<TheLoaiModel, string>,
        Base.IUpdateable<TheLoaiModel, string>,
        Base.IDeleteable<string, bool>
    {
    }
}
