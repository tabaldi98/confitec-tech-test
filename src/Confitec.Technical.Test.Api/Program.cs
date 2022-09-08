using Confitec.Technical.Test.Api.Extensions;
using Confitec.Technical.Test.Application.UserModule.UserCreate;
using FluentValidation.AspNetCore;
using MediatR;
using Serilog;

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.ConfigureLog();

    builder.AddCors();

    builder.Services.AddControllers()
        .AddFluentValidation(p => p.RegisterValidatorsFromAssemblyContaining<UserCreateCommandValidator>())
        .AddNewtonsoftJson();

    builder.Services.AddMediatR(typeof(UserCreateCommandHandler));

    builder.Services.AddVersioning();

    builder.AddJwtBearerAuthentication();

    builder.Services.AddSwagger();

    builder.Services.AddDependencies();

    builder.AddHealthCheck();

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }

    app.EnableSwagger();

    app.UseRouting();

    app.UseCustomCors();

    app.UseHealthChecks("/health-check");

    app.UseAuthentication();
    app.UseAuthorization();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });

    app.MigrationInitialisation();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.Information("Server Shutting down...");
    Log.CloseAndFlush();
}