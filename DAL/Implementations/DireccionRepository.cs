using DAL.Database;
using ET.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Implementations
{
    public interface IDireccionRepository : IRepository<Direccion>
    {
        Task<Direccion> GetDireccionWithClienteAsync(int id);
    }
}

namespace DAL.Implementations
{
    public class DireccionRepository : Repository<Direccion>, IDireccionRepository
    {
        public DireccionRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Direccion> GetDireccionWithClienteAsync(int id)
        {
            return await _context.Direcciones
                                 .Include(d => d.Cliente)
                                 .FirstOrDefaultAsync(d => d.Id == id);
        }
    }
}
