using BibliotecaAPI.DTO;
using BibliotecaAPI.Models;
using BibliotecaAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BibliotecariosController : ControllerBase
    {
        private readonly IBibliotecariosService _bibliotecariosService;
        public BibliotecariosController(IBibliotecariosService bibliotecarioService)
        {
            _bibliotecariosService = bibliotecarioService;
        }
        [HttpGet]
        public async Task<ActionResult<List<BibliotecariosDTO>>> GetAllBibliotecarios()
        {
            return Ok(await _bibliotecariosService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<BibliotecariosDTO>> GetBibliotecarios(int id)
        {
            var Bibliotecario = await _bibliotecariosService.GetBibliotecario(id);
            if (Bibliotecario == null)
            {
                return BadRequest("Bibliotecario not found");
            }
            return Ok(Bibliotecario);
        }
        [HttpPost("{idPersona}/{fechaContratacion}/{turno}")]
        public async Task<ActionResult<BibliotecariosModel>> CreateBibliotecario(int idPersona, DateOnly fechaContratacion, string turno)
        {
            var newBibliotecario = await _bibliotecariosService.CreateBibliotecario(idPersona, fechaContratacion, turno);
            return Created(string.Empty, newBibliotecario);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<BibliotecariosModel>> UpdateBibliotecario(int id, int? idPersona = null, DateOnly? fechaContratacion = null, string? turno = null)
        {
            try
            {
                return Ok(await _bibliotecariosService.UpdateBibliotecario(id, idPersona, fechaContratacion, turno));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<BibliotecariosModel>> DeleteBibliotecario(int id)
        {
            var bibliotecario = await _bibliotecariosService.DeleteBibliotecario(id);
            if (bibliotecario == null)
            {
                return NotFound();
            }
            return Ok(bibliotecario);
        }
    }
}
