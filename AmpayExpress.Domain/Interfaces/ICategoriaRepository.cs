using AmpayExpress.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmpayExpress.Domain.Interfaces
{
	public interface ICategoriaRepository
	{
		Task<Categoria?> ObtenerPorIdAsync(int id);
	}
}
