using AutoMapper;
using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.ChiTietHoaDon;

namespace WaterCity.Mapper
{
    public class ChiTietHoaDonProfile : Profile
    {
        public ChiTietHoaDonProfile()
        {
            CreateMap<ChiTietHoaDonModel, ChiTietHoaDonEntity>().ReverseMap();
        }
    }
}
