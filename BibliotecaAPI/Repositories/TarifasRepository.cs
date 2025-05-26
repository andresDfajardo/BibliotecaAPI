using BibliotecaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Repositories
{
    public interface ITarifasRepository
    {
        Task<TarifasModel> CreateTarifa(int idPrestamo, int diasRetraso, int montoTarifa);
        Task<List<TarifasModel>> GetAll();
        Task<TarifasModel> GetTarifa(int id);
        Task<TarifasModel> UpdateTarifa(TarifasModel tarifa);
        Task<TarifasModel> DeleteTarifa(TarifasModel tarifa);
    }

    public class TarifasRepository : ITarifasRepository
    {
        private readonly ApplicationDbContext _db;

        public TarifasRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<TarifasModel> CreateTarifa(int idPrestamo, int diasRetraso, int montoTarifa)
        {
            var tarifa = new TarifasModel
            {
                IdPrestamo = idPrestamo,
                DiasRetraso = diasRetraso,
                MontoTarifa = montoTarifa
            };
            await _db.Tarifas.AddAsync(tarifa);
            await _db.SaveChangesAsync();
            return tarifa;
        }

        public async Task<List<TarifasModel>> GetAll()
        {
            return await _db.Tarifas.ToListAsync();
        }

        public async Task<TarifasModel> GetTarifa(int id)
        {
            return await _db.Tarifas.FirstOrDefaultAsync(t => t.IdTarifa == id);
        }

        public async Task<TarifasModel> UpdateTarifa(TarifasModel tarifa)
        {
            _db.Tarifas.Update(tarifa);
            await _db.SaveChangesAsync();
            return tarifa;
        }

        public async Task<TarifasModel> DeleteTarifa(TarifasModel tarifa)
        {
            _db.Tarifas.Remove(tarifa);
            await _db.SaveChangesAsync();
            return tarifa;
        }
    }
}
