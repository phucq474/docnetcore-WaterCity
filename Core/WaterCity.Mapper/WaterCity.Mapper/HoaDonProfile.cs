using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.HoaDon;

namespace WaterCity.Mapper
{
    public class HoaDonProfile : Profile
    {
        public HoaDonProfile()
        {
            CreateMap<HoaDonModel, HoaDonEntity>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
