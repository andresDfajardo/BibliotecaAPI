using BibliotecaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Repositories
{
    public interface IPersonasRepository
    {
        Task<PersonasModel> CreatePersona(string nombre, string apellido, string documentoIdentidad, DateOnly fechaNacimiento, string correo, string telefono, string direccion);
        Task<List<PersonasModel>> GetAll();
        Task<PersonasModel> UpdatePersona(PersonasModel persona);
        Task<PersonasModel> GetPersona(int id);
        Task<PersonasModel> DeletePersona(PersonasModel persona);
    }
    public class PersonasRepository : IPersonasRepository
    {
        private readonly ApplicationDbContext _db;

        public PersonasRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<PersonasModel> CreatePersona(string nombre, string apellido, string documentoIdentidad, DateOnly fechaNacimiento, string correo, string telefono, string direccion)
        {
            var persona = new PersonasModel
            {
                Nombre = nombre,
                Apellido = apellido,
                DocumentoIdentidad = documentoIdentidad,
                FechaNacimiento = fechaNacimiento,
                Correo = correo,
                Telefono = telefono,
                Direccion = direccion
            };
            await _db.Personas.AddAsync(persona);
            await _db.SaveChangesAsync();
            return persona;
        }

        public async Task<PersonasModel> DeletePersona(PersonasModel persona)
        {
            _db.Personas.Remove(persona);
            await _db.SaveChangesAsync();
            return persona;
        }

        public async Task<List<PersonasModel>> GetAll()
        {
            return await _db.Personas.ToListAsync();
        }

        public async Task<PersonasModel> GetPersona(int id)
        {
            return await _db.Personas.FirstOrDefaultAsync(x => x.IdPersona == id);
        }

        public async Task<PersonasModel> UpdatePersona(PersonasModel persona)
        {
            _db.Personas.Update(persona);
            await _db.SaveChangesAsync();
            return persona;
        }
    }
}
