using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmpayExpress.Domain.Entities
{
	public class Usuario
	{
		public int Id { get; set; }
		public string Nombre { get; set; } = string.Empty;
		public string Apellido { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public string PasswordHash { get; set; } = string.Empty;
		public int RolId { get; set; } // 1:Cliente, 2:Repartidor, 3:Comercio, 4:Admin
	}
}
