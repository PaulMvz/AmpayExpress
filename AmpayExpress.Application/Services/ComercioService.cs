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
using System.Runtime.CompilerServices;


namespace AmpayExpress.Application.Services
{
	public class ComercioService : IComercioService
	{
		private readonly IComercioRepository _repository;
		private readonly ICategoriaRepository _categoriaRepository;
		public ComercioService(IComercioRepository repository, ICategoriaRepository categoriaRepository)
		{
			_repository = repository;
			_categoriaRepository = categoriaRepository;
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
			// Seguridad : Validar que la categoría realmente existe en la DB
			// Asumiendo que tienes un repositorio de categorías inyectado como _categoriaRepository
			var categoria = await _categoriaRepository.ObtenerPorIdAsync(dto.CategoriaId);
			if (categoria == null)
			{
				// Si no existe, lanzamos una excepción o manejamos el error
				// Esto evita que se intente crear un registro "huérfano" o erróneo
				throw new Exception("La categoría especificada no existe.");
			}

			// Mapeo de DTO a entidad
			var nuevocomercio = new Comercio
			{
				NombreComercial = dto.NombreComercial,
				RUC = dto.RUC,
				Direccion = dto.Direccion,
				EstadoAbierto = dto.EstadoAbierto,
				CategoriaId = dto.CategoriaId
			};

			// Persistencia: Guardamos el nuevo comercio en la base de datos
			var comercioCreado = await _repository.CrearAsync(nuevocomercio);

			// Mapeo de Salida con el nombre de categoría
			return new ComercioDto
			{
				Id = comercioCreado.Id,
				NombreComercial = comercioCreado.NombreComercial,
				RUC = comercioCreado.RUC,
				Direccion = comercioCreado.Direccion,
				EstadoAbierto = comercioCreado.EstadoAbierto,
				//Aqui usamos el nombre, no el Id, para que coincida con tu DTO actual
				CategoriaNombre = categoria.Nombre
			};

		}
	}
}
