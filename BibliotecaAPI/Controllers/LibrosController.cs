using BibliotecaAPI.Models;
using BibliotecaAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibrosController : ControllerBase
    {
        private readonly ILibrosService _librosService;

        public LibrosController(ILibrosService librosService)
        {
            _librosService = librosService;
        }

        [HttpGet]
        public async Task<ActionResult<List<LibrosModel>>> GetAll()
        {
            return Ok(await _librosService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LibrosModel>> GetLibro(int id)
        {
            var libro = await _librosService.GetLibro(id);
            if (libro == null)
                return NotFound("Libro no encontrado");
            return Ok(libro);
        }

        [HttpPost("{titulo}/{anioPublicacion}/{idEditorial}")]
        public async Task<ActionResult<LibrosModel>> CreateLibro(string titulo, int anioPublicacion, int idEditorial)
        {
            var newLibro = await _librosService.CreateLibro(titulo, anioPublicacion, idEditorial);
            return Created(string.Empty, newLibro);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<LibrosModel>> UpdateLibro(int id, string? titulo = null, int? anioPublicacion = null, int? idEditorial = null)
        {
            var updated = await _librosService.UpdateLibro(id, titulo, anioPublicacion, idEditorial);
            if (updated == null)
                return NotFound("Libro no encontrado");
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<LibrosModel>> DeleteLibro(int id)
        {
            var deleted = await _librosService.DeleteLibro(id);
            if (deleted == null)
                return NotFound("Libro no encontrado");
            return Ok(deleted);
        }
    }
}
