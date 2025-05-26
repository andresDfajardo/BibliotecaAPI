using BibliotecaAPI.Models;
using BibliotecaAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
public class PersonasController : ControllerBase
{
    private readonly IPersonasService _personasService;

    public PersonasController(IPersonasService personasService)
    {
        _personasService = personasService;
    }

    [HttpGet]
    public async Task<ActionResult<List<PersonasModel>>> GetAll()
    {
        return Ok(await _personasService.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PersonasModel>> GetPersona(int id)
    {
        var persona = await _personasService.GetPersona(id);
        return persona == null ? NotFound("Persona no encontrada") : Ok(persona);
    }

    [HttpPost("{nombre}/{apellido}/{documentoIdentidad}/{fechaNacimiento}/{correo}/{telefono}/{direccion}")]
    public async Task<ActionResult<PersonasModel>> CreatePersona(string nombre, string apellido, string documentoIdentidad, DateOnly fechaNacimiento, string correo, string telefono, string direccion)
    {
        var newPersona = await _personasService.CreatePersona(nombre, apellido, documentoIdentidad, fechaNacimiento, correo, telefono, direccion);
        return Created(string.Empty, newPersona);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<PersonasModel>> UpdatePersona(int id, string? nombre = null, string? apellido = null, string? documentoIdentidad = null, DateOnly? fechaNacimiento = null, string? correo = null, string? telefono = null, string? direccion = null)
    {
        var updated = await _personasService.UpdatePersona(id, nombre, apellido, documentoIdentidad, fechaNacimiento, correo, telefono, direccion);
        return updated == null ? NotFound("Persona no encontrada") : Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<PersonasModel>> DeletePersona(int id)
    {
        var deleted = await _personasService.DeletePersona(id);
        return deleted == null ? NotFound("Persona no encontrada") : Ok(deleted);
    }
}
}

