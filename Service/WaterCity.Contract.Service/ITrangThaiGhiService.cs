using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.TrangThaiGhi;
using WaterCity.Core.Models.TuyenDoc;

namespace WaterCity.Contract.Service
{
    public interface ITrangThaiGhiService :
       Base.ICreateable<TrangThaiGhiModel, string>,
       Base.IUpdateable<TrangThaiGhiModel, string>,
       Base.IGetable<TrangThaiGhiEntity, string>,
       Base.IDeleteable<string, bool>
    {
    }
}
