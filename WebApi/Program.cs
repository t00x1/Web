using businessLogic.Interfaces; 
using DataAccess.Models;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<Inspireo>(option =>
    option.UseSqlServer("Server=DESKTOP-3F0EBO4;Database=Pinterest;Trusted_Connection=True;TrustServerCertificate=True"));


builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Конфигурация HTTP запросов
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
