using EnergyDataService.Application;
using EnergyDataService.Infrastructure;
using Microsoft.AspNetCore.RateLimiting;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using Serilog;
using CorrelationId.DependencyInjection;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// ---------------------------
// Logging
// ---------------------------
builder.Host.UseSerilog((ctx, lc) =>
{
    lc.ReadFrom.Configuration(ctx.Configuration)
      .Enrich.FromLogContext()
      .WriteTo.Console();
});

// ---------------------------
// Services
// ---------------------------
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

// ---------------------------
// Observability (metrics only)
// ---------------------------
builder.Services.AddOpenTelemetry()
    .ConfigureResource(r => r.AddService("EnergyDataService"))
    .WithMetrics(m =>
    {
        m.AddAspNetCoreInstrumentation()
         .AddRuntimeInstrumentation()
         .AddPrometheusExporter();
    });

// ---------------------------
// Correlation ID
// ---------------------------
builder.Services.AddDefaultCorrelationId();

// ---------------------------
// Rate limiting (simple global)
// ---------------------------
builder.Services.AddRateLimiter(opts =>
{
    opts.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(_ =>
        RateLimitPartition.GetFixedWindowLimiter(
            "global",
            _ => new FixedWindowRateLimiterOptions
            {
                PermitLimit = 100,
                Window = TimeSpan.FromMinutes(1)
            }));
});

// ---------------------------
// Build app
// ---------------------------
var app = builder.Build();

// ---------------------------
// Middleware
// ---------------------------
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseRateLimiter();

app.MapControllers();
app.MapPrometheusScrapingEndpoint();

app.Run();
