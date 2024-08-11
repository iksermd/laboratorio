
using ET.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Pedido>()
            //    .HasOne(p => p.Cliente)
            //    .WithMany(c => c.Pedidos)
            //    .HasForeignKey(p => p.ClienteId)
            //    .OnDelete(DeleteBehavior.Restrict); // O Disable la cascada

            //modelBuilder.Entity<Pedido>()
            //    .HasOne(p => p.Usuario)
            //    .WithMany(u => u.Pedidos)
            //    .HasForeignKey(p => p.UsuarioId)
            //    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Direccion)
                .WithMany(d => d.Pedido)
                .HasForeignKey(p => p.DireccionId)
                .OnDelete(DeleteBehavior.Restrict);
        }


        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoDetalle> PedidoDetalles { get; set; }
        public DbSet<Producto> Productos { get; set; }


    }
}

