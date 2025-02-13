using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.NguoiDung;

namespace WaterCity.Contract.Service
{
    public interface INguoiDungService :
        Base.IGetable<NguoiDungEntity, string>,
        Base.ICreateable<NguoiDungModel, string>,
        Base.IUpdateable<NguoiDungModel, string>,
        Base.IDeleteable<string, bool>
    {
    }
}
