namespace GearOps.Api.Configurations.App;

public static class AppConfig
{
    public static WebApplication ApplyConfiguration(this WebApplication app)
    {

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHealthChecks("/v1/health");

        return app;
    }
}