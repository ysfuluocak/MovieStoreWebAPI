using Microsoft.Extensions.Configuration;

namespace Persistence
{
    public class Configurations
    {
        IConfiguration Configuration { get;}

        public Configurations(IConfiguration configuration)
        {
            Configuration = configuration;
            ConnectionString = Configuration.GetConnectionString("SqlServer");
        }

        public static string ConnectionString;
    }
}
