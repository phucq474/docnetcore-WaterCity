using AutoMapper;
using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.TrangThaiGhi;

namespace WaterCity.Mapper
{
    public class TrangThaiGhiProfile : Profile
    {
        public TrangThaiGhiProfile()
        {
            CreateMap<TrangThaiGhiEntity, TrangThaiGhiModel>().ReverseMap();
        }
    }
}
