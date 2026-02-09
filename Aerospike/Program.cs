using Microsoft.Extensions.Options;
using AerospikeTest;


var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddOptions<AerospikeOptions>()
    .Bind(builder.Configuration.GetSection("Aerospike"))
    .Validate(o => o.Hosts.Count > 0, "Aerospike:Hosts must have at least one host.")
    .Validate(o => !string.IsNullOrWhiteSpace(o.Namespace), "Aerospike:Namespace is required.")
    .Validate(o => !string.IsNullOrWhiteSpace(o.Set), "Aerospike:Set is required.")
    .ValidateOnStart();

builder.Services.AddSingleton<AerospikeDb>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/health/aerospike", (AerospikeDb db) => Results.Ok(new { status = "ok" }));

// Create/Update
app.MapPut("/users/{id}", (string id, UpsertRequest req, AerospikeDb db) =>
{
    db.Put(id, req.Bins);
    return Results.Ok(new { id, upserted = true });
});

// Read
app.MapGet("/users/{id}", (string id, AerospikeDb db) =>
{
    var bins = db.Get(id);
    return bins is null ? Results.NotFound() : Results.Ok(new { id, bins });
});

// Delete
app.MapDelete("/users/{id}", (string id, AerospikeDb db) =>
{
    var existed = db.Delete(id);
    return Results.Ok(new { id, deleted = true, existed });
});

app.Run();

record UpsertRequest(Dictionary<string, object> Bins);