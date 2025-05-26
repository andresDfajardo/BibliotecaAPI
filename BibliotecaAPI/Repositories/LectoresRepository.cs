using BibliotecaAPI.DTO;
using BibliotecaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Repositories
{
    public interface ILectoresRepository
    {
        Task<LectoresModel> CreateLectores(int idPersona, DateOnly fechaRegistro, string ocupacion);
        Task<List<LectoresDTO>> GetAll();
        Task<LectoresModel> UpdateLectores(LectoresModel lectores);
        Task<LectoresDTO> GetLectores(int id);
        Task<LectoresModel> DeleteLectores(LectoresModel lectores);
    }
    public class LectoresRepository : ILectoresRepository
    {
        private readonly ApplicationDbContext _db;
        public LectoresRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<LectoresModel> CreateLectores(int idPersona, DateOnly fechaRegistro, string ocupacion)
        {
            LectoresModel lectores = new LectoresModel
            {
                IdPersona = idPersona,
                FechaRegistro = fechaRegistro,
                Ocupacion = ocupacion
            };
            await _db.Lectores.AddAsync(lectores);
            _db.SaveChanges();
            return lectores;
        }

        public async Task<LectoresModel> DeleteLectores(LectoresModel lectores)
        {
            LectoresModel lectoresFind = _db.Lectores.Find(lectores.IdLector);
            _db.Lectores.Remove(lectoresFind);
            await _db.SaveChangesAsync();
            return lectores;
        }

        public async Task<List<LectoresDTO>> GetAll()
        {
            return await _db.Lectores.
                Include(p => p.Personas)
                .Select(p => new LectoresDTO
                {
                    IdLector = p.IdLector,
                    IdPersona = p.IdPersona,
                    FechaRegistro = p.FechaRegistro,
                    Ocupacion = p.Ocupacion,
                    Nombre = p.Personas.Nombre,
                    Apellido = p.Personas.Apellido,
                    DocumentoIdentidad = p.Personas.DocumentoIdentidad
                }).ToListAsync();
        }

        public async Task<LectoresDTO> GetLectores(int id)
        {
            return await _db.Lectores.
                Include(p => p.Personas)
                .Select(p => new LectoresDTO
                {
                    IdLector = p.IdLector,
                    IdPersona = p.IdPersona,
                    FechaRegistro = p.FechaRegistro,
                    Ocupacion = p.Ocupacion,
                    Nombre = p.Personas.Nombre,
                    Apellido = p.Personas.Apellido,
                    DocumentoIdentidad = p.Personas.DocumentoIdentidad
                }).FirstOrDefaultAsync(x => x.IdLector == id);
        }

        public async Task<LectoresModel> UpdateLectores(LectoresModel lectores)
        {
            _db.Lectores.Update(lectores);
            await _db.SaveChangesAsync();
            return lectores;
        }
    }
}
