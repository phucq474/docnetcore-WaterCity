using AutoMapper;
using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.SuCo;

namespace WaterCity.Mapper
{
    public class SuCoProfile : Profile
    {
        public SuCoProfile()
        {
            CreateMap<SuCoModel, SuCoEntity>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
