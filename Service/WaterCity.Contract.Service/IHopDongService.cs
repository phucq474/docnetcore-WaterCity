using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.HopDong;

namespace WaterCity.Contract.Service
{
    public interface IHopDongService :
       Base.ICreateable<HopDongModel, string>,
       Base.IUpdateable<HopDongModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<HopDongEntity, string>
    {
        //public async HopDongEntity GetByIdAsync(string id); 
        public HopDongEntity GetByIdAsync(string id);
    }
}
