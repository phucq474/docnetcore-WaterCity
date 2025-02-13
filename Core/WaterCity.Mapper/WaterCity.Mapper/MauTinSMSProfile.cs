using AutoMapper;
using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.MauTinSMS;

namespace WaterCity.Mapper
{
    public class MauTinSMSProfile : Profile
    {
        public MauTinSMSProfile()
        {
            CreateMap<MauTinSMSModel, MauTinSMSEntity>().ReverseMap();
        }
    }
}
