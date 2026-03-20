using AmpayExpress.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AmpayExpress.Api.Controllers
{
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
	}
}
