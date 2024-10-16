using Microsoft.EntityFrameworkCore;
using DataAccess.ModelsDB;
using Registration.DataAccess.Wrapper;
using Registration.Domain.Interfaces.Wrapper;
using Registration.Domain.Interfaces.Service;
using Registration.BusinessLogic.Service;

var builder = WebApplication.CreateBuilder(args);

// Настройка CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin() // Позволяет любые источники
               .AllowAnyMethod() // Позволяет любые HTTP методы (GET, POST и т.д.)
               .AllowAnyHeader(); // Позволяет любые заголовки
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<InspireoContext>(option =>
    option.UseSqlServer("Server=DESKTOP-3F0EBO4;Database=Inspireo;Trusted_Connection=True;TrustServerCertificate=True;"));
builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
builder.Services.AddScoped<IUserService, UserLogic>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Включите CORS
app.UseCors("AllowAllOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();
