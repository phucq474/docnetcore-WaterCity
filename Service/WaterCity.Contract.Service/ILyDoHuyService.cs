using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.LyDoHuy;

namespace WaterCity.Contract.Service
{
    
    public interface ILyDoHuyService :
       Base.ICreateable<LyDoHuyModel, string>,
       Base.IUpdateable<LyDoHuyModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<LyDoHuyEntity, string>
    {
    }
}
