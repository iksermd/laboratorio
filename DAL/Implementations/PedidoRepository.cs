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
    public interface IPedidoRepository : IRepository<Pedido>
    {
        Task<Pedido> GetPedidoWithPedidoDetallesAsync(int id);
    }

    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Pedido> GetPedidoWithPedidoDetallesAsync(int id)
        {
            return await _context.Pedidos
                                 .Include(c => c.PedidoDetalles)
                                 .FirstOrDefaultAsync(c => c.Id == id);

        }
    }

}
