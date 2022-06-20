using System.Text.Json;

using FastEndpointsAPI.Extensions;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
  options.AddServerHeader = false;
  options.AllowSynchronousIO = false;
});

builder.Services.AddAuthentication();
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

public partial class Program { }
