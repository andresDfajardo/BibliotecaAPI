using BibliotecaAPI.Models;
using BibliotecaAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EditorialesController : ControllerBase
    {
        private readonly IEditorialesService _editorialesService;
        public EditorialesController(IEditorialesService editorialesService)
        {
            _editorialesService = editorialesService;
        }
        [HttpGet]
        public async Task<ActionResult<List<EditorialesModel>>> GetAll()
        {
            return Ok(await _editorialesService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<EditorialesModel>> GetEditorial(int id)
        {
            var Editorial = await _editorialesService.GetEditorial(id);
            if (Editorial == null)
            {
                return BadRequest("Editorial not found");
            }
            return Ok(Editorial);
        }
        [HttpPost("{nombre}/{pais}/{ciudad}/{sitioWeb}")]
        public async Task<ActionResult<EditorialesModel>> CreateEditoriales(string nombre,string pais, string ciudad, string sitioWeb)
        {
            var newEditorial = await _editorialesService.CreateEditoriales(nombre, pais, ciudad, sitioWeb);
            return Created(string.Empty, newEditorial);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<EditorialesModel>> UpdateEditoriales(int id, string? nombre = null, string? pais = null, string? ciudad = null, string? sitioWeb = null)
        {
            try
            {
                return Ok(await _editorialesService.UpdateEditoriales(id, nombre, pais, ciudad, sitioWeb));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<EditorialesModel>> DeleteEditoriales(int id)
        {
            var editorial = await _editorialesService.DeleteEditoriales(id);
            if (editorial == null)
            {
                return NotFound();
            }
            return Ok(editorial);
        }
    }
}
