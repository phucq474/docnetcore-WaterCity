using AutoMapper;
using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.ThongBao;

namespace WaterCity.Mapper
{
    public class ThongBaoProfile : Profile
    {
        public ThongBaoProfile()
        {
            CreateMap<ThongBaoModel, ThongBaoEntity>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
