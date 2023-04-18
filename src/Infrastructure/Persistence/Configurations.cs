using Microsoft.Extensions.Configuration;


namespace Persistence
{
    public static class Configurations
    {
        //IConfiguration Configuration { get;}

        //public Configurations(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //    ConnectionString = Configuration.GetConnectionString("SqlServer");
        //}

        public static string ConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new ConfigurationManager();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/MovieStoreWebAPI"));
                configurationManager.AddJsonFile("appsettings.json");
                return configurationManager.GetConnectionString("SqlServer");
            }
        }
    }
}
