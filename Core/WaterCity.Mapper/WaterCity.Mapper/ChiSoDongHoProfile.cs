using AutoMapper;
using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.ChiSoDongHo;

namespace WaterCity.Mapper
{
    public class ChiSoDongHoProfile : Profile
    {
        public ChiSoDongHoProfile()
        {
            CreateMap<ChiSoDongHoEntity, ChiSoDongHoModel>().ReverseMap();
        }
    }
}
