using AutoMapper;
using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.NhaMay;

namespace WaterCity.Mapper
{
    public class NhaMayProfile : Profile
    {
        public NhaMayProfile()
        {
            CreateMap<NhaMayModel, NhaMayEntity>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
