using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ET.Entities
{
    public class PedidoDetalle
    {
        public int Id { get; set; }

        public int Cantidad { get; set; }

        [ForeignKey("Pedido")]
        public int PedidoId { get; set; }

        [ForeignKey("Producto")]
        public int ProductoId { get; set; }

        public Pedido Pedido { get; set; }
        public Producto Producto { get; set; }
    }
}
