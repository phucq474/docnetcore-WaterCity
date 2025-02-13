using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.TheLoai;

namespace WaterCity.Mapper
{
    public class TheLoaiProfile : Profile
    {
        public TheLoaiProfile()
        {
            CreateMap<TheLoaiModel, TheLoaiEntity>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
