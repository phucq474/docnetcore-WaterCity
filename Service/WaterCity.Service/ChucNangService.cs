using Invedia.DI.Attributes;
using Microsoft.Extensions.DependencyInjection;
using WaterCity.Contract.Repository.Interface;
using WaterCity.Contract.Service;

namespace WaterCity.Service
{
    [ScopedDependency(ServiceType = typeof(IChucNangService))]
    public class ChucNangService : Base.Service, IChucNangService
    {

        private readonly IChucNangRepository _chucNangRepository;
        public ChucNangService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _chucNangRepository = serviceProvider.GetRequiredService<IChucNangRepository>();
        }


    }
}
