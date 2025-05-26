using BibliotecaAPI.DTO;
using BibliotecaAPI.Models;
using BibliotecaAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LectoresController : ControllerBase
    {
        private readonly ILectoresService _lectoresService;
        public LectoresController(ILectoresService lectoresService)
        {
            _lectoresService = lectoresService;
        }
        [HttpGet]
        public async Task<ActionResult<List<LectoresDTO>>> GetAll()
        {
            return Ok(await _lectoresService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<LectoresDTO>> GetLectores(int id)
        {
            var Lector = await _lectoresService.GetLectores(id);
            if (Lector == null)
            {
                return BadRequest("Lector not found");
            }
            return Ok(Lector);
        }
        [HttpPost("{idPersona}/{fechaRegistro}/{ocupacion}")]
        public async Task<ActionResult<LectoresModel>> CreateLectores(int idPersona, DateOnly fechaRegistro, string ocupacion)
        {
            var newLector = await _lectoresService.CreateLectores(idPersona, fechaRegistro,ocupacion);
            return Created(string.Empty, newLector);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<LectoresModel>> UpdateLectores(int id, int? idPersona = null, DateOnly? fechaRegistro = null,string ? ocupacion = null)
        {
            try
            {
                return Ok(await _lectoresService.UpdateLectores(id, idPersona,fechaRegistro,ocupacion));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<LectoresModel>> DeleteLectores(int id)
        {
            var lector = await _lectoresService.DeleteLectores(id);
            if (lector == null)
            {
                return NotFound();
            }
            return Ok(lector);
        }
    }
}
