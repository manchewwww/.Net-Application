using Serilog;
using LoggerMetrics.Middleware;
using LoggerMetrics.Services;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((ctx, services, lc) =>
    lc.ReadFrom.Configuration(ctx.Configuration)
      .ReadFrom.Services(services)
      .Enrich.FromLogContext()
);

builder.Services.AddOpenTelemetry()
    .WithMetrics(m =>
    {
        m.SetResourceBuilder(
             ResourceBuilder.CreateDefault()
                 .AddService(serviceName: "LoggerMetrics"))
         .AddAspNetCoreInstrumentation()
         .AddRuntimeInstrumentation()
         .AddPrometheusExporter();
    });

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPartService,PartService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();
app.MapPrometheusScrapingEndpoint("/metrics");

app.MapControllers();
app.Run();
