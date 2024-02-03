using DienmayShop.Configurations.Enums;

namespace DienmayShop.Configurations.Constants
{
    public static class ConfigConstants
    {
        public static EnumEnvironment EnumEnvironment { get; set; }
        public static bool IsLocal
        {
            get
            {
                return EnumEnvironment == EnumEnvironment.Local; 
            }
        }
        public static bool IsProduction
        {
            get
            {
                return EnumEnvironment == EnumEnvironment.Production;
            }
        }
        public static bool Development
        {
            get
            {
                return EnumEnvironment != EnumEnvironment.Production;
            }
        }
        public static string TokenWithKey { get; set; } = string.Empty;
        public static string TokenIssuer { get; set; } = string.Empty;
    }
}
