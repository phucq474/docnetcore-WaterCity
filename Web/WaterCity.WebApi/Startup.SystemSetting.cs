using WaterCity.Core.Configs;

namespace WaterCity.WebApi
{
    public static class StartupSystemSetting
    {
        public static IServiceCollection AddSystemSetting(this IServiceCollection services, SystemSettingModel systemSettingModel)
        {
            SystemSettingModel.Instance = systemSettingModel ?? new SystemSettingModel();

            return services;
        }
    }
}
