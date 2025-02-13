using AutoMapper;
using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.LyDoHuy;

namespace WaterCity.Mapper
{
    public class LyDoHuyProfile : Profile
    {
        public LyDoHuyProfile()
        {
            CreateMap<LyDoHuyModel, LyDoHuyEntity>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
