using AutoMapper;
using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.DanhSachDoiTuongGia;

namespace WaterCity.Mapper
{
    public class DanhSachDoiTuongGiaProfile : Profile
    {
        public DanhSachDoiTuongGiaProfile()
        {
            CreateMap<DanhSachDoiTuongGiaModel, DanhSachDoiTuongGiaEntity>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
