using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmpayExpress.Domain.Entities
{
	public class Categoria
	{
		public int Id { get; set; }
		public string Nombre { get; set; } = string.Empty;
		public string? Descripcion { get; set; }

		// Relación: Una categoría tiene muchos comercios
		public ICollection<Comercio> Comercios { get; set; } = new List<Comercio>();
	}
}
