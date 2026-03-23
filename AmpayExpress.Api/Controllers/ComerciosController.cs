using AmpayExpress.Application.DTOs;
using AmpayExpress.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AmpayExpress.Api.Controllers
{
	[Authorize] // Esto bloquea el acceso a esta ruta para usuarios no autenticados. Asegúrate de configurar la autenticación en tu aplicación.
	[ApiController]
	[Route("api/[controller]")]
	public class ComerciosController : ControllerBase
	{
		private readonly IComercioService _comercioService;

		public ComerciosController(IComercioService comercioService)
		{
			_comercioService = comercioService;
		}
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var comercios = await _comercioService.ObtenerTodosLosComerciosAsync();
			return Ok(comercios);
		}
		[HttpPost]
		public async Task<ActionResult<ComercioDto>> Post([FromBody] ComercioCreateDto dto)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState); //Si el RUC no tiene 11 dígitos, se devuelve un error de validación

			var resultado = await _comercioService.CrearComercioAsync(dto);
			//Cambiamos nameof(Get) por "GetAll" o el nombre del método que corresponda para obtener el comercio recién creado
			return CreatedAtAction(nameof(GetAll), new { id = resultado.Id }, resultado);
		}
	} 
}
