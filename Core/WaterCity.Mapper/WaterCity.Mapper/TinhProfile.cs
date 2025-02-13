using AutoMapper;
using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.Tinh;

namespace WaterCity.Mapper
{
    public class TinhProfile : Profile
    {
        public TinhProfile()
        {
            CreateMap<TinhModel, TinhEntity>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}