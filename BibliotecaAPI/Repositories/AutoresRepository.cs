using BibliotecaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Repositories
{
    public interface IAutoresRepository
    {
        Task<List<AutoresModel>> GetAll();
        Task<AutoresModel> GetAutores(int id);
        Task<AutoresModel> CreateAutores(string nombre, string apellido, DateOnly fechaNacimiento, string nacionalidad);
        Task<AutoresModel> UpdateAutores(AutoresModel autoresModel);
        Task<AutoresModel> DeleteAutores(AutoresModel autoresModel);
    }
    public class AutoresRepository : IAutoresRepository
    {
        private readonly ApplicationDbContext _db;
        public AutoresRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<AutoresModel> CreateAutores(string nombre, string apellido, DateOnly fechaNacimiento, string nacionalidad)
        {
            AutoresModel newAutoresModel = new AutoresModel 
            {
                Nombre = nombre,
                Apellido = apellido,
                FechaNacimiento = fechaNacimiento,
                Nacionalidad = nacionalidad
            };
            await _db.Autores.AddAsync(newAutoresModel);
            _db.SaveChanges();
            return newAutoresModel;
        }

        public async Task<AutoresModel> DeleteAutores(AutoresModel autoresModel)
        {
            _db.Autores.Remove(autoresModel);
            await _db.SaveChangesAsync();
            return autoresModel;
        }

        public async Task<List<AutoresModel>> GetAll()
        {
            return await _db.Autores.ToListAsync();
        }

        public async Task<AutoresModel> GetAutores(int id)
        {
            return await _db.Autores.FirstOrDefaultAsync(a => a.IdAutor == id);
        }

        public async Task<AutoresModel> UpdateAutores(AutoresModel autoresModel)
        {
            _db.Autores.Update(autoresModel);
            await _db.SaveChangesAsync();
            return autoresModel;
        }

    }
}
