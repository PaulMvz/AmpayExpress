using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmpayExpress.Domain.Entities
{
	public class Producto
	{
		public int Id { get; set; }
		public string Nombre { get; set; } = string.Empty;
		public string? Descripcion { get; set; }
		public decimal Precio { get; set; }
		public int Stock { get; set; }

		// Relación con el Comercio que lo vende
		public int ComercioId { get; set; }
		public Comercio Comercio { get; set; } = null!;
	}
}
