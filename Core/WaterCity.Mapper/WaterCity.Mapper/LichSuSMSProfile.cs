using AutoMapper;
using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.LichSuSMS;

namespace WaterCity.Mapper
{
    public class LichSuSMSProfile : Profile
    {
        public LichSuSMSProfile()
        {
            CreateMap<LichSuSMSModel, LichSuSMSEntity>().ReverseMap();
        }
    }
}
