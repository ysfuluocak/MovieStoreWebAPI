using Application.Interfaces.Token;
using Infrastructure.Security.Jwt;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureService(this IServiceCollection services)
        {
            services.AddScoped<ITokenHelper, JwtHelper>();
        }
    }
}
