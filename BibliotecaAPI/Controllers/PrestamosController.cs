using BibliotecaAPI.DTO;
using BibliotecaAPI.Models;
using BibliotecaAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrestamosController : ControllerBase
    {
        private readonly IPrestamosService _prestamosService;

        public PrestamosController(IPrestamosService prestamosService)
        {
            _prestamosService = prestamosService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PrestamosDTO>>> GetAll()
        {
            return Ok(await _prestamosService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PrestamosDTO>> GetPrestamo(int id)
        {
            var prestamo = await _prestamosService.GetPrestamo(id);
            return prestamo == null ? NotFound("Préstamo no encontrado") : Ok(prestamo);
        }

        [HttpPost("{idLector}/{idBibliotecario}/{idEjemplar}/{fechaPrestamo}/{fechaDevolucion}")]
        public async Task<ActionResult<PrestamosModel>> CreatePrestamo(int idLector, int idBibliotecario, int idEjemplar, DateOnly fechaPrestamo, DateOnly fechaDevolucion)
        {
            var nuevoPrestamo = await _prestamosService.CreatePrestamo(idLector, idBibliotecario, idEjemplar, fechaPrestamo, fechaDevolucion);
            return Created(string.Empty, nuevoPrestamo);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PrestamosModel>> UpdatePrestamo(int id, int? idLector = null, int? idBibliotecario = null, int? idEjemplar = null, DateOnly? fechaPrestamo = null, DateOnly? fechaDevolucion = null)
        {
            var actualizado = await _prestamosService.UpdatePrestamo(id, idLector, idBibliotecario, idEjemplar, fechaPrestamo, fechaDevolucion);
            return actualizado == null ? NotFound("Préstamo no encontrado") : Ok(actualizado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PrestamosModel>> DeletePrestamo(int id)
        {
            var eliminado = await _prestamosService.DeletePrestamo(id);
            return eliminado == null ? NotFound("Préstamo no encontrado") : Ok(eliminado);
        }
    }
}
