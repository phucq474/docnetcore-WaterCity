using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.KhuVuc;
using AutoMapper;

namespace WaterCity.Mapper
{
    public class KhuVucProfile : Profile
    {
        public KhuVucProfile()
        {
            CreateMap<KhuVucModel, KhuVucEntity>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
