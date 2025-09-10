using Microsoft.EntityFrameworkCore;
using PruebaCRUD1.Models;
using PruebaCRUD1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ProductosService>(); //Por cada servicio que vayas a usar debes hacer esto

builder.Services.AddDbContext<PruebaTecnicaCrudContext>( opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("conexion"));
}
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
