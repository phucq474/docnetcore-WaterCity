using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.KhachHang;

namespace WaterCity.Contract.Service
{
     public interface IKhachHangService :
        Base.ICreateable<KhachHangModel, string>, 
        Base.IUpdateable<KhachHangModel, string>, 
        Base.IGetable<KhachHangEntity, string>, 
        Base.IDeleteable<string, bool>
    {
    }
}
