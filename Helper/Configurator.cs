using Newtonsoft.Json;
using System.Reflection;


namespace TestRail.Helper
{
    public class Configurator
    {
        public static AppSettings ReadConfiguration()
        {
            var appSettingsPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "appsettings.json");
            var appSettingsReadFile = File.ReadAllText(appSettingsPath);

            return JsonConvert.DeserializeObject<AppSettings>(appSettingsReadFile) ?? throw new FileNotFoundException();
        }

    }
}
