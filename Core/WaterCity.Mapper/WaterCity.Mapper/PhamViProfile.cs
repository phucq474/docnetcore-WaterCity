using AutoMapper;
using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.PhamVi;

namespace WaterCity.Mapper
{
    public class PhamViProfile : Profile
    {
        public PhamViProfile()
        {
            CreateMap<PhamViModel, PhamViEntity>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}