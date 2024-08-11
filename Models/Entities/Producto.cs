using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ET.Entities
{
public class Producto
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Nombre { get; set; }

    public string? Descripcion { get; set; }
    public decimal Precio { get; set; }
    public decimal ISV { get; set; }

    public ICollection<PedidoDetalle>? PedidoDetalles { get; set; }
}
}
