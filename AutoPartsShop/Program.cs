using AutoPartsShop.Data;
using AutoPartsShop.Repositories;
using AutoPartsShop.Services;
using Microsoft.EntityFrameworkCore;
using AutoPartsShop.Enums;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AutoPartsShopDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

builder.Services.AddDbContext<AutoPartsShopDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        o => o.MapEnum<AddressType>("address_type")
              .MapEnum<DeliveryType>("delivery_type")
              .MapEnum<OrderStatus>("order_status")
              .MapEnum<PaymentStatus>("payment_status")
              .MapEnum<ShipmentStatus>("shipment_status")
              .MapEnum<StockMovementType>("stock_movement_type")
              .MapEnum<ReturnStatus>("return_status")
              .MapEnum<PartNumberType>("part_number_type")
              .MapEnum<FitmentType>("fitment_type")
    )
);

builder.Services.AddScoped<IBrandRepository, BrandRepository>();
builder.Services.AddScoped<IBrandService, BrandService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();