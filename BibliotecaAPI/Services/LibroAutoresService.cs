using BibliotecaAPI.Models;
using BibliotecaAPI.Repositories;

namespace BibliotecaAPI.Services
{
    public interface ILibroAutoresService
    {
        Task<LibroAutoresModel> CreateLibroAutor(int idLibro, int idAutor, string rol);
        Task<List<LibroAutoresModel>> GetAll();
        Task<LibroAutoresModel> UpdateLibroAutor(int idLibro, int idAutor, string? rol);
        Task<LibroAutoresModel> GetLibroAutor(int idLibro, int idAutor, string r);
        Task<LibroAutoresModel> DeleteLibroAutor(int idLibro, int idAutor, string rol);
        public class LibroAutoresService : ILibroAutoresService
        {
            private readonly ILibroAutoresRepository _libroAutoresRepository;

            public LibroAutoresService(ILibroAutoresRepository libroAutoresRepository)
            {
                _libroAutoresRepository = libroAutoresRepository;
            }

            public async Task<LibroAutoresModel> CreateLibroAutor(int idLibro, int idAutor, string rol)
            {
                return await _libroAutoresRepository.CreateLibroAutor(idLibro, idAutor, rol);
            }

            public async Task<LibroAutoresModel> DeleteLibroAutor(int idLibro, int idAutor, string r)
            {
                var libroAutor = await _libroAutoresRepository.GetLibroAutor(idLibro, idAutor);
                if (libroAutor != null)
                {
                    return await _libroAutoresRepository.DeleteLibroAutor(libroAutor);
                }
                return null;
            }

            public async Task<List<LibroAutoresModel>> GetAll()
            {
                return await _libroAutoresRepository.GetAll();
            }

            public async Task<LibroAutoresModel> GetLibroAutor(int idLibro, int idAutor, string r)
            {
                return await _libroAutoresRepository.GetLibroAutor(idLibro, idAutor);
            }

            public async Task<LibroAutoresModel> UpdateLibroAutor(int idLibro, int idAutor, string rol)
            {
                var libroAutor = await _libroAutoresRepository.GetLibroAutor(idLibro, idAutor);
                if (libroAutor != null)
                {
                    if (!string.IsNullOrEmpty(rol))
                        libroAutor.rol = rol;
                    return await _libroAutoresRepository.UpdateLibroAutor(libroAutor);
                }
                return null;
            }
        }
    }
}