using Microsoft.EntityFrameworkCore;
using HelloMotors.Data;
using HelloMotors.Repository;
using HelloMotors.Service;
using HelloMotors.Mappings;
using HelloMotors.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
});

builder.Services.AddScoped<VendedorRepository>();
builder.Services.AddScoped<ProprietarioRepository>();
builder.Services.AddScoped<VeiculoRepository>();
builder.Services.AddScoped<VendaRepository>();

builder.Services.AddScoped<VendedorService>();
builder.Services.AddScoped<ProprietarioService>();
builder.Services.AddScoped<VeiculoService>();
builder.Services.AddScoped<VendaService>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();
app.Run();
