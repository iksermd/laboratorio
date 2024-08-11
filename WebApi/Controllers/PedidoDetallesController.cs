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
    public class PedidoDetallesController : ControllerBase
    {
        private readonly IPedidoDetalleRepository _pedidoDetalleRepository;

        public PedidoDetallesController(IPedidoDetalleRepository pedidoDetalleRepository)
        {
            _pedidoDetalleRepository = pedidoDetalleRepository;
        }

        // GET: api/PedidoDetalles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedidoDetalle>>> GetPedidoDetalles()
        {
            var pedidoDetalles = await _pedidoDetalleRepository.GetAllAsync();
            return Ok(pedidoDetalles);
        }

        // GET: api/PedidoDetalles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PedidoDetalle>> GetPedidoDetalle(int id)
        {
            var pedidoDetalle = await _pedidoDetalleRepository.GetPedidoDetalleWithProductosAsync(id);

            if (pedidoDetalle == null)
            {
                return NotFound(new { success = 0, message = "PedidoDetalle no encontrado." });
            }

            return Ok(pedidoDetalle);
        }

        // POST: api/PedidoDetalles
        [HttpPost]
        public async Task<ActionResult<PedidoDetalle>> PostPedidoDetalle(PedidoDetalle pedidoDetalle)
        {
            try
            {
                await _pedidoDetalleRepository.AddAsync(pedidoDetalle);
                return CreatedAtAction(nameof(GetPedidoDetalle), new { id = pedidoDetalle.Id }, pedidoDetalle);
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = 0, message = $"Error: {ex.Message}" });
            }
        }

        // PUT: api/PedidoDetalles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedidoDetalle(int id, PedidoDetalle pedidoDetalle)
        {
            if (id != pedidoDetalle.Id)
            {
                return BadRequest(new { success = 0, message = "ID de PedidoDetalle no coincide." });
            }

            try
            {
                await _pedidoDetalleRepository.UpdateAsync(pedidoDetalle);
                return NoContent();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!await PedidoDetalleExists(id))
                {
                    return NotFound(new { success = 0, message = "PedidoDetalle no encontrado." });
                }
                else
                {
                    return BadRequest(new { success = 0, message = $"Error de concurrencia: {ex.Message}" });
                }
            }
        }

        // DELETE: api/PedidoDetalles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedidoDetalle(int id)
        {
            try
            {
                var pedidoDetalle = await _pedidoDetalleRepository.GetByIdAsync(id);
                if (pedidoDetalle == null)
                {
                    return NotFound(new { success = 0, message = "PedidoDetalle no encontrado." });
                }

                await _pedidoDetalleRepository.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = 0, message = $"Error: {ex.Message}" });
            }
        }

        private async Task<bool> PedidoDetalleExists(int id)
        {
            var pedidoDetalle = await _pedidoDetalleRepository.GetByIdAsync(id);
            return pedidoDetalle != null;
        }
    }
}
