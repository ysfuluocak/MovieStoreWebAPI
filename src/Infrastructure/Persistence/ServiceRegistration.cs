using Application.Interfaces.Repositories.ActorRepository;
using Application.Interfaces.Repositories.CustomerRepository;
using Application.Interfaces.Repositories.DirectorRepository;
using Application.Interfaces.Repositories.GenreRepository;
using Application.Interfaces.Repositories.MovieRepository;
using Application.Interfaces.Repositories.OrderRepository;
using Application.Interfaces.Repositories.UserRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repositories.EntityFramework.ActorRepository;
using Persistence.Repositories.EntityFramework.CustomerRepository;
using Persistence.Repositories.EntityFramework.DirectorRepository;
using Persistence.Repositories.EntityFramework.GenreRepository;
using Persistence.Repositories.EntityFramework.MovieRepository;
using Persistence.Repositories.EntityFramework.OrderRepository;
using Persistence.Repositories.EntityFramework.UserRepository;

namespace Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceService(this IServiceCollection services)
        {
            services.AddDbContext<MovieStoreDbContext>(options => options.UseSqlServer(Configurations.ConnectionString));
            //services.AddDbContext<MovieStoreDbContext>();
            services.AddScoped<ICustomerReadRepository, EfCustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, EfCustomerWriteRepository>();

            services.AddScoped<IOrderReadRepository, EfOrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, EfOrderWriteRepository>();

            services.AddScoped<IGenreReadRepository, EfGenreReadRepository>();
            services.AddScoped<IGenreWriteRepository, EfGenreWriteRepository>();

            services.AddScoped<IActorReadRepository, EfActorReadRepository>();
            services.AddScoped<IActorWriteRepository, EfActorWriteRepository>();

            services.AddScoped<IDirectorReadRepository, EfDirectorReadRepository>();
            services.AddScoped<IDirectorWriteRepository, EfDirectorWriteRepository>();

            services.AddScoped<IMovieReadRepository, EfMovieReadRepository>();
            services.AddScoped<IMovieWriteRepository, EfMovieWriteRepository>();

            services.AddScoped<IUserReadRepository, EfUserReadRepository>();
            services.AddScoped<IUserWriteRepository, EfUserWriteRepository>();
        }
    }
}
