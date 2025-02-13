using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.KhachHang;

namespace WaterCity.Mapper
{
    public class KhachHangProfile : Profile
    {
        public KhachHangProfile()
        {
            CreateMap<KhachHangModel, KhachHangEntity>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
