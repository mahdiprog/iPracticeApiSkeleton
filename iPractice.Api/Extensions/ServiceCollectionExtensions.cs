using iPractice.Application.Services;
using iPractice.Domain.Repositories;
using iPractice.Infrastructure;
using iPractice.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace iPractice.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(configuration.GetConnectionString("Sqlite")));

            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IPsychologistRepository, PsychologistRepository>();

            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IPsychologistService, PsychologistService>();

            return services;
        }
    }
}
