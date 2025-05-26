using BibliotecaAPI.Models;
using BibliotecaAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BibliotecaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutoresController : ControllerBase
    {
        private readonly IAutoresService _autoresService;
        public AutoresController(IAutoresService autoresService)
        {
            _autoresService = autoresService;
        }
        [HttpGet]
        public async Task<ActionResult<List<AutoresModel>>> GetAllAutores()
        {
            return Ok(await _autoresService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AutoresModel>> GetAutor(int id)
        {
            var Autor = await _autoresService.GetAutores(id);
            if (Autor == null)
            {
                return BadRequest("Autor not found");
            }
            return Ok(Autor);
        }
        [HttpPost("{nombre}/{apellido}/{fechaNacimiento}/{nacionalidad}")]
        public async Task<ActionResult<AutoresModel>> CreateAutor(string nombre, string apellido, DateOnly fechaNacimiento, string nacionalidad)
        {
            var newAutor = await _autoresService.CreateAutores(nombre,apellido,fechaNacimiento,nacionalidad);
            return Created(string.Empty, newAutor);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<AutoresModel>> UpdateAutor(int id, string? nombre = null, string? apellido = null, DateOnly? fechaNacimiento = null, string? nacionalidad = null)
        {
            try
            {
                return Ok(await _autoresService.UpdateAutores(id, nombre,apellido,fechaNacimiento,nacionalidad));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<AutoresModel>> DeleteAutor(int id)
        {
            var autor = await _autoresService.DeleteAutores(id);
            if (autor == null)
            {
                return NotFound();
            }
            return Ok(autor);
        }
    }
}
