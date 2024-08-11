using DAL.Database;
using ET.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<Usuario> GetByCorreoAsync(string correo);
    }

    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Usuario> GetByCorreoAsync(string correo)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.Correo == correo);
        }
    }
}
