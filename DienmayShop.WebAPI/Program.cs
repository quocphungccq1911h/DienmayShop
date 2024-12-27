using DienmayShop.Application.PhungTest;
using DienmayShop.Application.System.Users;
using DienmayShop.Configurations.ConfigAppSettings;
using DienmayShop.Configurations.Constants;
using DienmayShop.Data.EF;
using DienmayShop.Data.Entities;
using DienmayShop.Data.SystemHelpers.RabbitMQ;
using DienmayShop.Utilities.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;


//Here we specify the Rabbit MQ Server. we use rabbitmq docker image and use it
//var factory = new ConnectionFactory
//{
//    HostName = "localhost",
//};
////Create the RabbitMQ connection using connection factory details as i mentioned above
//var connection = factory.CreateConnection();
////Here we create channel with session and model
//using
//var channel = connection.CreateModel();
////declare the queue after mentioning name and a few property related to that
//channel.QueueDeclare("product", exclusive: false);
////Set Event object which listen message from chanel which is sent by producer
//var consumer = new EventingBasicConsumer(channel);
//consumer.Received += (model, eventArgs) => {
//    var body = eventArgs.Body.ToArray();
//    var message = Encoding.UTF8.GetString(body);
//    Console.WriteLine($"Product message received: {message}");
//};
////read the message
//channel.BasicConsume(queue: "product", autoAck: true, consumer: consumer);
//Console.ReadKey();

var builder = WebApplication.CreateBuilder(args);

// add DB
builder.Services.AddDbContext<DienmayShopDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString(SystemConstants.ConnectionString.DienmayShopDB)));

// Add DI
builder.Services.AddScoped<IPhungTestService, PhungTestService>();
builder.Services.AddScoped<IRabitMQProducer, RabitMQProducer>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<UserManager<AppUser>, UserManager<AppUser>>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<DienmayShopDbContext>().AddDefaultTokenProviders(); 


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

#region Set Config Variable
ConfigConstants.EnumEnvironment = ConfigureAppsettings.GetEnvironment();
ConfigConstants.TokenWithKey = builder.Configuration["Tokens:Key"];
ConfigConstants.TokenIssuer = builder.Configuration["Tokens:Issuer"];

#endregion

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
