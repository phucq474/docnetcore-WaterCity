using AutoMapper;
using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.DoiTuongGia;

namespace WaterCity.Mapper
{
    public class DoiTuongGiaProfile : Profile
    {
        public DoiTuongGiaProfile()
        {
            CreateMap<DoiTuongGiaModel, DoiTuongGiaEntity>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
