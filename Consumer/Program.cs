using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Consumer.Data;
using Consumer.Messaging;
using Consumer.Repositories;
using Consumer.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Host.ConfigureAppConfiguration((ctx, cfg) =>
{
    cfg.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
});

builder.Services.AddLogging();
builder.Services.AddSingleton<MongoDbContext>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<OrderProcessingService>();
builder.Services.AddHostedService<RabbitMqConsumer>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
