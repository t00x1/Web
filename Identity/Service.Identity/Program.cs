using DataAccess.ModelsDB;
using Grpc.Core;
using IdentityService.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using DomainGeneral;
using InfrastructureGeneral;
using DomainIdentity;
using DataAccessGeneral;
using BusinessLogicIdentity;
using DataAccessIdentity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();
builder.Services.AddLogging();

// Исправление регистрации зависимостей
builder.Services.AddSingleton<IStructFile, JSONFile>();
builder.Services.AddSingleton<IFileContent>(provider => new FileContentBuffer(1024));
builder.Services.AddSingleton<SettingRead>();
builder.Services.AddScoped<IUserLogic, UserLogic>();

// Регистрация DbContext
Console.WriteLine(builder.Configuration["ConnectionString"]);
builder.Services.AddDbContext<InspireoContext>(option =>
    option.UseSqlServer(builder.Configuration["ConnectionString"]));
builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<InspireoContext>();
    context.Database.Migrate();
}
app.MapGrpcService<AccountService>();

app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
