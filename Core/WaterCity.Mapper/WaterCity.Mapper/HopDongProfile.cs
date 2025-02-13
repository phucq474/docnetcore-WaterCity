using AutoMapper;
using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.HopDong;

namespace WaterCity.Mapper
{
    public class HopDongProfile : Profile
    {
        public HopDongProfile()
        {
            CreateMap<HopDongModel, HopDongEntity>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
