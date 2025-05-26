using BibliotecaAPI.DTO;
using BibliotecaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Repositories
{
    public interface IPrestamosRepository
    {
        Task<PrestamosModel> CreatePrestamo(int idLector, int idBibliotecario, int idEjemplar, DateOnly fechaPrestamo, DateOnly fechaDevolucion);
        Task<List<PrestamosDTO>> GetAll();
        Task<PrestamosDTO> GetPrestamo(int id);
        Task<PrestamosModel> UpdatePrestamo(PrestamosModel prestamo);
        Task<PrestamosModel> DeletePrestamo(PrestamosModel prestamo);
    }
    public class PrestamosRepository : IPrestamosRepository
    {
        private readonly ApplicationDbContext _db;

        public PrestamosRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<PrestamosModel> CreatePrestamo(int idLector, int idBibliotecario, int idEjemplar, DateOnly fechaPrestamo, DateOnly fechaDevolucion)
        {
            var prestamo = new PrestamosModel
            {
                IdLector = idLector,
                IdBibliotecario = idBibliotecario,
                IdEjemplar = idEjemplar,
                FechaPrestamo = fechaPrestamo,
                FechaDevolucion = fechaDevolucion
            };
            await _db.Prestamos.AddAsync(prestamo);
            await _db.SaveChangesAsync();
            return prestamo;
        }

        public async Task<PrestamosModel> DeletePrestamo(PrestamosModel prestamo)
        {
            PrestamosModel prestamoFind = _db.Prestamos.Find(prestamo.IdPrestamo);
            _db.Prestamos.Remove(prestamoFind);
            await _db.SaveChangesAsync();
            return prestamo;
        }

        public async Task<List<PrestamosDTO>> GetAll()
        {
            return await _db.Prestamos.
                Include(p => p.Lectores)
                    .ThenInclude(l => l.Personas)
                .Include(p => p.Bibliotecarios)
                    .ThenInclude(b => b.Personas)
                .Select(p => new PrestamosDTO
                {
                    IdPrestamo = p.IdPrestamo,
                    NombreLector = p.Lectores.Personas.Nombre,
                    NombreBibliotecario = p.Bibliotecarios.Personas.Nombre,
                    IdEjemplar = p.IdEjemplar,
                    FechaPrestamo = p.FechaPrestamo,
                    FechaDevolucion = p.FechaDevolucion
                }).ToListAsync();
        }

        public async Task<PrestamosDTO> GetPrestamo(int id)
        {
            return await _db.Prestamos.
                Include(p => p.Lectores)
                    .ThenInclude(l => l.Personas)
                .Include(p => p.Bibliotecarios)
                    .ThenInclude(b => b.Personas)
                .Select(p => new PrestamosDTO
                {
                    IdPrestamo = p.IdPrestamo,
                    NombreLector = p.Lectores.Personas.Nombre,
                    NombreBibliotecario = p.Bibliotecarios.Personas.Nombre,
                    IdEjemplar = p.IdEjemplar,
                    FechaPrestamo = p.FechaPrestamo,
                    FechaDevolucion = p.FechaDevolucion,
                    IdBibliotecario = p.IdBibliotecario,
                    IdLector = p.IdLector
                }).FirstOrDefaultAsync(p => p.IdPrestamo == id);
        }

        public async Task<PrestamosModel> UpdatePrestamo(PrestamosModel prestamo)
        {
            _db.Prestamos.Update(prestamo);
            await _db.SaveChangesAsync();
            return prestamo;
        }
    }
}
