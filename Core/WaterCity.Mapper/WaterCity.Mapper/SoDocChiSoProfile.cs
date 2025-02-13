using AutoMapper;
using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.ChiSoDongHo;
using WaterCity.Core.Models.SoDocChiSo;

namespace WaterCity.Mapper
{
    public class SoDocChiSoProfile : Profile
    {
        public SoDocChiSoProfile()
        {
            CreateMap<SoDocChiSoEntity, SoDocChiSoModel>().ReverseMap();
        }
    }
}
