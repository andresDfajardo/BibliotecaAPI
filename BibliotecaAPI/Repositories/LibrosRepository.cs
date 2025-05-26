using BibliotecaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Repositories
{
    public interface ILibrosRepository
    {
        Task<LibrosModel> CreateLibro(string titulo, int anioPublicacion, int idEditorial);
        Task<List<LibrosModel>> GetAll();
        Task<LibrosModel> UpdateLibro(LibrosModel libro);
        Task<LibrosModel> GetLibro(int id);
        Task<LibrosModel> DeleteLibro(LibrosModel libro);
    }
    public class LibrosRepository : ILibrosRepository
    {
        private readonly ApplicationDbContext _db;

        public LibrosRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<LibrosModel> CreateLibro(string titulo, int anioPublicacion, int idEditorial)
        {
            LibrosModel libro = new LibrosModel
            {
                Titulo = titulo,
                AnioPublicacion = anioPublicacion,
                IdEditorial = idEditorial
            };
            await _db.Libros.AddAsync(libro);
            await _db.SaveChangesAsync();
            return libro;
        }

        public async Task<LibrosModel> DeleteLibro(LibrosModel libro)
        {
            _db.Libros.Remove(libro);
            await _db.SaveChangesAsync();
            return libro;
        }

        public async Task<List<LibrosModel>> GetAll()
        {
            return await _db.Libros.ToListAsync();
        }

        public async Task<LibrosModel> GetLibro(int id)
        {
            return await _db.Libros.FirstOrDefaultAsync(x => x.IdLibro == id);
        }

        public async Task<LibrosModel> UpdateLibro(LibrosModel libro)
        {
            _db.Libros.Update(libro);
            await _db.SaveChangesAsync();
            return libro;
        }
    }
}
