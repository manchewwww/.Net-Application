var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<PartRepository>();
builder.Services.AddSingleton<PartService>();

var app = builder.Build();

app.MapPartEndpoints();

app.Run();
