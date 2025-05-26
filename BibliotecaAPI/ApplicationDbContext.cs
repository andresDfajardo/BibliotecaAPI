using Microsoft.EntityFrameworkCore;
using BibliotecaAPI.Models;
using BibliotecaAPI.DTO;

namespace BibliotecaAPI
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        {
            
        }
        public DbSet<AutoresModel> Autores { get; set; }
        public DbSet<BibliotecariosModel> Bibliotecarios { get; set; }
        public DbSet<EditorialesModel> Editoriales { get; set; }
        public DbSet<EjemplaresModel> Ejemplares { get; set;}
        public DbSet<LectoresModel> Lectores { get; set; }
        public DbSet<LibroAutoresModel> LibroAutores { get; set; }
        public DbSet<LibrosModel> Libros { get; set; }
        public DbSet<PersonasModel> Personas { get; set; }
        public DbSet<PrestamosModel> Prestamos { get; set; }
        public DbSet<TarifasModel> Tarifas { get; set; }
    }
}
