using ET.Entities;
using DAL.Implementations;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidosController(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        // GET: api/Pedidos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetPedidos()
        {
            var pedidos = await _pedidoRepository.GetAllAsync();
            return Ok(pedidos);
        }

        // GET: api/Pedidos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> GetPedido(int id)
        {
            var pedido = await _pedidoRepository.GetPedidoWithPedidoDetallesAsync(id);

            if (pedido == null)
            {
                return NotFound(new { success = 0, message = "Pedido no encontrado." });
            }

            return Ok(pedido);
        }

        // POST: api/Pedidos
        [HttpPost]
        public async Task<ActionResult<Pedido>> PostPedido(Pedido pedido)
        {
            try
            {
                await _pedidoRepository.AddAsync(pedido);
                return CreatedAtAction(nameof(GetPedido), new { id = pedido.Id }, pedido);
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = 0, message = $"Error: {ex.Message}" });
            }
        }

        // PUT: api/Pedidos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedido(int id, Pedido pedido)
        {
            if (id != pedido.Id)
            {
                return BadRequest(new { success = 0, message = "ID de pedido no coincide." });
            }

            try
            {
                await _pedidoRepository.UpdateAsync(pedido);
                return NoContent();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!await PedidoExists(id))
                {
                    return NotFound(new { success = 0, message = "Pedido no encontrado." });
                }
                else
                {
                    return BadRequest(new { success = 0, message = $"Error de concurrencia: {ex.Message}" });
                }
            }
        }

        // DELETE: api/Pedidos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedido(int id)
        {
            try
            {
                var pedido = await _pedidoRepository.GetByIdAsync(id);
                if (pedido == null)
                {
                    return NotFound(new { success = 0, message = "Pedido no encontrado." });
                }

                await _pedidoRepository.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = 0, message = $"Error: {ex.Message}" });
            }
        }

        private async Task<bool> PedidoExists(int id)
        {
            var pedido = await _pedidoRepository.GetByIdAsync(id);
            return pedido != null;
        }
    }
}
