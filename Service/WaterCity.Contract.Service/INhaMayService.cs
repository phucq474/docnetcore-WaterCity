using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.NhaMay;

namespace WaterCity.Contract.Service
{
    public interface INhaMayService : 
        Base.ICreateable<NhaMayModel, string>, 
        Base.IUpdateable<NhaMayModel, string>, 
        Base.IGetable<NhaMayEntity, string>, 
        Base.IDeleteable<string, bool>
    {
        //<ICollection<NhaMayModel>> GetAllNhaMay();
        //Task<NhaMayEntity> GetNhaMayById(string Id);
        //Task<string> CreateNhaMay(NhaMayModel model, CancellationToken cancellationToken = default);
        // UpdateNhaMay(NhaMayModel model, CancellationToken cancellationToken = default);
        //Task DeleteNhaMay(string id, bool isPhysical = false, CancellationToken cancellationToken = default);
    }
}
