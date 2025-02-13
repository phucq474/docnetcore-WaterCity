using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.PhamVi;

namespace WaterCity.Contract.Service
{
    
    public interface IPhamViService :
       Base.ICreateable<PhamViModel, string>,
       Base.IUpdateable<PhamViModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<PhamViEntity, string>
    {
    }
}
