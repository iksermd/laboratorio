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
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<Cliente> GetClienteWithDireccionesAsync(int id);
    }

    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Cliente> GetClienteWithDireccionesAsync(int id)
        {
            return await _context.Clientes
                                 .Include(c => c.Direcciones)
                                 .FirstOrDefaultAsync(c => c.Id == id);

        }
    }
    
}
