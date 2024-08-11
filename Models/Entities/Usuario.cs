using System.ComponentModel.DataAnnotations;

namespace ET.Entities
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Nombre { get; set; }

        [Required]
        [EmailAddress]
        public string Correo { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Contrasena { get; set; }
        public ICollection<Pedido>? Pedidos { get; set; }
    }
}
