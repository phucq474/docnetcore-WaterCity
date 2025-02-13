using AutoMapper;
using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.Vung;

namespace WaterCity.Mapper
{
    public class VungProfile : Profile
    {
        public VungProfile()
        {
            CreateMap<VungModel, VungEntity>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}