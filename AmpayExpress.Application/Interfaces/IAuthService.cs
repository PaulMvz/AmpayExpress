using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmpayExpress.Application.Interfaces
{
	public interface IAuthService
	{
		String GenerateToken(string usuario, string rol);
	}
}
