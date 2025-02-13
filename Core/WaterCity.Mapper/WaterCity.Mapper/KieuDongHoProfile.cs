using AutoMapper;
using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.KieuDongHo;

namespace WaterCity.Mapper
{
    public class KieuDongHoProfile : Profile
    {
        public KieuDongHoProfile()
        {
            CreateMap<KieuDongHoModel, KieuDongHoEntity>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}