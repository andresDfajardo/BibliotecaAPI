using BibliotecaAPI.Models;
using BibliotecaAPI.Repositories;

namespace BibliotecaAPI.Services
{
    public interface ILibrosService
    {
        Task<LibrosModel> CreateLibro(string titulo, int anioPublicacion, int idEditorial);
        Task<List<LibrosModel>> GetAll();
        Task<LibrosModel> UpdateLibro(int id, string? titulo, int? anioPublicacion, int? idEditorial);
        Task<LibrosModel> GetLibro(int id);
        Task<LibrosModel> DeleteLibro(int id);
    }
    public class LibrosService : ILibrosService
    {
        private readonly ILibrosRepository _librosRepository;

        public LibrosService(ILibrosRepository librosRepository)
        {
            _librosRepository = librosRepository;
        }

        public async Task<LibrosModel> CreateLibro(string titulo, int anioPublicacion, int idEditorial)
        {
            return await _librosRepository.CreateLibro(titulo, anioPublicacion, idEditorial);
        }

        public async Task<LibrosModel> DeleteLibro(int id)
        {
            var libro = await _librosRepository.GetLibro(id);
            if (libro != null)
            {
                return await _librosRepository.DeleteLibro(libro);
            }
            return null;
        }

        public async Task<List<LibrosModel>> GetAll()
        {
            return await _librosRepository.GetAll();
        }

        public async Task<LibrosModel> GetLibro(int id)
        {
            return await _librosRepository.GetLibro(id);
        }

        public async Task<LibrosModel> UpdateLibro(int id, string? titulo, int? anioPublicacion, int? idEditorial)
        {
            var libro = await _librosRepository.GetLibro(id);
            if (libro != null)
            {
                if (!string.IsNullOrEmpty(titulo))
                    libro.Titulo = titulo;
                if (anioPublicacion != null)
                    libro.AnioPublicacion = anioPublicacion;
                if (idEditorial != null)
                    libro.IdEditorial = idEditorial.Value;

                return await _librosRepository.UpdateLibro(libro);
            }
            return null;
        }
    }
}