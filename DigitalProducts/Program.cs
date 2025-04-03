using DigitalProducts.Infra.Repositories;
using DigitalProducts.Infra.Repositories.Interfaces;
using DigitalProducts.Application;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using DigitalProducts.Infra.Database;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")).LogTo(Console.WriteLine, LogLevel.Information);
;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserRepositories, UserRepository>();
builder.Services.AddInjectionApplication();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
