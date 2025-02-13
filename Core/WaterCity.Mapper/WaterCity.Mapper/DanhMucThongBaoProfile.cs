using AutoMapper;
using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.DanhMucThongBao;

namespace WaterCity.Mapper
{
    public class DanhMucThongBaoProfile : Profile
    {
        public DanhMucThongBaoProfile()
        {
            CreateMap<DanhMucThongBaoModel, DanhMucThongBaoEntity>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
