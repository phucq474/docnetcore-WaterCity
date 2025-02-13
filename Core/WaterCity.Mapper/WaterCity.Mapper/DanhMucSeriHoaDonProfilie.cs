using AutoMapper;
using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.DanhMucSeriHoaDon;

namespace WaterCity.Mapper
{
    public class DanhMucSeriHoaDonProfile : Profile
    {
        public DanhMucSeriHoaDonProfile()
        {
            CreateMap<DanhMucSeriHoaDonModel, DanhMucSeriHoaDonEntity>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
