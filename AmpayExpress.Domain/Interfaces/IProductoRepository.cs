using AmpayExpress.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmpayExpress.Domain.Interfaces
{
	public interface IProductoRepository
	{
		// El contrato: "Alguien me dará una lista de productos"
		Task<IEnumerable<Producto>> ObtenerTodosAsync();
		Task<Producto> CrearAsync(Producto producto);
	}
}
