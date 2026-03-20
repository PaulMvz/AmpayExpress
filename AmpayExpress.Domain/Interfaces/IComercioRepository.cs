using AmpayExpress.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmpayExpress.Domain.Interfaces
{
	public interface IComercioRepository
	{
		// El contrato: "Alguien me dará una lista de comercios"
		Task<IEnumerable<Comercio>> ObtenerTodosAsync();
	}
}
