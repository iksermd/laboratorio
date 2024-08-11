using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ET.DTO;
using DAL.Implementations;
using ET.Entities;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly JwtService _jwtService;

        public AuthController(IUsuarioRepository usuarioRepository, JwtService jwtService)
        {
            _usuarioRepository = usuarioRepository;
            _jwtService = jwtService;
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar([FromBody] CrearUsuario usuarioDto)
        {
            try
            {
                // Validar si el modelo es válido
                if (!ModelState.IsValid)
                {
                    throw new Exception("Modelo no válido.");
                }

                // Validar si el correo ya existe
                var existingUser = await _usuarioRepository.GetByCorreoAsync(usuarioDto.Correo);
                if (existingUser != null)
                {
                    throw new Exception("El correo ya se había registrado anteriormente.");
                }

                // Validar que los campos no estén vacíos
                if (string.IsNullOrWhiteSpace(usuarioDto.Nombre) ||
                    string.IsNullOrWhiteSpace(usuarioDto.Correo) ||
                    string.IsNullOrWhiteSpace(usuarioDto.Contrasena))
                {
                    throw new Exception("Todos los campos son obligatorios.");
                }

                // Validar que la contraseña tenga al menos 4 caracteres
                if (usuarioDto.Contrasena.Length < 4)
                {
                    throw new Exception("La contraseña debe tener al menos 4 caracteres.");
                }

                // Crear el nuevo usuario
                var usuario = new Usuario
                {
                    Nombre = usuarioDto.Nombre,
                    Correo = usuarioDto.Correo,
                    Contrasena = BCrypt.Net.BCrypt.HashPassword(usuarioDto.Contrasena)
                };

                await _usuarioRepository.AddAsync(usuario);

                return Ok(new { success = 1, message = "Usuario registrado con éxito" });
            }
            catch (Exception ex)
            {
                return Ok(new { success = 0, message = $"Error: {ex.Message}" });
            }
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Login loginDto)
        {
            try
            {
                var usuario = await _usuarioRepository.GetByCorreoAsync(loginDto.Correo);

                if (usuario == null || !BCrypt.Net.BCrypt.Verify(loginDto.Contrasena, usuario.Contrasena))
                {
                    throw new Exception( "Correo o contraseña incorrectos" );
                }

                var token = _jwtService.GenerarToken(usuario);

                return Ok(new { success = 1, token });
            }
            catch (Exception ex)
            {
                return Ok(new { success = 0, message = $"Error: {ex.Message}" });
            }
        }

    }
}
