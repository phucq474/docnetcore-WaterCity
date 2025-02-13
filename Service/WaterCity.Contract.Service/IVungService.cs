using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.Vung;
using WaterCity.Core.Models.Vung;

namespace WaterCity.Contract.Service
{
    /*public interface IVungService :
        Base.ICreateable<VungEntity, string>,
        Base.IUpdateable<VungEntity, string>
    {
        ICollection<VungModel> GetAllVung();
        VungEntity GetVungById(string Id);
        Task<string> CreateVungAsync(VungModel model, CancellationToken cancellationToken = default);
        Task UpdateVung(VungModel model, CancellationToken cancellationToken = default);
        Task DeleteVung(string id, bool isPhysical = false, CancellationToken cancellationToken = default);

    }*/
    public interface IVungService :
       Base.ICreateable<VungModel, string>,
       Base.IUpdateable<VungModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<VungEntity, string>
    {
    }
}
