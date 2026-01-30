using WebApplication1.Controllers;
using WebApplication1.Repositories;
using WebApplication1.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<PartRepository>();
builder.Services.AddSingleton<PartService>();

var app = builder.Build();

app.MapPartEndpoints();

app.Run();
