using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Text.Json;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHealthChecks();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapHealthChecks("health", new HealthCheckOptions
{
    ResponseWriter = (ctx, report) =>
    {
        ctx.Response.ContentType = "application/json; charset=utf-8";

        using var memoryStream = new MemoryStream();
        using (var jsonWriter = new Utf8JsonWriter(memoryStream))
        {
            jsonWriter.WriteStartObject();
            jsonWriter.WriteString("status", report.Status == HealthStatus.Healthy ? "OK" : "BAD");
            jsonWriter.WriteEndObject();
        }

        return ctx.Response.WriteAsync(
            Encoding.UTF8.GetString(memoryStream.ToArray()));
    }
});

app.MapControllers();

app.Run();
