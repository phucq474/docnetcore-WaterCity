using AutoMapper;
using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.ChiTietDonHang;

namespace WaterCity.Mapper
{
    public class ChiTietDonHangProfile : Profile
    {
        public ChiTietDonHangProfile()
        {
            CreateMap<ChiTietDonHangEntity, ChiTietDonHangModel>().ReverseMap();
        }
    }
}