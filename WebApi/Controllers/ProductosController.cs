using DAL.Implementations;
using ET.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IProductoRepository _Repository;


        public ProductosController(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        // GET: api/Productos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
        {
            try
            {
                var productos = await _productoRepository.GetAllAsync();
                return Ok(productos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = 0, message = $"Error: {ex.Message}" });
            }
        }

        // GET: api/Productos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            try
            {
                var producto = await _productoRepository.GetByIdAsync(id);

                if (producto == null)
                {
                    return NotFound(new { success = 0, message = "Producto no encontrado." });
                }

                return Ok(producto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = 0, message = $"Error: {ex.Message}" });
            }
        }

        // POST: api/Productos
        [HttpPost]
        public async Task<ActionResult<Producto>> PostProducto(Producto producto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _productoRepository.AddAsync(producto);
                return CreatedAtAction(nameof(GetProducto), new { id = producto.Id }, producto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = 0, message = $"Error: {ex.Message}" });
            }
        }

        // PUT: api/Productos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, Producto producto)
        {
            if (id != producto.Id)
            {
                return BadRequest(new { success = 0, message = "ID de producto no coincide." });
            }

            try
            {
                await _productoRepository.UpdateAsync(producto);
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ProductoExists(id))
                {
                    return NotFound(new { success = 0, message = "Producto no encontrado." });
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = 0, message = $"Error: {ex.Message}" });
            }
        }

        // DELETE: api/Productos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            try
            {
                var producto = await _productoRepository.GetByIdAsync(id);
                if (producto == null)
                {
                    return NotFound(new { success = 0, message = "Producto no encontrado." });
                }

                await _productoRepository.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = 0, message = $"Error: {ex.Message}" });
            }
        }

        private async Task<bool> ProductoExists(int id)
        {
            var producto = await _productoRepository.GetByIdAsync(id);
            return producto != null;
        }
    }
}
