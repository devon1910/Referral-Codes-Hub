using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Referral_Codes_Hub.Application.Helper
{
    public class AppSettingsHelper
    {
        private static IConfiguration _config;
        public static void AppSettingsConfigure(IConfiguration configuration)
        {
            _config = configuration;
        }

        public static string Settings(string key)
        {
            return _config.GetSection(key).Value;
        }
    }
}
