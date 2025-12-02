using LaEmpresa.LogicaAplicacion.DTOs;
using LaEmpresa.LogicaAplicacion.InterfacesCU.CasosUsuario;
using LaEmpresa.LogicaNegocio.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace LaEmpresa.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ILogin _loginCU;

        public LoginController(ILogin loginCU)
        {
            _loginCU = loginCU;
        }

        /// <summary>
        /// Permite iniciar sesion, se le asigan token al usuario
        /// </summary>
        /// <param name="loginRequestDTO"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("login")]
        [ProducesResponseType(typeof(UsuarioDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public IActionResult Login([FromBody] LoginRequestDTO loginRequestDTO)
        {
            try
            {
                if (string.IsNullOrEmpty(loginRequestDTO.Email) || string.IsNullOrEmpty(loginRequestDTO.Contrasenia))
                {
                    return BadRequest("Email y contraseña son requeridos");
                }

                UsuarioDTO logueado = _loginCU.Login(loginRequestDTO.Email, loginRequestDTO.Contrasenia);
                var token = ManejadorJWT.GenerarToken(logueado);
                logueado.Token = token.ToString();
                
                return Ok(logueado);
            }
            catch (UsuarioException uex)
            {
                return Unauthorized(uex.Message);
            }
            catch
            {
                return StatusCode(500, "Ocurrió un error inesperado. Intente de nuevo más tarde.");
            }
        }
    }
}
