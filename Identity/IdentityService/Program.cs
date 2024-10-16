using DataAccess.ModelsDB;
using Grpc.Core;
using IdentityService.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Registration.BusinessLogic.Service;
using Registration.Domain.Interfaces.Service;
using Registration.Domain.Interfaces.Wrapper;
using Registration.DataAccess.Wrapper;
using InfrastructureGeneral.Settings;

var builder = WebApplication.CreateBuilder(args);

// Добавьте сервисы в контейнер
builder.Services.AddGrpc();
builder.Services.AddLogging();

// Регистрация IUserLogic как сервиса (предполагается, что у вас есть его реализация)
builder.Services.AddScoped<IUserLogic, UserLogic>();

// Регистрация DbContext
builder.Services.AddDbContext<InspireoContext>(option =>
    option.UseSqlServer("Server=DESKTOP-3F0EBO4;Database=Inspireo;Trusted_Connection=True;TrustServerCertificate=True;"));



builder.Services.AddSingleton<SettingRead>();

// Регистрация IRepositoryWrapper
builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

var app = builder.Build();

// Настройка конвейера HTTP-запросов
app.MapGrpcService<AccountService>();

app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();