using AmpayExpress.Domain.Interfaces;
using AmpayExpress.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using AmpayExpress.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmpayExpress.Infrastructure.Repository
{
	public class CategoriaRepository : ICategoriaRepository
	{
		private readonly ApplicationDbContext _context;
		public CategoriaRepository(ApplicationDbContext context)
		{
			_context = context;
		}
		public async Task<Categoria?> ObtenerPorIdAsync(int id) // El ? dice: "esto puede ser nulo"
		{
			return await _context.Categoria.FindAsync(id);
		}

	}
}
