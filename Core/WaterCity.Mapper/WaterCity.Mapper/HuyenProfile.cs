using AutoMapper;
using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.Huyen;

namespace WaterCity.Mapper
{
    public class HuyenProfile : Profile
    {
        public HuyenProfile()
        {
            CreateMap<HuyenModel, HuyenEntity>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}