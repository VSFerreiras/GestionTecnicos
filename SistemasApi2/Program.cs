using GestionTecnicos.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext
var ConStr = builder.Configuration.GetConnectionString("SqlConStr");
builder.Services.AddDbContextFactory<Contexto>(o => o.UseSqlServer(ConStr));

// Add controllers
builder.Services.AddControllers();

// Optional: Add Swagger if you want to test easily
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();