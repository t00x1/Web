using DataAccess.ModelsDB;
using Grpc.Core;
using IdentityService.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using DomainGeneral;
using DomainIdentity;
using DataAccessGeneral;
using BusinessLogicIdentity;
using DataAccessIdentity;


using InfrastructureGeneral;

var builder = WebApplication.CreateBuilder(args);

// �������� ������� � ���������
builder.Services.AddGrpc();
builder.Services.AddLogging();

// ����������� IUserLogic ��� ������� (��������������, ��� � ��� ���� ��� ����������)
builder.Services.AddScoped<IUserLogic, UserLogic>();

// ����������� DbContext
builder.Services.AddDbContext<InspireoContext>(option =>
    option.UseSqlServer("Server=DESKTOP-3F0EBO4;Database=Inspireo;Trusted_Connection=True;TrustServerCertificate=True;"));



builder.Services.AddSingleton<SettingRead>();

// ����������� IRepositoryWrapper
builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

var app = builder.Build();

// ��������� ��������� HTTP-��������
app.MapGrpcService<AccountService>();

app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();