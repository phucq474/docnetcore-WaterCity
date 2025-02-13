using AutoMapper;
using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.HangSanXuat;

namespace WaterCity.Mapper
{
    public class HangSanXuatProfile : Profile
    {
        public HangSanXuatProfile()
        {
            CreateMap<HangSanXuatModel, HangSanXuatEntity>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
