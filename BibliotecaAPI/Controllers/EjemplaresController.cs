using BibliotecaAPI.DTO;
using BibliotecaAPI.Models;
using BibliotecaAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EjemplaresController : ControllerBase
    {
        private readonly IEjemplaresService _ejemplaresService;
        public EjemplaresController(IEjemplaresService ejemplaresService)
        {
            _ejemplaresService = ejemplaresService;
        }
        [HttpGet]
        public async Task<ActionResult<List<EjemplaresDTO>>> GetAll()
        {
            return Ok(await _ejemplaresService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<EjemplaresDTO>> GetEjemplares(int id)
        {
            var Ejemplar = await _ejemplaresService.GetEjemplares(id);
            if (Ejemplar == null)
            {
                return BadRequest("Ejemplar not found");
            }
            return Ok(Ejemplar);
        }
        [HttpPost("{idLibro}/{ubicacion}")]
        public async Task<ActionResult<EjemplaresModel>> CreateEjemplares(int idLibro, string ubicacion)
        {
            var newEjemplar = await _ejemplaresService.CreateEjemplares(idLibro, ubicacion);
            return Created(string.Empty, newEjemplar);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<EjemplaresModel>> UpdateEjemplares(int id, int? idLibro = null, string? ubicacion = null)
        {
            try
            {
                return Ok(await _ejemplaresService.UpdateEjemplares(id, idLibro, ubicacion));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<EjemplaresModel>> DeleteEjemplares(int id)
        {
            var ejemplar = await _ejemplaresService.DeleteEjemplares(id);
            if (ejemplar == null)
            {
                return NotFound();
            }
            return Ok(ejemplar);
        }
    }
}
