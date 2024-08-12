using DAL.Database;
using ET.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public interface IPedidoDetalleRepository : IRepository<PedidoDetalle>
    {
        Task<PedidoDetalle> GetPedidoDetalleWithProductosAsync(int id);

    }

    public class PedidoDetalleRepository : Repository<PedidoDetalle>, IPedidoDetalleRepository
    {
        public PedidoDetalleRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<PedidoDetalle> GetPedidoDetalleWithProductosAsync(int id)
        {
            return await _context.PedidoDetalles
                                 .Include(c => c.Producto)
                                 .FirstOrDefaultAsync(c => c.Id == id);

        }
        public async Task<PedidoDetalle> GetPedidoDetalleByPedidoAsync(int id)
        {
            return await _context.PedidoDetalles
                                 .Include(c => c.Producto)
                                 .FirstOrDefaultAsync(c => c.Id == id);

        }
    }

}
