using LaEmpresa.LogicaAplicacion.DTOs;
using LaEmpresa.LogicaAplicacion.InterfacesCU.CasosTipoDeGasto;
using LaEmpresa.LogicaNegocio.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LaEmpresa.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDeGastoController: ControllerBase
    {
        private IAltaTipoDeGasto _altaTipoDeGasto;
        private IBorrarTipoDeGasto _borrarTipoDeGasto;
        private IEditarTipoDeGasto _editarTipoDeGasto;
        private IObtenerTipoDeGastoPorId _obtenerTipoDeGastoPorId;
        private IObtenerTipoDeGasto _obtenerTipoDeGasto;

        public TipoDeGastoController(
                IAltaTipoDeGasto altaTipoDeGasto, 
                IBorrarTipoDeGasto borrarTipoDeGasto, 
                IEditarTipoDeGasto editarTipoDeGasto, 
                IObtenerTipoDeGastoPorId obtenerTipoDeGastoPorId, 
                IObtenerTipoDeGasto obtenerTipoDeGasto)
        {
            _altaTipoDeGasto = altaTipoDeGasto;
            _borrarTipoDeGasto = borrarTipoDeGasto;
            _editarTipoDeGasto = editarTipoDeGasto;
            _obtenerTipoDeGastoPorId = obtenerTipoDeGastoPorId;
            _obtenerTipoDeGasto = obtenerTipoDeGasto;
        }

        /// <summary>
        /// Devuelve todos los tipos de gasto
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(TipoDeGastoDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public IActionResult ObtenerTiposDeGasto()
        {
            try
            {
                Claim rolClaim = User.FindFirst(ClaimTypes.Role);

                if (rolClaim == null)
                {
                    return Unauthorized("Solo los administradores pueden acceder a este recurso");
                }

                IEnumerable<TipoDeGastoDTO> tiposDeGasto = _obtenerTipoDeGasto.ObtenerTiposDeGasto();

                return Ok(tiposDeGasto);
            }
            catch (TipoDeGastoException te)
            {
                return NotFound(te.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error");
            }    
        }
        /// <summary>
        /// Dado un id devuelve el tipo de gasto correspondiente
        /// </summary>
        /// <param name="idTipoDeGasto"></param>
        /// <returns></returns>

        [HttpGet("{idTipoDeGasto}")]
        [ProducesResponseType(typeof(TipoDeGastoDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public IActionResult ObtenerTipoDeGastoPorId(int idTipoDeGasto)
        {
            try
            {
                if (idTipoDeGasto <= 0)
                {
                    return BadRequest("Id tiene que ser mayor a 0");
                }

                Claim rolClaim = User.FindFirst(ClaimTypes.Role);

                if (rolClaim == null || rolClaim.Value != "Administrador")
                {
                    return Unauthorized("Solo los administradores pueden acceder a este recurso");
                }

                TipoDeGastoDTO tipo = _obtenerTipoDeGastoPorId.ObtenerTipoDeGastoPorId(idTipoDeGasto);
                return Ok(tipo);
            }
            catch (TipoDeGastoException te)
            {
                return NotFound(te.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error");
            }
        }
        /// <summary>
        /// Agrega un tipo de gasto
        /// </summary>
        /// <param name="tipoDeGastoCreateDto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        
        public IActionResult AltaTipoDeGasto([FromBody] TipoDeGastoCreateDTO tipoDeGastoCreateDto)
        {
            try
            {
                Claim rolClaim = User.FindFirst(ClaimTypes.Role);
                Claim emailClaim = User.FindFirst(ClaimTypes.Email);
                string email = emailClaim.Value;

                if (rolClaim == null || rolClaim.Value != "Administrador")
                {
                    return Unauthorized("Solo los administradores pueden acceder a este recurso");
                }

                if (tipoDeGastoCreateDto == null)
                {
                    return BadRequest("Tipo de gasto invalido");
                }

                TipoDeGastoDTO tipoDeGastoDto = new TipoDeGastoDTO
                {
                    Nombre = tipoDeGastoCreateDto.Nombre,
                    Descripcion = tipoDeGastoCreateDto.Descripcion
                };

                _altaTipoDeGasto.AgregarTipoDeGasto(tipoDeGastoDto, email);

                return StatusCode(201);

            }
            catch (TipoDeGastoException te)
            {
                return BadRequest(te.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error");
            }
        }
        /// <summary>
        /// Mediante un id dado, elimina el tipo de gasto asociado.
        /// </summary>
        /// <param name="idTipoDeGasto"></param>
        /// <returns></returns>
        [HttpDelete("delete/{idTipoDeGasto}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]

        public IActionResult BorrarTipoDeGasto(int idTipoDeGasto)
        {
            try
            {
                if (idTipoDeGasto <= 0)
                {
                    return BadRequest("Id tiene que ser mayor a 0");
                }

                Claim rolClaim = User.FindFirst(ClaimTypes.Role);
                Claim emailClaim = User.FindFirst(ClaimTypes.Email);
                string email = emailClaim.Value;

                if (rolClaim == null || rolClaim.Value != "Administrador")
                {
                    return Unauthorized("Solo los administradores pueden acceder a este recurso");
                }

                _borrarTipoDeGasto.BorrarTipoDeGasto(idTipoDeGasto, email);

                return Ok();
            }
            catch (TipoDeGastoException te)
            {
                return NotFound(te.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error");
            }
        }

        /// <summary>
        /// Edita el tipo de gasto del id indicado
        /// </summary>
        /// <param name="tipoDeGastoDto"></param>
        /// <param name="idTipoDeGasto"></param>
        /// <returns></returns>
        [HttpPut("{idTipoDeGasto}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]

        public IActionResult EditarTipoDeGasto([FromBody] TipoDeGastoDTO tipoDeGastoDto, int idTipoDeGasto)
        {
            try
            {
                if (idTipoDeGasto <= 0)
                {
                    return BadRequest("Id tiene que ser mayor a 0");
                }

                if (tipoDeGastoDto == null)
                {
                    return BadRequest("Tipo de gasto invalido");
                }


                Claim rolClaim = User.FindFirst(ClaimTypes.Role);
                Claim emailClaim = User.FindFirst(ClaimTypes.Email);
                string email = emailClaim.Value;

                if (rolClaim == null || rolClaim.Value != "Administrador")
                {
                    return Unauthorized("Solo los administradores pueden acceder a este recurso");
                }

                tipoDeGastoDto.Id = idTipoDeGasto;

                _editarTipoDeGasto.EditarTipoDeGasto(tipoDeGastoDto, email);

                return Ok();
            }
            catch (TipoDeGastoException te)
            {
                return NotFound(te.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error");
            }
        }
    }
}
