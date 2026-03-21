using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmpayExpress.Application.DTOs
{
	public class ProductoCreateDto
	{
		[Required(ErrorMessage = "El nombre del producto es obligatorio")]
		[StringLength(100, MinimumLength = 3)]
		public string Nombre { get; set; } = null!;
		[Required(ErrorMessage = "El producto tiene que tener una descripción")]
		public string? Descripcion { get; set; }
		[Required(ErrorMessage = "El precio es obligatorio")]
		[Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a cero")]
		public decimal Precio { get; set; }
		[Required(ErrorMessage = "El stock es obligatorio")]
		[Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo")]
		public int Stock { get; set; }
		[Required(ErrorMessage = "El comercio es obligatorio")]
		public int ComercioId { get; set; }
	}
}
