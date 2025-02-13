using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.Xa;

namespace WaterCity.Contract.Service
{
    
    public interface IXaService :
       Base.ICreateable<XaModel, string>,
       Base.IUpdateable<XaModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<XaEntity, string>
    {
    }
}
