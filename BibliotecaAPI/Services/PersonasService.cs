using BibliotecaAPI.Models;
using BibliotecaAPI.Repositories;

namespace BibliotecaAPI.Services
{
    public interface IPersonasService
    {
        Task<PersonasModel> CreatePersona(string nombre, string apellido, string documentoIdentidad, DateOnly fechaNacimiento, string correo, string telefono, string direccion);
        Task<List<PersonasModel>> GetAll();
        Task<PersonasModel> UpdatePersona(int id, string? nombre, string? apellido, string? documentoIdentidad, DateOnly? fechaNacimiento, string? correo, string? telefono, string? direccion);
        Task<PersonasModel> GetPersona(int id);
        Task<PersonasModel> DeletePersona(int id);
    }
    public class PersonasService : IPersonasService
    {
        private readonly IPersonasRepository _personasRepository;

        public PersonasService(IPersonasRepository personasRepository)
        {
            _personasRepository = personasRepository;
        }

        public async Task<PersonasModel> CreatePersona(string nombre, string apellido, string documentoIdentidad, DateOnly fechaNacimiento, string correo, string telefono, string direccion)
        {
            return await _personasRepository.CreatePersona(nombre, apellido, documentoIdentidad, fechaNacimiento, correo, telefono, direccion);
        }

        public async Task<PersonasModel> DeletePersona(int id)
        {
            var persona = await _personasRepository.GetPersona(id);
            return persona != null ? await _personasRepository.DeletePersona(persona) : null;
        }

        public async Task<List<PersonasModel>> GetAll()
        {
            return await _personasRepository.GetAll();
        }

        public async Task<PersonasModel> GetPersona(int id)
        {
            return await _personasRepository.GetPersona(id);
        }

        public async Task<PersonasModel> UpdatePersona(int id, string? nombre, string? apellido, string? documentoIdentidad, DateOnly? fechaNacimiento, string? correo, string? telefono, string? direccion)
        {
            var persona = await _personasRepository.GetPersona(id);
            if (persona != null)
            {
                if (nombre != null) persona.Nombre = nombre;
                if (apellido != null) persona.Apellido = apellido;
                if (documentoIdentidad != null) persona.DocumentoIdentidad = documentoIdentidad;
                if (fechaNacimiento != null) persona.FechaNacimiento = fechaNacimiento.Value;
                if (correo != null) persona.Correo = correo;
                if (telefono != null) persona.Telefono = telefono;
                if (direccion != null) persona.Direccion = direccion;

                return await _personasRepository.UpdatePersona(persona);
            }
            return null;
        }
    }
}
