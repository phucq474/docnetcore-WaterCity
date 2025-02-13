using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.DonHang;

namespace WaterCity.Mapper
{
    public class DonHangProfile : Profile
    {
        public DonHangProfile()
        {
            CreateMap<DonHangModel, DonHangEntity>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
