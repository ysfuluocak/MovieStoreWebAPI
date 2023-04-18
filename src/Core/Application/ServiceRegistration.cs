using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationService(this IServiceCollection services)
        {

            services.AddMediatR(options =>
            {
                options.RegisterServicesFromAssemblyContaining(typeof(ServiceRegistration));
            });
        }
    }
}
