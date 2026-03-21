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
using AmpayExpress.Domain.Entities;


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
		public async Task<ComercioDto> CrearComercioAsync(ComercioCreateDto dto)
		{
			// 1. Convertimos el DTO a una entidad de dominio
			var nuevocomercio = new Comercio
			{
				NombreComercial = dto.NombreComercial,
				RUC = dto.RUC,
				Direccion = dto.Direccion,
				EstadoAbierto = dto.EstadoAbierto,
				CategoriaId = dto.CategoriaId
			};

			// 2. Guardamos en la base de datos
			var comercioCreado = await _repository.CrearAsync(nuevocomercio);

			// 3. Retornamos el DTO de respuesta (para confirmar el ID generado)
			return new ComercioDto
			{
				Id = comercioCreado.Id,
				NombreComercial = comercioCreado.NombreComercial,
				RUC = comercioCreado.RUC,
				Direccion = comercioCreado.Direccion,
				EstadoAbierto = comercioCreado.EstadoAbierto,
				//Aqui usamos el nombre, no el Id, para que coincida con tu DTO actual
				CategoriaNombre = "Asignada"
			};

		}
	}
}
