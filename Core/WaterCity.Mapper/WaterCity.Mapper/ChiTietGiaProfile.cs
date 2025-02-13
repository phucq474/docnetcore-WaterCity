using AutoMapper;
using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.ChiTietGia;

namespace WaterCity.Mapper
{
    public class ChiTietGiaProfile : Profile
    {
        public ChiTietGiaProfile()
        {
            CreateMap<ChiTietGiaEntity, ChiTietGiaModel>().ReverseMap();
        }
    }
}
