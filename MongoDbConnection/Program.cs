using Logger.Repositories;
using Logger.Services;
using Logger.Settings;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<MongoSettings>(builder.Configuration.GetSection("MongoSettings"));
builder.Services.AddSingleton<IMongoClient>(_ => new MongoClient(builder.Configuration["MongoSettings:ConnectionString"]));
builder.Services.AddScoped<ItemRepository>();
builder.Services.AddScoped<ItemService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();
