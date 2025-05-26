using BibliotecaAPI.Models;
using BibliotecaAPI.Repositories;

namespace BibliotecaAPI.Services
{
    public interface ITarifasService
    {
        Task<TarifasModel> CreateTarifa(int idPrestamo, int diasRetraso, int montoTarifa);
        Task<List<TarifasModel>> GetAll();
        Task<TarifasModel> GetTarifa(int id);
        Task<TarifasModel> UpdateTarifa(int id, int? idPrestamo, int? diasRetraso, int? montoTarifa);
        Task<TarifasModel> DeleteTarifa(int id);
    }
    public class TarifasService : ITarifasService
    {
        private readonly ITarifasRepository _tarifasRepository;

        public TarifasService(ITarifasRepository tarifasRepository)
        {
            _tarifasRepository = tarifasRepository;
        }

        public async Task<TarifasModel> CreateTarifa(int idPrestamo, int diasRetraso, int montoTarifa)
        {
            return await _tarifasRepository.CreateTarifa(idPrestamo, diasRetraso, montoTarifa);
        }

        public async Task<TarifasModel> DeleteTarifa(int id)
        {
            var tarifa = await _tarifasRepository.GetTarifa(id);
            return tarifa != null ? await _tarifasRepository.DeleteTarifa(tarifa) : null;
        }

        public async Task<List<TarifasModel>> GetAll()
        {
            return await _tarifasRepository.GetAll();
        }

        public async Task<TarifasModel> GetTarifa(int id)
        {
            return await _tarifasRepository.GetTarifa(id);
        }

        public async Task<TarifasModel> UpdateTarifa(int id, int? idPrestamo, int? diasRetraso, int? montoTarifa)
        {
            var tarifa = await _tarifasRepository.GetTarifa(id);
            if (tarifa != null)
            {
                if (idPrestamo.HasValue) tarifa.IdPrestamo = idPrestamo.Value;
                if (diasRetraso.HasValue) tarifa.DiasRetraso = diasRetraso.Value;
                if (montoTarifa.HasValue) tarifa.MontoTarifa = montoTarifa.Value;

                return await _tarifasRepository.UpdateTarifa(tarifa);
            }
            return null;
        }
    }
}
