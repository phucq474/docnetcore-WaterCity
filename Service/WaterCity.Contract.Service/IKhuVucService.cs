using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.KhuVuc;
using WaterCity.Core.Models.NhaMay;

namespace WaterCity.Contract.Service
{
    public interface IKhuVucService :
        Base.ICreateable<KhuVucModel, string>,
        Base.IUpdateable<KhuVucModel, string>,
        Base.IGetable<KhuVucEntity, string>,
        Base.IDeleteable<string, bool>
    {
    }
}
