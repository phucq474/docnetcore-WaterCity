using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.NhaCungCap;

namespace WaterCity.Contract.Service
{
    public interface INhaCungCapService :
      Base.ICreateable<NhaCungCapModel, string>,
      Base.IUpdateable<NhaCungCapModel, string>,
      Base.IDeleteable<string, bool>,
      Base.IGetable<NhaCungCapEntity, string>
    {
    }
}
