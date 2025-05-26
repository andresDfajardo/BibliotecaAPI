using BibliotecaAPI.DTO;
using BibliotecaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Repositories
{
    public interface IBibliotecariosRepository
    {
        Task<List<BibliotecariosDTO>> GetAll();
        Task<BibliotecariosDTO> GetBibliotecario(int id);
        Task<BibliotecariosModel> CreateBibliotecario(int idPersona, DateOnly fechaContratacion, string turno);
        Task<BibliotecariosModel> UpdateBibliotecario(BibliotecariosModel bibliotecariosModel);
        Task<BibliotecariosModel> DeleteBibliotecario(BibliotecariosModel bibliotecariosModel);
    }
    public class BibliotecariosRepository : IBibliotecariosRepository
    {
        private readonly ApplicationDbContext _db;
        public BibliotecariosRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<BibliotecariosModel> CreateBibliotecario(int idPersona, DateOnly fechaContratacion, string turno)
        {
            BibliotecariosModel newBibliotecario = new BibliotecariosModel
            {
                IdPersona = idPersona,
                FechaContratacion = fechaContratacion,
                Turno = turno
            };
            await _db.Bibliotecarios.AddAsync(newBibliotecario);
            _db.SaveChanges();
            return newBibliotecario;
        }

        public async Task<BibliotecariosModel> DeleteBibliotecario(BibliotecariosModel bibliotecarios)
        {
            BibliotecariosModel bibliotecariosFind = _db.Bibliotecarios.Find(bibliotecarios.IdBibliotecario);
            _db.Bibliotecarios.Remove(bibliotecariosFind);
            await _db.SaveChangesAsync();
            return bibliotecariosFind;
        }

        public async Task<List<BibliotecariosDTO>> GetAll()
        {
            return await _db.Bibliotecarios.
                Include(p => p.Personas)
                .Select(p => new BibliotecariosDTO
                {
                    IdBibliotecario = p.IdBibliotecario,
                    IdPersona = p.IdPersona,
                    FechaContratacion = p.FechaContratacion,
                    Turno = p.Turno,
                    Nombre = p.Personas.Nombre,
                    Apellido = p.Personas.Apellido,
                    DocumentoIdentidad = p.Personas.DocumentoIdentidad
                }).ToListAsync();
        }

        public async Task<BibliotecariosDTO> GetBibliotecario(int id)
        {
            return await _db.Bibliotecarios.
                Include(p => p.Personas)
                .Select(p => new BibliotecariosDTO
                {
                    IdBibliotecario = p.IdBibliotecario,
                    IdPersona = p.IdPersona,
                    FechaContratacion = p.FechaContratacion,
                    Turno = p.Turno,
                    Nombre = p.Personas.Nombre,
                    Apellido = p.Personas.Apellido,
                    DocumentoIdentidad = p.Personas.DocumentoIdentidad
                }).FirstOrDefaultAsync(a => a.IdBibliotecario == id);
        }

        public async Task<BibliotecariosModel> UpdateBibliotecario(BibliotecariosModel bibliotecariosModel)
        {
            _db.Bibliotecarios.Update(bibliotecariosModel);
            await _db.SaveChangesAsync();
            return bibliotecariosModel;
        }
    }
}
