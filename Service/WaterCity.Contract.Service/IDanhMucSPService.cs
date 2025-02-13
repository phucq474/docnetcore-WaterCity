using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.DanhMucSP;

namespace WaterCity.Contract.Service
{
    public interface IDanhMucSPService :
        Base.IGetable<DanhMucSPEntity, string>,
        Base.ICreateable<DanhMucSPModel, string>,
        Base.IUpdateable<DanhMucSPModel, string>,
        Base.IDeleteable<string, bool>
    {
    }
}
