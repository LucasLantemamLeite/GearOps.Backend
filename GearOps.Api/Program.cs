using GearOps.Api.Configurations.App;
using GearOps.Api.Configurations.Builder;
using GearOps.Api.Configurations.Services;

var builder = WebApplication.CreateBuilder(args);

builder.ApplyConfiguration();

builder.Services.RegisterServices(builder.Configuration);

var app = builder.Build();

app.ApplyConfiguration();

app.Run();
