using AutoMapper;
using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.NguoiDung;

namespace WaterCity.Mapper
{
    public class NguoiDungProfile : Profile
    {
        public NguoiDungProfile()
        {
            CreateMap<NguoiDungModel, NguoiDungEntity>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
