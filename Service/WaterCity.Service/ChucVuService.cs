using Invedia.DI.Attributes;
using Microsoft.Extensions.DependencyInjection;
using WaterCity.Contract.Repository.Interface;
using WaterCity.Contract.Service;

namespace WaterCity.Service
{
    [ScopedDependency(ServiceType = typeof(IChucVuService))]
    public class ChucVuService : Base.Service, IChucVuService
    {

        private readonly IChucVuRepository _chucVuRepository;
        public ChucVuService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _chucVuRepository = serviceProvider.GetRequiredService<IChucVuRepository>();
        }


    }
}
