namespace GearOps.Api.Configurations.App;

public static class AppConfig
{
    public static WebApplication ApplyConfiguration(this WebApplication app)
    {
        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseExceptionHandler(appError =>
        {

            appError.Run(async context =>
            {
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";

                var response = new { Message = "Erro interno no servidor. Tente novamente mais tarde." };
                await context.Response.WriteAsJsonAsync(response);
            });
        });

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHealthChecks("/v1/health");

        app.MapControllers();

        return app;
    }
}