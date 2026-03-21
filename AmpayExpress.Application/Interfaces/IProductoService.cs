using AmpayExpress.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmpayExpress.Application.Interfaces
{
	public interface IProductoService
	{
		//Una tarea asíncrona que devuelve una lista de nuestros DTOs
		Task<IEnumerable<ProductoDto>> ObtenerTodosLosProductosAsync();
	}
}
