using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmpayExpress.Application.DTOs
{
	public class ProductoDto
	{
		public int Id { get; set; }
		public string Nombre { get; set; } = null!;
		public string? Descripcion { get; set; }
		public decimal Precio { get; set; }
		public int Stock { get; set; }
		public String ComercioNombre { get; set; } = null!; // Aquí aplanamos la relación con Comercio
	}
}
