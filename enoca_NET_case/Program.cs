using enoca_NET_case.Data;
using enoca_NET_case.Repositories;
using enoca_NET_case.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ICarrierRepository, CarrierRepository>();
builder.Services.AddScoped<ICarrierService, CarrierService>();
builder.Services.AddScoped<ICarrierConfigurationRepository, CarrierConfigurationRepository>();
builder.Services.AddScoped<ICarrierConfigurationService, CarrierConfigurationService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
