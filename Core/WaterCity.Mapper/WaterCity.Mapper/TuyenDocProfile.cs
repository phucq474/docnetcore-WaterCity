using AutoMapper;
using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.TuyenDoc;

namespace WaterCity.Mapper
{
    public class TuyenDocProfile : Profile
    {
        public TuyenDocProfile()
        {
            CreateMap<TuyenDocModel, TuyenDocEntity>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
