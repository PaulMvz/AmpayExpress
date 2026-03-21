using AmpayExpress.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmpayExpress.Domain.Entities;
using AmpayExpress.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AmpayExpress.Infrastructure.Repository
{
	public class ComercioRepository : IComercioRepository
	{
		// En este repositorio, inyectamos el ApplicationDbContext para acceder a la base de datos.
		private readonly ApplicationDbContext _context;
		public ComercioRepository(ApplicationDbContext context)
		{
			_context = context;
		}
		public async Task<IEnumerable<Comercio>> ObtenerTodosAsync()
		{
			return await _context.Comercio.Include(c => c.Categoria).ToListAsync();
		}
	}
}
