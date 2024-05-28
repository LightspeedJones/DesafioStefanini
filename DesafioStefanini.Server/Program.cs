using DesafioStefanini.Server.Context;
using DesafioStefanini.Server.Interface;
using DesafioStefanini.Server.Repositorios;
using DesafioStefanini.Server.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StefDbContext>(o => o.UseInMemoryDatabase("StefDb"));
//builder.Services.AddScoped<StefDbContext>();
builder.Services.AddScoped<IStefService, StefService>();
builder.Services.AddScoped<IPedidoRepositorio, PedidoRepositorio>();

var app = builder.Build();

using (var serviceScope = app.Services.CreateScope())
{
    StefDbContext.SeedData(serviceScope.ServiceProvider);
}

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
