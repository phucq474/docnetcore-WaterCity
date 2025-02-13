using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.MauTinSMS;

namespace WaterCity.Contract.Service
{
    public interface IMauTinSMSService :
        Base.IGetable<MauTinSMSEntity, string>,
        Base.ICreateable<MauTinSMSModel, string>,
        Base.IUpdateable<MauTinSMSModel, string>,
        Base.IDeleteable<string, bool>
    {

    }
}
