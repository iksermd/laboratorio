using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ET.Entities
{
    public class Direccion
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Calle { get; set; }

        [Required]
        [StringLength(100)]
        public string Ciudad { get; set; }

        [Required]
        [StringLength(100)]
        public string Departamento { get; set; }


        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }

        public Cliente? Cliente { get; set; }
        public ICollection<Pedido>? Pedido { get; set; }
    }
}
