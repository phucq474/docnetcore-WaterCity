using AutoMapper;
using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.PhiDuyTri;

namespace WaterCity.Mapper
{
    public class PhiDuyTriProfile : Profile
    {
        public PhiDuyTriProfile()
        {
            CreateMap<PhiDuyTriModel, PhiDuyTriEntity>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
