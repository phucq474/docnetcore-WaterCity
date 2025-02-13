using AutoMapper;
using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.NhatKyDuLieu;

namespace WaterCity.Mapper
{
    public class NhatKyDuLieuProfile : Profile
    {
        public NhatKyDuLieuProfile()
        {
            CreateMap<NhatKyDuLieuModel, NhatKyDuLieuEntity>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
