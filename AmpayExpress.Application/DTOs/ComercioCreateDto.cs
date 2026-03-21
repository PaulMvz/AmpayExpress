using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmpayExpress.Application.DTOs
{
	public class ComercioCreateDto
	{
		[Required(ErrorMessage = "El nombre comercial es obligatorio")]
		[StringLength(100, MinimumLength = 3)]
		public string NombreComercial { get; set; } = null!;

		[Required(ErrorMessage = "El RUC es obligatorio")]
		[RegularExpression(@"^\d{11}$", ErrorMessage = "El RUC debe tener exactamente 11 dígitos")]
		public string RUC { get; set; } = null!;

		[Required(ErrorMessage = "La dirección es obligatoria")]
		public string Direccion { get; set; } = null!;
		public bool EstadoAbierto { get; set; }

		[Required(ErrorMessage = "La categoría es obligatoria")]
		public int CategoriaId { get; set; }

	}
}
