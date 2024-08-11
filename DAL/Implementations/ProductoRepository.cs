
using DAL.Database;
using ET.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Implementations
{
    public interface IProductoRepository : IRepository<Producto>
    {

    }
}


namespace DAL.Implementations
{
    public class ProductoRepository : Repository<Producto>, IProductoRepository
    {
        public ProductoRepository(AppDbContext context) : base(context)
        {
        }


    }
}
