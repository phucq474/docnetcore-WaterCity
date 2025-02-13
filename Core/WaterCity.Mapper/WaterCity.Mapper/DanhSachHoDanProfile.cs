using AutoMapper;
using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.DanhSachHoDan;

namespace WaterCity.Mapper
{
    public class DanhSachHoDanProfile : Profile
    {
        public DanhSachHoDanProfile()
        {
            CreateMap<DanhSachHoDanModel, DanhSachHoDanEntity>().ReverseMap();
        }
    }
}
