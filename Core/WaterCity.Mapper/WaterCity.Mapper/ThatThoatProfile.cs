using AutoMapper;
using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.ThatThoat;

namespace WaterCity.Mapper
{
    public class ThatThoatProfile : Profile
    {
        public ThatThoatProfile()
        {
            CreateMap<ThatThoatModel, ThatThoatEntity>().ReverseMap();
        }
    }
}
