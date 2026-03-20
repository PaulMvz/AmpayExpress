using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AmpayExpress.Application.DTOs;
using AmpayExpress.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
//Asumimos que aqui inyectaremos tu DbContext de Infrastructure
using AmpayExpress.Domain.Interfaces;


namespace AmpayExpress.Application.Services
{
	public class ComercioService : IComercioService
	{
		private readonly IComercioRepository _repository;
		public ComercioService(IComercioRepository repository)
		{
			_repository = repository;
		}

		public async Task<IEnumerable<ComercioDto>> ObtenerTodosLosComerciosAsync()
		{
			var comercios = await _repository.ObtenerTodosAsync();
			return comercios.Select(c => new ComercioDto{
				Id = c.Id,
				NombreComercial = c.NombreComercial,
				RUC = c.RUC,
				Direccion = c.Direccion,
				EstadoAbierto = c.EstadoAbierto,
				CategoriaNombre = c.Categoria != null ? c.Categoria.Nombre : "Sin Categoría"
			});
			
		}
	}
}
