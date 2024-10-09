using Microsoft.EntityFrameworkCore;
using DataAccess.ModelsDB;
using Domain.Interfaces.Wrapper;
using DataAccess.Wrapper;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
builder.Services.AddDbContext<InspireoContext>(option =>
    option.UseSqlServer("Server=DESKTOP-3F0EBO4;Database=Pinterest;Trusted_Connection=True;TrustServerCertificate=True"));
builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
