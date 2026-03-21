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
		private readonly IComercioRepository _comercioRepository;

		public ProductoService(IProductoRepository repository, IComercioRepository comercioRepository)
		{
			_repository = repository;
			_comercioRepository = comercioRepository;
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
		public async Task<ProductoDto> CrearProductoAsync(ProductoCreateDto dto)
		{
			// Validar que el comercio existe
			var comercio = await _comercioRepository.ObtenerPorIdAsync(dto.ComercioId);
			if (comercio == null)
			{
				throw new Exception("El comercio especificado no existe.");
			}
			var nuevoProducto = new Domain.Entities.Producto
			{
				Nombre = dto.Nombre,
				Descripcion = dto.Descripcion,
				Precio = dto.Precio,
				Stock = dto.Stock,
				ComercioId = dto.ComercioId
			};
			var productoCreado = await _repository.CrearAsync(nuevoProducto);
			return new ProductoDto
			{
				Id = productoCreado.Id,
				Nombre = productoCreado.Nombre,
				Descripcion = productoCreado.Descripcion,
				Precio = productoCreado.Precio,
				Stock = productoCreado.Stock,
				ComercioNombre = comercio.NombreComercial
			};
		}
	}
}
