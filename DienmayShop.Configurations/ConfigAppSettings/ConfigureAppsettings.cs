using DienmayShop.Configurations.Constants;
using DienmayShop.Configurations.Enums;

namespace DienmayShop.Configurations.ConfigAppSettings
{
    public static class ConfigureAppsettings
    {
        public static EnumEnvironment GetEnvironment()
        {
            switch(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"))
            {
                case "Local":
                    return EnumEnvironment.Local;
                case "Development":
                    return EnumEnvironment.Beta;
                case "Staging":
                    return EnumEnvironment.Staging;
                case "Production":
                    return EnumEnvironment.Production;
                default: return EnumEnvironment.Production;
            }
        }
        public static void AddConfigAppSettings()
        {
            ConfigConstants.EnumEnvironment = GetEnvironment();
        }
    }
    
}
