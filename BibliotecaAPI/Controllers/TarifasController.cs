using BibliotecaAPI.Models;
using BibliotecaAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarifasController : ControllerBase
    {
        private readonly ITarifasService _tarifasService;

        public TarifasController(ITarifasService tarifasService)
        {
            _tarifasService = tarifasService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TarifasModel>>> GetAll()
        {
            return Ok(await _tarifasService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TarifasModel>> GetTarifa(int id)
        {
            var tarifa = await _tarifasService.GetTarifa(id);
            return tarifa == null ? NotFound("Tarifa no encontrada") : Ok(tarifa);
        }

        [HttpPost("{idPrestamo}/{diasRetraso}/{montoTarifa}")]
        public async Task<ActionResult<TarifasModel>> CreateTarifa(int idPrestamo, int diasRetraso, int montoTarifa)
        {
            var nuevaTarifa = await _tarifasService.CreateTarifa(idPrestamo, diasRetraso, montoTarifa);
            return Created(string.Empty, nuevaTarifa);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TarifasModel>> UpdateTarifa(int id, int? idPrestamo = null, int? diasRetraso = null, int? montoTarifa = null)
        {
            var tarifa = await _tarifasService.UpdateTarifa(id, idPrestamo, diasRetraso, montoTarifa);
            return tarifa == null ? NotFound("Tarifa no encontrada") : Ok(tarifa);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TarifasModel>> DeleteTarifa(int id)
        {
            var tarifa = await _tarifasService.DeleteTarifa(id);
            return tarifa == null ? NotFound("Tarifa no encontrada") : Ok(tarifa);
        }
    }
}