using GearOps.Api.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GearOps.Api.Configurations.Services;

public static class ServicesConfig
{
    public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

        return services;
    }
}