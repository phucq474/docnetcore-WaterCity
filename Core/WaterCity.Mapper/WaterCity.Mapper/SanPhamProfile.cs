using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.SanPham;

namespace WaterCity.Mapper
{
    public class SanPhamProfile : Profile
    {
        public SanPhamProfile()
        {
            CreateMap<SanPhamModel, SanPhamEntity>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
