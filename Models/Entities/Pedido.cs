using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ET.Entities
{
    public class Pedido
    {
        public int Id { get; set; }

        public DateTime Fecha_Creacion { get; set; }

        public decimal Total { get; set; }

        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }

        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }

        [ForeignKey("Direccion")]
        public int DireccionId { get; set; }

        public Cliente Cliente { get; set; }
        public Usuario Usuario { get; set; }
        public Direccion Direccion { get; set; }

        public ICollection<PedidoDetalle>? PedidoDetalles { get; set; }
    }
}
