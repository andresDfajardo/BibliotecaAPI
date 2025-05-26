using BibliotecaAPI.DTO;
using BibliotecaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Repositories
{
    public interface IEjemplaresRepository
    {
        Task<EjemplaresModel> CreateEjemplares(int idLibro, string ubicacion);
        Task<List<EjemplaresDTO>> GetAll();
        Task<EjemplaresModel> UpdateEjemplares(EjemplaresModel ejemplares);
        Task<EjemplaresDTO> GetEjemplares(int id);
        Task<EjemplaresModel> DeleteEjemplares(EjemplaresModel ejemplares);
    }
    public class EjemplaresRepository : IEjemplaresRepository
    {
        private readonly ApplicationDbContext _db;
        public EjemplaresRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<EjemplaresModel> CreateEjemplares(int idLibro, string ubicacion)
        {
            EjemplaresModel model = new EjemplaresModel
            {
                IdLibro = idLibro,
                Ubicacion = ubicacion
            };
            await _db.Ejemplares.AddAsync(model);
            _db.SaveChanges();
            return model;
        }

        public async Task<EjemplaresModel> DeleteEjemplares(EjemplaresModel ejemplares)
        {
            EjemplaresModel ejemplaresFind = _db.Ejemplares.Find(ejemplares.IdEjemplar);
            _db.Ejemplares.Remove(ejemplaresFind);
            await _db.SaveChangesAsync();
            return ejemplaresFind;
        }

        public async Task<List<EjemplaresDTO>> GetAll()
        {
            return await _db.Ejemplares.
                Include(p => p.Libros)
                .Select(p => new EjemplaresDTO
                {
                    IdEjemplar = p.IdEjemplar,
                    IdLibro = p.IdLibro,
                    Ubicacion = p.Ubicacion,
                    Titulo = p.Libros.Titulo
                }).ToListAsync();
        }

        public async Task<EjemplaresDTO> GetEjemplares(int id)
        {
            return await _db.Ejemplares.
                Include(p => p.Libros)
                .Select(p => new EjemplaresDTO
                {
                    IdEjemplar = p.IdEjemplar,
                    IdLibro = p.IdLibro,
                    Ubicacion = p.Ubicacion,
                    Titulo = p.Libros.Titulo
                }).FirstOrDefaultAsync(x => x.IdEjemplar == id);
        }

        public async Task<EjemplaresModel> UpdateEjemplares(EjemplaresModel ejemplares)
        {
            _db.Ejemplares.Update(ejemplares);
            await _db.SaveChangesAsync();
            return ejemplares;
        }
    }
}
