using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmpayExpress.Infrastructure.Persistence
{
	public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
	{
		public ApplicationDbContext CreateDbContext(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

			// Usamos la cadena de conexión de tu SQLEXPRESS que vimos en la imagen
			optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=AmpayExpressDB;Trusted_Connection=True;TrustServerCertificate=True;");

			return new ApplicationDbContext(optionsBuilder.Options);
		}
	}
}
