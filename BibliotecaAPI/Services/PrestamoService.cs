using BibliotecaAPI.DTO;
using BibliotecaAPI.Models;
using BibliotecaAPI.Repositories;

namespace BibliotecaAPI.Services
{
    public interface IPrestamosService
    {
        Task<PrestamosModel> CreatePrestamo(int idLector, int idBibliotecario, int idEjemplar, DateOnly fechaPrestamo, DateOnly fechaDevolucion);
        Task<List<PrestamosDTO>> GetAll();
        Task<PrestamosDTO> GetPrestamo(int id);
        Task<PrestamosModel> UpdatePrestamo(int id, int? idLector, int? idBibliotecario, int? idEjemplar, DateOnly? fechaPrestamo, DateOnly? fechaDevolucion);
        Task<PrestamosModel> DeletePrestamo(int id);
    }
    public class PrestamosService : IPrestamosService
    {
        private readonly IPrestamosRepository _prestamosRepository;

        public PrestamosService(IPrestamosRepository prestamosRepository)
        {
            _prestamosRepository = prestamosRepository;
        }

        public async Task<PrestamosModel> CreatePrestamo(int idLector, int idBibliotecario, int idEjemplar, DateOnly fechaPrestamo, DateOnly fechaDevolucion)
        {
            return await _prestamosRepository.CreatePrestamo(idLector, idBibliotecario, idEjemplar, fechaPrestamo, fechaDevolucion);
        }

        public async Task<PrestamosModel> DeletePrestamo(int id)
        {
            var prestamo = await _prestamosRepository.GetPrestamo(id);
            PrestamosModel prestamosModel = new PrestamosModel();
            prestamosModel.IdPrestamo = prestamo.IdPrestamo;

            return prestamo != null ? await _prestamosRepository.DeletePrestamo(prestamosModel) : null;
        }

        public async Task<List<PrestamosDTO>> GetAll()
        {
            return await _prestamosRepository.GetAll();
        }

        public async Task<PrestamosDTO> GetPrestamo(int id)
        {
            return await _prestamosRepository.GetPrestamo(id);
        }

        public async Task<PrestamosModel> UpdatePrestamo(int id, int? idLector, int? idBibliotecario, int? idEjemplar, DateOnly? fechaPrestamo, DateOnly? fechaDevolucion)
        {
            var prestamo = await _prestamosRepository.GetPrestamo(id);
            PrestamosModel prestamosModel = new PrestamosModel();
            prestamosModel.IdLector = prestamo.IdLector;
            prestamosModel.IdBibliotecario = prestamo.IdBibliotecario;
            prestamosModel.IdEjemplar = prestamo.IdEjemplar;
            prestamosModel.FechaPrestamo = prestamo.FechaPrestamo;
            prestamosModel.FechaDevolucion = prestamo.FechaDevolucion;
            prestamosModel.IdPrestamo = prestamo.IdPrestamo;

            if (prestamosModel != null)
            {
                if (idLector != null) prestamosModel.IdLector = idLector.Value;
                if (idBibliotecario != null) prestamosModel.IdBibliotecario = idBibliotecario.Value;
                if (idEjemplar != null) prestamosModel.IdEjemplar = idEjemplar.Value;
                if (fechaPrestamo != null) prestamosModel.FechaPrestamo = fechaPrestamo.Value;
                if (fechaDevolucion != null) prestamosModel.FechaDevolucion = fechaDevolucion.Value;

                return await _prestamosRepository.UpdatePrestamo(prestamosModel);
            }
            return null;
        }
    }
}
