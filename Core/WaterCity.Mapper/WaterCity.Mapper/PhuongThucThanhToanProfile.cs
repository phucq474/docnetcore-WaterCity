using AutoMapper;
using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.PhuongThucThanhToan;

namespace WaterCity.Mapper
{
    public class PhuongThucThanhToanProfile : Profile
    {
        public PhuongThucThanhToanProfile()
        {
            CreateMap<PhuongThucThanhToanModel, PhuongThucThanhToanEntity>().ReverseMap();
        }
    }
}
