using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmpayExpress.Application.DTOs
{
	public class ComercioDto
	{
		public int Id { get; set; }
		public string NombreComercial { get; set; } = null!;
		public string RUC { get; set; } = null!;
		public string Direccion { get; set; } = null!;
		public bool EstadoAbierto { get; set; }
		public String CategoriaNombre { get; set; } = null!;// Aquí aplanamos la relación
	}
}
