using AutoMapper;
using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.Xa;

namespace WaterCity.Mapper
{
    public class XaProfile : Profile
    {
        public XaProfile()
        {
            CreateMap<XaModel, XaEntity>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}