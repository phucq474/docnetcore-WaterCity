using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.TuyenDoc;

namespace WaterCity.Contract.Service
{
    public interface ITuyenDocService :
       Base.ICreateable<TuyenDocModel, string>,
       Base.IUpdateable<TuyenDocModel, string>,
       Base.IGetable<TuyenDocEntity, string>,
       Base.IDeleteable<string, bool>
    {
    }
}
