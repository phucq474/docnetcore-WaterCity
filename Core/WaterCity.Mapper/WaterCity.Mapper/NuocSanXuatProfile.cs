using AutoMapper;
using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.NuocSanXuat;

namespace WaterCity.Mapper
{
    public class NuocSanXuatProfile : Profile
    {
        public NuocSanXuatProfile()
        {
            CreateMap<NuocSanXuatModel, NuocSanXuatEntity>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
