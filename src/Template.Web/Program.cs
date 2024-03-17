using Template.Domain;
using Template.Application;
using Template.Infrastructure;
using FastEndpoints;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints();
builder.Services.SwaggerDocument();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly, typeof(ApplicationModule).Assembly));
builder.Services.AddSingleton(TimeProvider.System);

builder.Services
    .AddDomainModule()
    .AddApplicationModule()
    .AddInfrastructureModule();

var app = builder.Build();

app.UseFastEndpoints(e => e.Errors.UseProblemDetails());

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerGen();
}

app.Run();