using Microsoft.AspNetCore.Mvc;

namespace GearOps.Api.Configurations.Builder;

public static class BuilderConfig
{
    public static WebApplicationBuilder ApplyConfiguration(this WebApplicationBuilder builder)
    {
        builder.Services.AddSignalR();

        // Alterar para permitir o teste via ip privado ao rodar no docker-compose
        builder.Services.AddCors(options => options.AddPolicy("FrontendPolicy", policy => policy.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod().AllowCredentials()));

        builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

        if (builder.Environment.IsDevelopment())
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
        }

        builder.Services.AddHealthChecks();

        builder.Services.AddControllers();

        return builder;
    }
}