using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.ThatThoat;

namespace WaterCity.Contract.Service
{
     public interface IThatThoatService :
       Base.ICreateable<ThatThoatModel, string>,
       Base.IUpdateable<ThatThoatModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<ThatThoatEntity, string>
    {
    }
}
