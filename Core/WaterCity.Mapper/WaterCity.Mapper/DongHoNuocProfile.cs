using AutoMapper;
using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.DongHoNuoc;

namespace WaterCity.Mapper
{
    public class DongHoNuocProfile : Profile
    {
        public DongHoNuocProfile()
        {
            CreateMap<DongHoNuocModel, DongHoNuocEntity>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
