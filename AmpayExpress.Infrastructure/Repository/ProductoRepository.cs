using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmpayExpress.Domain.Entities;
using AmpayExpress.Domain.Interfaces;
using AmpayExpress.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AmpayExpress.Infrastructure.Repository
{
	public class ProductoRepository : IProductoRepository
	{
		private readonly ApplicationDbContext _context;
		public ProductoRepository(ApplicationDbContext context) {
			_context = context;
		}
		public async Task<IEnumerable<Producto>> ObtenerTodosAsync()
		{
			return await _context.Producto.Include(p => p.Comercio).ToListAsync();
		}
		public async Task<Producto> CrearAsync(Producto producto)
		{
			await _context.Producto.AddAsync(producto);
			await _context.SaveChangesAsync();
			return producto;
		}

	}
}
