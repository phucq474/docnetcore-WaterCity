using AutoMapper;
using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.DongHoNuocSuCo;

namespace WaterCity.Mapper
{
    public class DongHoNuocSuCoProfile : Profile
    {
        public DongHoNuocSuCoProfile()
        {
            CreateMap<DongHoNuocSuCoModel, DongHoNuocSuCoEntity>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
