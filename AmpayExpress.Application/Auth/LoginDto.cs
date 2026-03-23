using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmpayExpress.Application.Auth
{
	public class LoginDto
	{
		public string Usuario { get; set; } = null!; // El ! después del tipo de dato indica que esta propiedad no puede ser nula. Es una forma de decirle al compilador que confíe en que esta propiedad siempre tendrá un valor asignado.
		public string Password { get; set; } = null!; // El ! después del tipo de dato indica que esta propiedad no puede ser nula. Es una forma de decirle al compilador que confíe en que esta propiedad siempre tendrá un valor asignado.
	}
}
