using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.LichSuSMS;

namespace WaterCity.Contract.Service
{
    public interface ILichSuSMSService :
        Base.IGetable<LichSuSMSEntity, string>,
        Base.ICreateable<LichSuSMSModel, string>,
        Base.IUpdateable<LichSuSMSModel, string>,
        Base.IDeleteable<string, bool>
    {

    }
}
