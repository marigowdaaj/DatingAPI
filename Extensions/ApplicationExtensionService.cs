using DatingAPI.Data;
using DatingAPI.Interface;
using DatingAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace DatingAPI.Extensions
{
    public static class ApplicationExtensionService
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config) 
        {
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("DatingConnectionString"));
            });
            services.AddScoped<ITokenService, TokenService>(); 

            return services;
        }
    }
}
