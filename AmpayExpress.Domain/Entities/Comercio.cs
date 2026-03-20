using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmpayExpress.Domain.Entities
{
	public class Comercio
	{
		public int Id { get; set; }
		public string NombreComercial { get; set; } = string.Empty;
		public string RUC { get; set; } = string.Empty;
		public string Direccion { get; set; } = string.Empty;
		public int CategoriaId { get; set; }
		public Categoria Categoria { get; set; } = null!;
	}
}
