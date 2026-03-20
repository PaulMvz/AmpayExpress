using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmpayExpress.Domain.Entities
{
	public class Pedido
	{
		public int Id { get; set; }
		public int ClienteId { get; set; }
		public int ComercioId { get; set; }
		public int? RepartidorId { get; set; } // Opcional al inicio
		public DateTime FechaCreacion { get; set; } = DateTime.Now;
		public int EstadoId { get; set; } // 1: Pendiente, 2: En Camino, etc.
		public decimal Total { get; set; }

		// Propiedades de navegación
		public Usuario Cliente { get; set; } = null!;
		public Comercio Comercio { get; set; } = null!;
		public ICollection<DetallePedido> Detalles { get; set; } = new List<DetallePedido>();
	}
}
