using AmpayExpress.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AmpayExpress.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProductosController : ControllerBase
	{
		private readonly IProductoService _productoService;
		public ProductosController(IProductoService productoService)
		{
			_productoService = productoService;
		}
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var productos = await _productoService.ObtenerTodosLosProductosAsync();
			return Ok(productos);
		}
	}
}
