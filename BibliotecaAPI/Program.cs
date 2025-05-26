using BibliotecaAPI;
using BibliotecaAPI.Repositories;
using BibliotecaAPI.Services;
using Microsoft.EntityFrameworkCore;
using static BibliotecaAPI.Repositories.ILibroAutoresRepository;
using static BibliotecaAPI.Services.ILibroAutoresService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(ConnectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Repositories
builder.Services.AddScoped<IAutoresRepository, AutoresRepository>();
builder.Services.AddScoped<IBibliotecariosRepository, BibliotecariosRepository>();
builder.Services.AddScoped<IEditorialesRepository, EditorialesRepository>();
builder.Services.AddScoped<IEjemplaresRepository, EjemplaresRepository>();
builder.Services.AddScoped<ILectoresRepository, LectoresRepository>();
builder.Services.AddScoped<ILibroAutoresRepository, LibroAutoresRepository>();
builder.Services.AddScoped<ILibrosRepository, LibrosRepository>();
builder.Services.AddScoped<IPrestamosRepository, PrestamosRepository>();
builder.Services.AddScoped<IPersonasRepository, PersonasRepository>();
builder.Services.AddScoped<ITarifasRepository, TarifasRepository>();
#endregion

#region Services
builder.Services.AddScoped<IAutoresService, AutoresService>();
builder.Services.AddScoped<IBibliotecariosService, BibliotecariosService>();
builder.Services.AddScoped<IEditorialesService, EditorialesService>();
builder.Services.AddScoped<IEjemplaresService, EjemplaresService>();
builder.Services.AddScoped<ILectoresService, LectoresService>();
builder.Services.AddScoped<ILibroAutoresService, LibroAutoresService>();
builder.Services.AddScoped<ILibrosService, LibrosService>();
builder.Services.AddScoped<IPrestamosService, PrestamosService>();
builder.Services.AddScoped<IPersonasService, PersonasService>();
builder.Services.AddScoped<ITarifasService, TarifasService>();

#endregion

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
