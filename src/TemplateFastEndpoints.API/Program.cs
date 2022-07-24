using System.Text.Json;
using TemplateFastEndpoints.API.Extensions;
using FastEndpoints.Swagger;
#if (UseCookieAuth)
using Microsoft.AspNetCore.Authentication.Cookies;
#endif

#if (UseSerilog)
using Serilog;
#endif

var builder = WebApplication.CreateBuilder(args);
#if (UseSerilog)

var logger = new LoggerConfiguration()
    .WriteTo.Console()
    .MinimumLevel.Information()
    .CreateLogger();

logger.Information("Starting up");

try
{
#endif

builder.WebHost.ConfigureKestrel(options =>
    {
        options.AddServerHeader = false;
        options.AllowSynchronousIO = false;
    });

#if (UseSerilog)
 if (builder.Environment.IsProduction())
    {
        builder.Logging.ClearProviders();
    }
    builder.Services.AddSingleton(logger);
#endif

builder.Host.UseConsoleLifetime(options => options.SuppressStatusMessages = true);


#if (UseCookieAuth)
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme);
#else
builder.Services.AddAuthentication();
#endif
builder.Services.AddAuthorization();

builder.Services.AddFastEndpoints(options =>
{
    options.SourceGeneratorDiscoveredTypes = DiscoveredTypes.All;
});

builder.Services.AddSwaggerDoc(addJWTBearerAuth: false);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDefaultExceptionHandler();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseFastEndpoints(options =>
{
    options.SerializerOptions = x => x.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    options.ErrorResponseStatusCode = StatusCodes.Status422UnprocessableEntity;
    options.ErrorResponseBuilder = (failures, _) => failures.ToResponse();
});

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi3(x => x.ConfigureDefaults());
}

await app.RunAsync();

#if (UseSerilog)
}
catch (Exception ex)
{
    logger.Fatal(ex, "Unhandled exception");
}
finally
{
    logger.Error("Shut down complete");
    Log.CloseAndFlush();
}
#endif
public partial class Program { }
