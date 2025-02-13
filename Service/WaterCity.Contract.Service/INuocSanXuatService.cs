using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.NuocSanXuat;

namespace WaterCity.Contract.Service
{
    
    public interface INuocSanXuatService :
       Base.ICreateable<NuocSanXuatModel, string>,
       Base.IUpdateable<NuocSanXuatModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<NuocSanXuatEntity, string>
    {
    }
}
