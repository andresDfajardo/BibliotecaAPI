using BibliotecaAPI.Models;
using BibliotecaAPI.Repositories;

namespace BibliotecaAPI.Services
{
    public interface IAutoresService
    {
        Task<List<AutoresModel>> GetAll();
        Task<AutoresModel> GetAutores(int id);
        Task<AutoresModel> CreateAutores(string nombre, string apellido, DateOnly fechaNacimiento, string nacionalidad);
        Task<AutoresModel> UpdateAutores(int id, string? nombre, string? apellido, DateOnly? fechaNacimiento, string? nacionalidad);
        Task<AutoresModel> DeleteAutores(int id);
    }
    public class AutoresService : IAutoresService
    {
        private readonly IAutoresRepository _autoresRepository;
        public AutoresService(IAutoresRepository autoresRepository)
        {
            _autoresRepository = autoresRepository;
        }
        public async Task<AutoresModel> CreateAutores(string nombre, string apellido, DateOnly fechaNacimiento, string nacionalidad)
        {
            return await _autoresRepository.CreateAutores(nombre, apellido, fechaNacimiento, nacionalidad);
        }

        public async Task<AutoresModel> DeleteAutores(int id)
        {
            AutoresModel autoresModel = await _autoresRepository.GetAutores(id);
            return await _autoresRepository.DeleteAutores(autoresModel);
        }

        public async Task<List<AutoresModel>> GetAll()
        {
            return await _autoresRepository.GetAll();
        }

        public async Task<AutoresModel> GetAutores(int id)
        {
            return await _autoresRepository.GetAutores(id);
        }

        public async Task<AutoresModel> UpdateAutores(int id, string? nombre, string? apellido, DateOnly? fechaNacimiento, string? nacionalidad)
        {
            AutoresModel autoresModel = await _autoresRepository.GetAutores(id);
            if (autoresModel != null)
            {
                if (nombre != null)
                    autoresModel.Nombre = nombre;
                else if (apellido != null)
                    autoresModel.Apellido = apellido;
                else if (fechaNacimiento != null)
                    autoresModel.FechaNacimiento = fechaNacimiento;
                else if (nacionalidad != null)
                    autoresModel.Nacionalidad = nacionalidad;
                return await _autoresRepository.UpdateAutores(autoresModel);
            }
            else
                return null;
        }
    }
}
