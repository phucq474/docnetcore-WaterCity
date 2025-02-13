using AutoMapper;
using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.KyGhiChiSo;

namespace WaterCity.Mapper
{
    public class KyGhiChiSoProfile : Profile
    {
        public KyGhiChiSoProfile()
        {
            CreateMap<KyGhiChiSoEntity, KyGhiChiSoModel>().ReverseMap();
        }
    }
}
