using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AmpayExpress.Application.DTOs;
using AmpayExpress.Application.Interfaces;
using AmpayExpress.Domain.Interfaces;

namespace AmpayExpress.Application.Services
{
	public class ProductoService : IProductoService
	{
		private readonly IProductoRepository _repository;
		
		public ProductoService(IProductoRepository repository)
		{
			_repository = repository;
		}

		public async Task<IEnumerable<ProductoDto>> ObtenerTodosLosProductosAsync()
		{
			var productos = await _repository.ObtenerTodosAsync();
			return productos.Select(p => new ProductoDto
			{
				Id = p.Id,
				Nombre = p.Nombre,
				Descripcion = p.Descripcion,
				Precio = p.Precio,
				Stock = p.Stock,
				ComercioNombre = p.Comercio != null ? p.Comercio.NombreComercial : "Desconocido"
			});
		}
	}
}
