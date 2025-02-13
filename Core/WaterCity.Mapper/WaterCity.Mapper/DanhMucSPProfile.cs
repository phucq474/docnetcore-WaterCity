using AutoMapper;
using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.DanhMucSP;

namespace WaterCity.Mapper
{
    public class DanhMucSPProfile : Profile
    {
        public DanhMucSPProfile()
        {
            CreateMap<DanhMucSPModel, DanhMucSPEntity>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
