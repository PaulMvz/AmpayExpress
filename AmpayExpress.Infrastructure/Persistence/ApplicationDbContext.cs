using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
//Extensiones
using AmpayExpress.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace AmpayExpress.Infrastructure.Persistence
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

		// Add DbSet properties for your entities here
		public DbSet<Usuario> Usuarios { get; set; } = null!;
		public DbSet<Categoria> Categorias { get; set; } = null!;
		public DbSet<Comercio> Comercios { get; set; } = null!;
		public DbSet<Producto> Productos { get; set; } = null!;
		public DbSet<Pedido> Pedidos { get; set; } = null!;
		public DbSet<DetallePedido> DetallesPedidos { get; set; } = null!;

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			// Aqui configuraremos nombres de tablas o relaciones complejas para más adelante

			// Configuraciones de precisión
			modelBuilder.Entity<Producto>().Property(p => p.Precio).HasColumnType("decimal(18,2)");
			modelBuilder.Entity<Pedido>().Property(p => p.Total).HasColumnType("decimal(18,2)");
			modelBuilder.Entity<DetallePedido>().Property(d => d.PrecioUnitario).HasColumnType("decimal(18,2)");

			// SOLUCIÓN DEFINITIVA PARA SQL SERVER
			// Desactivamos el borrado en cascada para TODAS las relaciones
			foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
			{
				relationship.DeleteBehavior = DeleteBehavior.Restrict;
			}
		}
	}
}
