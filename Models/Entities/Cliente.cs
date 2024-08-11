using System.ComponentModel.DataAnnotations;

namespace ET.Entities
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }


        [Required]
        [StringLength(15)]
        public string Telefono { get; set; }
        public ICollection<Direccion>? Direcciones { get; set; }
        public ICollection<Pedido>? Pedido { get; set; }


    }
}
