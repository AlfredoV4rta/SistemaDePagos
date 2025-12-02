using LaEmpresa.LogicaAplicacion.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LaEmpresa.LogicaAplicacion.InterfacesCU.CasosPago;
using LaEmpresa.LogicaNegocio.Exceptions;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace LaEmpresa.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoController : ControllerBase
    {
        private IObtenerPagosDeUsuario _obtenerPagosDeUsuario;
        private IObtenerEquiposMayorMonto _obtenerEquiposMayorMonto;
        private IAltaPago _altaPago;

        public PagoController(
                IObtenerPagosDeUsuario obtenerPagosDeUsuario,
                IObtenerEquiposMayorMonto obtenerEquiposMayorMonto,
                IAltaPago altaPago)
        {
            _obtenerPagosDeUsuario = obtenerPagosDeUsuario;
            _obtenerEquiposMayorMonto = obtenerEquiposMayorMonto;
            _altaPago = altaPago;
        }
        /// <summary>
        /// Dado un id de usuario devuelve los pagos del mismo, solo funciona con el id el usuario logueado
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        [HttpGet("pagos/usuario/{idUsuario}")]
        [ProducesResponseType(typeof(PagoDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public IActionResult PagosDeUsuario(int idUsuario)
        {
            try
            {
                Claim rolClaim = User.FindFirst(ClaimTypes.Role);

                if (rolClaim == null || rolClaim.Value != "Gerente" || rolClaim.Value != "Empleado")
                {
                    return Unauthorized("Solo los gerentes o empleados pueden acceder a este recurso");
                }

                int idUsuarioToken = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

                if (idUsuario <= 0)
                {
                    return BadRequest("Id no valido");
                }

                if (idUsuario != idUsuarioToken)
                {
                    return Unauthorized("El id debe ser igual a tu propio id");
                }

                IEnumerable<PagoDTO> pagos = _obtenerPagosDeUsuario.ObtenerPagosDeUsuario(idUsuario);
                return Ok(pagos);
            }
            catch (PagoException pe)
            {
                return NotFound(pe.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error");
            }
        }
        
        /// <summary>
        /// Devuelve los equipos, en los cuales algun usuario hizo un pago mayor a un monto determinado
        /// </summary>
        /// <param name="monto"></param>
        /// <returns></returns>
        [HttpGet("pagos/equipo/{monto}")]
        [ProducesResponseType(typeof(EquipoDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public IActionResult PagosMayorMontoEquipo(double monto)
        {
            try
            {
                Claim rolClaim = User.FindFirst(ClaimTypes.Role);

                if (rolClaim == null || rolClaim.Value != "Gerente")
                {
                    return Unauthorized("Solo los gerentes pueden acceder a este recurso");
                }

                if (monto <= 0)
                {
                    return BadRequest("El monto debe ser mayor a cero");
                }

                IEnumerable<EquipoDTO> equipos = _obtenerEquiposMayorMonto.ObtenerEquiposMayorMonto(monto);
                return Ok(equipos);
            }
            catch (EquipoException ee)
            {
                return NotFound(ee.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error");
            }
        }
        /// <summary>
        /// Agrega un pago unico
        /// </summary>
        /// <param name="pagoDTO"></param>
        /// <returns></returns>
        [HttpPost("pagos/alta/unico")]
        [ProducesResponseType(typeof(PagoDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]

        public IActionResult AltaPagoUnico([FromBody] PagoDTO pagoDTO)
        {
            try
            {
                if (pagoDTO == null || pagoDTO.FechaDePago == DateTime.MinValue)
                {
                    return BadRequest("No se creo el pago");
                }

                _altaPago.AltaPago(pagoDTO);
                return Ok();
            }
            catch (PagoException pe)
            {
                return BadRequest(pe.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error");
            }
        }
        /// <summary>
        /// Agrega un pago recurrente
        /// </summary>
        /// <param name="pagoDTO"></param>
        /// <returns></returns>
        [HttpPost("pagos/alta/recurrente")]
        [ProducesResponseType(typeof(PagoDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public IActionResult AltaPagoRecurrente([FromBody] PagoDTO pagoDTO)
        {
            try
            {
                if (pagoDTO == null || pagoDTO.FechaDesde == DateTime.MinValue || pagoDTO.FechaHasta == DateTime.MinValue)
                {
                    return BadRequest("No se creo el pago");
                }
                _altaPago.AltaPago(pagoDTO);
                return Ok();
            }
            catch (PagoException pe)
            {
                return BadRequest(pe.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error");
            }
        }
    }
}
