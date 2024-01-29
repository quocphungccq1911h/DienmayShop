using DienmayShop.Application.PhungTest;
using DienmayShop.Data.EF;
using DienmayShop.Data.SystemHelpers.RabbitMQ;
using DienmayShop.Utilities.Constants;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// add DB
builder.Services.AddDbContext<DienmayShopDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString(SystemConstants.ConnectionString.DienmayShopDB)));

// Add DI
builder.Services.AddScoped<IPhungTestService, PhungTestService>();
builder.Services.AddScoped<IRabitMQProducer, RabitMQProducer>();


// add cache into Project
builder.Services.AddStackExchangeRedisCache(option =>
{
    option.Configuration = builder.Configuration.GetConnectionString(SystemConstants.ConnectionString.DienmayShop_Redis);
    option.InstanceName = "DienmayShop";
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureSwaggerGen(setup =>
{
    setup.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Điện máy Shop - Web API",
        Version = "v1"
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction()) 
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
