using System.Configuration;
using System.Linq;

namespace NGnono.FMNote.WebSupport.Configs
{
    public class ConfigManager
    {
        public static string GetParamsValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        private static object GetParamsObjectValue(string key)
        {
            if (ConfigurationManager.AppSettings.AllKeys.Contains(key))
            {
                return GetParamsValue(key);
            }

            return null;
        }

        public static T GetParamsValueOrDefault<T>(string key, T defaultValue)
        {
            var t = GetParamsObjectValue(key);

            if (t == null)
            {
                return defaultValue;
            }

            return (T)t;
        }
    }
}
