using Microsoft.Extensions.Configuration;
using System.IO;

namespace CoffeeShopPos.Helpers
{
    public class Helper
    {
        private static IConfiguration Configuration { get; set; }

        static Helper()
        {

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            Configuration = builder.Build();
        }

        public static string CnnVal(string name)
        {
            return Configuration.GetConnectionString(name);
        }
    }
}