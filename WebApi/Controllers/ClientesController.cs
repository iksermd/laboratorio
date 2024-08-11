using DAL.Implementations;
using ET.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClientesController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            try
            {
                var clientes = await _clienteRepository.GetAllAsync();
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = 0, message = $"Error: {ex.Message}" });
            }
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            try
            {
                var cliente = await _clienteRepository.GetClienteWithDireccionesAsync(id);

                if (cliente == null)
                {
                    return NotFound(new { success = 0, message = "Cliente no encontrado." });
                }

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = 0, message = $"Error: {ex.Message}" });
            }
        }

        // POST: api/Clientes
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _clienteRepository.AddAsync(cliente);
                return CreatedAtAction(nameof(GetCliente), new { id = cliente.Id }, cliente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = 0, message = $"Error: {ex.Message}" });
            }
        }

        // PUT: api/Clientes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return BadRequest(new { success = 0, message = "ID de cliente no coincide." });
            }

            try
            {
                await _clienteRepository.UpdateAsync(cliente);
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ClienteExists(id))
                {
                    return NotFound(new { success = 0, message = "Cliente no encontrado." });
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

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            try
            {
                var cliente = await _clienteRepository.GetByIdAsync(id);
                if (cliente == null)
                {
                    return NotFound(new { success = 0, message = "Cliente no encontrado." });
                }

                await _clienteRepository.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = 0, message = $"Error: {ex.Message}" });
            }
        }

        private async Task<bool> ClienteExists(int id)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);
            return cliente != null;
        }
    }
}
