using Microsoft.Extensions.Configuration;

namespace PushDansMaster.WPF
{


    public class configAPI
    {

        public string getConfig()
        {
            //Get the configAPI configuration
            ConfigurationBuilder builder = new ConfigurationBuilder();
            IConfigurationRoot config = builder.AddJsonFile("appsettings.json", false, true).Build();

            return config.GetSection("APIURL:default").Value;
        }
    }
}
