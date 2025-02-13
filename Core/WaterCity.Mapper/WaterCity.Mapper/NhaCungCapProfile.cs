using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.NhaCungCap;

namespace WaterCity.Mapper
{
    public class NhaCungCapProfile : Profile
    {
        public NhaCungCapProfile()
        {
            CreateMap<NhaCungCapModel, NhaCungCapEntity>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
