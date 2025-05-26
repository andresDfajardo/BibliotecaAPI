using BibliotecaAPI.Models;
using BibliotecaAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaAPI.Controllers
{
        [ApiController]
        [Route("[controller]")]
        public class LibroAutoresController : ControllerBase
        {
            private readonly ILibroAutoresService _libroAutoresService;

            public LibroAutoresController(ILibroAutoresService libroAutoresService)
            {
                _libroAutoresService = libroAutoresService;
            }

            [HttpGet]
            public async Task<ActionResult<List<LibroAutoresModel>>> GetAll()
            {
                return Ok(await _libroAutoresService.GetAll());
            }

            [HttpGet("{idLibro}/{idAutor}")]
            public async Task<ActionResult<LibroAutoresModel>> GetLibroAutor(int idLibro, int idAutor, string? rol = null)
            {
                var item = await _libroAutoresService.GetLibroAutor(idLibro, idAutor, rol);
                if (item == null)
                {
                    return NotFound("Libro-Autor no encontrado");
                }
                return Ok(item);
            }

            [HttpPost("{idLibro}/{idAutor}/{rol}")]
            public async Task<ActionResult<LibroAutoresModel>> CreateLibroAutor(int idLibro, int idAutor, string rol)
            {
                var newItem = await _libroAutoresService.CreateLibroAutor(idLibro, idAutor, rol);
                return Created(string.Empty, newItem);
            }

            [HttpPut("{idLibro}/{idAutor}")]
            public async Task<ActionResult<LibroAutoresModel>> UpdateLibroAutor(int idLibro, int idAutor, string? rol = null)
            {
                try
                {
                    var updated = await _libroAutoresService.UpdateLibroAutor(idLibro, idAutor, rol);
                    if (updated == null)
                        return NotFound("Libro-Autor no encontrado");
                    return Ok(updated);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }

            [HttpDelete("{idLibro}/{idAutor}")]
            public async Task<ActionResult<LibroAutoresModel>> DeleteLibroAutor(int idLibro, int idAutor, string? rol = null)
            {
                var deleted = await _libroAutoresService.DeleteLibroAutor(idLibro, idAutor, rol);
                if (deleted == null)
                {
                    return NotFound("Libro-Autor no encontrado");
                }
                return Ok(deleted);
            }
        }
 }
