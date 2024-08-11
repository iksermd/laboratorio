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
    public class DireccionesController : ControllerBase
    {
        private readonly IDireccionRepository _direccionRepository;

        public DireccionesController(IDireccionRepository direccionRepository)
        {
            _direccionRepository = direccionRepository;
        }

        // GET: api/Direcciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Direccion>>> GetDirecciones()
        {
            try
            {
                var direcciones = await _direccionRepository.GetAllAsync();
                return Ok(direcciones);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = 0, message = $"Error: {ex.Message}" });
            }
        }

        // GET: api/Direcciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Direccion>> GetDireccion(int id)
        {
            try
            {
                var direccion = await _direccionRepository.GetDireccionWithClienteAsync(id);

                if (direccion == null)
                {
                    return NotFound(new { success = 0, message = "Dirección no encontrada." });
                }

                return Ok(direccion);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = 0, message = $"Error: {ex.Message}" });
            }
        }

        // POST: api/Direcciones
        [HttpPost]
        public async Task<ActionResult<Direccion>> PostDireccion(Direccion direccion)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _direccionRepository.AddAsync(direccion);
                return CreatedAtAction(nameof(GetDireccion), new { id = direccion.Id }, direccion);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = 0, message = $"Error: {ex.Message}" });
            }
        }

        // PUT: api/Direcciones/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDireccion(int id, Direccion direccion)
        {
            if (id != direccion.Id)
            {
                return BadRequest(new { success = 0, message = "ID de dirección no coincide." });
            }

            try
            {
                await _direccionRepository.UpdateAsync(direccion);
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await DireccionExists(id))
                {
                    return NotFound(new { success = 0, message = "Dirección no encontrada." });
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

        // DELETE: api/Direcciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDireccion(int id)
        {
            try
            {
                var direccion = await _direccionRepository.GetByIdAsync(id);
                if (direccion == null)
                {
                    return NotFound(new { success = 0, message = "Dirección no encontrada." });
                }

                await _direccionRepository.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = 0, message = $"Error: {ex.Message}" });
            }
        }

        private async Task<bool> DireccionExists(int id)
        {
            var direccion = await _direccionRepository.GetByIdAsync(id);
            return direccion != null;
        }
    }
}
