using AutoMapper;
using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.PhienInThongBao;

namespace WaterCity.Mapper
{
    public class PhienInThongBaoProfile : Profile
    {
        public PhienInThongBaoProfile()
        {
            CreateMap<PhienInThongBaoModel, PhienInThongBaoEntity>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
