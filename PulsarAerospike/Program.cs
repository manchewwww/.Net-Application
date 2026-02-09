using PulsarAerospike;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOptions<PulsarOptions>()
    .Bind(builder.Configuration.GetSection("Pulsar"))
    .Validate(o => !string.IsNullOrWhiteSpace(o.ServiceUrl), "Pulsar:ServiceUrl required")
    .Validate(o => !string.IsNullOrWhiteSpace(o.Topic), "Pulsar:Topic required")
    .Validate(o => !string.IsNullOrWhiteSpace(o.Subscription), "Pulsar:Subscription required")
    .ValidateOnStart();

builder.Services.AddOptions<AerospikeOptions>()
    .Bind(builder.Configuration.GetSection("Aerospike"))
    .Validate(o => o.Hosts.Count > 0, "Aerospike:Hosts must have at least one host.")
    .Validate(o => !string.IsNullOrWhiteSpace(o.Namespace), "Aerospike:Namespace is required.")
    .Validate(o => !string.IsNullOrWhiteSpace(o.Set), "Aerospike:Set is required.")
    .ValidateOnStart();

builder.Services.AddSingleton<AerospikeDb>();
builder.Services.AddSingleton<PulsarProducer>();
builder.Services.AddHostedService<Worker>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.MapPost("/pulsar/publish", async (JsonElement body, PulsarProducer producer, CancellationToken ct) =>
{
    var json = body.GetRawText();
    await producer.SendJsonAsync(json, ct);
    return Results.Ok(new { published = true });
});

app.MapGet("/aerospike/{id}", (string id, AerospikeDb db) =>
{
    var bins = db.Get(id);
    return bins is null ? Results.NotFound() : Results.Ok(new { id, bins });
});

app.MapGet("/health", () => Results.Ok(new { ok = true }));

app.Run();

record PublishRequest(string Json);
