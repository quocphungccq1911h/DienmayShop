using DienmayShop.Configurations.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
