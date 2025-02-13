using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.PhiDuyTri;

namespace WaterCity.Contract.Service
{
    public interface IPhiDuyTriService :
        Base.IGetable<PhiDuyTriEntity, string>,
        Base.ICreateable<PhiDuyTriModel, string>,
        Base.IUpdateable<PhiDuyTriModel, string>,
        Base.IDeleteable<string, bool>
    {

    }
}
