using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.SuCo;

namespace WaterCity.Contract.Service
{
     public interface ISuCoService :
       Base.ICreateable<SuCoModel, string>,
       Base.IUpdateable<SuCoModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<SuCoEntity, string>
    {
    }
}
