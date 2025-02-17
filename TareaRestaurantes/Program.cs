using Microsoft.EntityFrameworkCore;
using TareaRestaurantes.Data;

var builder = WebApplication.CreateBuilder(args);

// Agregar el DbContext y configurar la cadena de conexión
builder.Services.AddDbContext<RestaurantesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Agregar servicios al contenedor.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar el pipeline de HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
