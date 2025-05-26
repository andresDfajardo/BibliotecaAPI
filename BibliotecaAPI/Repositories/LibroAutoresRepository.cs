
using BibliotecaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Repositories
{

    public interface ILibroAutoresRepository
    {
        Task<LibroAutoresModel> CreateLibroAutor(int idLibro, int idAutor, string rol);
        Task<List<LibroAutoresModel>> GetAll();
        Task<LibroAutoresModel> UpdateLibroAutor(LibroAutoresModel libroAutor);
        Task<LibroAutoresModel> GetLibroAutor(int idLibro, int idAutor);
        Task<LibroAutoresModel> DeleteLibroAutor(LibroAutoresModel libroAutor);
        public class LibroAutoresRepository : ILibroAutoresRepository
        {
            private readonly ApplicationDbContext _db;
            public LibroAutoresRepository(ApplicationDbContext db)
            {
                _db = db;
            }

            public async Task<LibroAutoresModel> CreateLibroAutor(int idLibro, int idAutor, string rol)
            {
                LibroAutoresModel libroAutor = new LibroAutoresModel
                {
                    IdLibro = idLibro,
                    IdAutor = idAutor,
                    rol = rol
                };
                await _db.LibroAutores.AddAsync(libroAutor);
                await _db.SaveChangesAsync();
                return libroAutor;
            }

            public async Task<List<LibroAutoresModel>> GetAll()
            {
                return await _db.LibroAutores.ToListAsync();
            }

            public async Task<LibroAutoresModel> GetLibroAutor(int idLibro, int idAutor)
            {
                return await _db.LibroAutores.FirstOrDefaultAsync(x => x.IdLibro == idLibro && x.IdAutor == idAutor);
            }

            public async Task<LibroAutoresModel> UpdateLibroAutor(LibroAutoresModel libroAutor)
            {
                _db.LibroAutores.Update(libroAutor);
                await _db.SaveChangesAsync();
                return libroAutor;
            }

            public async Task<LibroAutoresModel> DeleteLibroAutor(LibroAutoresModel libroAutor)
            {
                _db.LibroAutores.Remove(libroAutor);
                await _db.SaveChangesAsync();
                return libroAutor;
            }
        }
    }
}

