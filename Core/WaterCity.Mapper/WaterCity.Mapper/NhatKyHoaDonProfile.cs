using AutoMapper;
using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.NhatKyHoaDon;

namespace WaterCity.Mapper
{
    public class NhatKyHoaDonProfile : Profile
    {
        public NhatKyHoaDonProfile()
        {
            CreateMap<NhatKyHoaDonModel, NhatKyHoaDonEntity>().ReverseMap();
        }
    }
}
