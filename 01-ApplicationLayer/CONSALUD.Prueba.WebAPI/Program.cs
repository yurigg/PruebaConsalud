using CONSALUD.Prueba.WebAPI.AccessAuthorization;
using CONSALUD.Prueba.WebAPI.Domain;
using CONSALUD.Prueba.WebAPI.DTO;
using CONSALUD.Prueba.WebAPI.Infraestructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<FacturasService, FacturasService>();

builder.Services.AddScoped<FacturasDao, FacturasDao>();

builder.Services.AddScoped<ApiKeyAuthFilter, ApiKeyAuthFilter>();


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
