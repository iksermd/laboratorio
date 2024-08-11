using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ET.DTOs
{
    public class PedidoDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Nombre { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        public ICollection<ProductoDTO>? Productos { get; set; }
    }

    public class CreatePedidoDTO
    {
        [Required]
        [StringLength(200)]
        public string Nombre { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        public ICollection<int>? ProductosIds { get; set; }
    }

    public class UpdatePedidoDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Nombre { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        public ICollection<int>? ProductosIds { get; set; }
    }

    public class ProductoDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        public string? Descripcion { get; set; }

        public int Cantidad { get; set; }

        public decimal Precio { get; set; }

        public decimal ISV { get; set; }
    }
}
