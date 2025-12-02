using LaEmpresa.LogicaAplicacion.DTOs;
using LaEmpresa.LogicaAplicacion.InterfacesCU.CasosUsuario;
using LaEmpresa.LogicaNegocio.Entidades;
using LaEmpresa.LogicaNegocio.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LaEmpresa.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IActualizarContrasenia _actualizarContrasenia;
        private IObtenerUsuarios _obtenerUsuarios;

        public UsuarioController(IActualizarContrasenia actualizarContrasenia, IObtenerUsuarios obtenerUsuarios)
        {
            _actualizarContrasenia = actualizarContrasenia;
            _obtenerUsuarios = obtenerUsuarios;
        }
        /// <summary>
        /// Actuliza la contraseña de un usuario, mediante su id. Devuelve la contraseña nueva.
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        [HttpPut("{idUsuario}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        public IActionResult ActualizarContrasenia(int idUsuario)
        {
            try
            {
                if (idUsuario <= 0)
                {
                    return BadRequest("Id tiene que ser mayor a 0");
                }

                Claim rolClaim = User.FindFirst(ClaimTypes.Role);

                if (rolClaim == null || rolClaim.Value != "Administrador")
                {
                    return Unauthorized("Solo los administradores pueden acceder a este recurso");
                }

                string nuevaContrasenia = _actualizarContrasenia.ActualizarContrasenia(idUsuario);
                return Ok($"La nueva contrasenia es: {nuevaContrasenia}");
            }
            catch(UsuarioException pe)
            {
                return NotFound(pe.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error");
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        public IActionResult ObtenerUsuarios()
        {
            try
            {
                Claim rolClaim = User.FindFirst(ClaimTypes.Role);

                if (rolClaim == null || rolClaim.Value != "Administrador")
                {
                    return Unauthorized("Solo los administradores pueden acceder a este recurso");
                }

                IEnumerable<UsuarioDTO> usuarios = _obtenerUsuarios.ObtenerUsuarios();
                return Ok(usuarios);
            }
            catch (UsuarioException pe)
            {
                return NotFound(pe.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error");
            }
        }
    }
}
