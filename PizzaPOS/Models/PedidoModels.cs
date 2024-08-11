using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaPOS.Models
{
    public class PedidoModel
    {
        public int Id { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public decimal Total { get; set; }
        public int ClienteId { get; set; }
        public int UsuarioId { get; set; }
        public int DireccionId { get; set; }
    }

    public class PedidoDetalleModel
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public int PedidoId { get; set; }
        public int ProductoId { get; set; }
    }

    public class ProductoModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public decimal ISV { get; set; }
    }
}
