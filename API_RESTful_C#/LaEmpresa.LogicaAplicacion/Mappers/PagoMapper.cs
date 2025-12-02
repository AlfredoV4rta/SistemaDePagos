using LaEmpresa.AccesoDatos.Migrations;
using LaEmpresa.LogicaAplicacion.DTOs;
using LaEmpresa.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEmpresa.LogicaAplicacion.Mappers
{
    public class PagoMapper
    {
        public static Unico toUnico(PagoDTO dto)
        {
            return new Unico
            {
                Id = dto.Id,
                MetodoDePago = dto.MetodoPago,
                IdTipoGasto = dto.IdTipoDeGasto,
                IdUsuario = dto.IdUsuario,
                Descripcion = dto.Descripcion,
                Monto = dto.Monto,  
                NroRecibo = dto.NroRecibo,
                FechaDePago = dto.FechaDePago
            };
        }

        public static Recurrente toRecurrente(PagoDTO dto)
        {
            return new Recurrente
            {
                Id = dto.Id,
                MetodoDePago = dto.MetodoPago,
                IdTipoGasto = dto.IdTipoDeGasto,
                IdUsuario = dto.IdUsuario,
                Descripcion = dto.Descripcion,
                Monto = dto.Monto,
                FechaDesde = dto.FechaDesde,
                FechaHasta = dto.FechaHasta
            };
        }

        public static PagoDTO ToDTO(Pago toDto)
        {
            PagoDTO pago = new PagoDTO
            {
                Id = toDto.Id,
                MetodoPago = toDto.MetodoDePago,
                IdTipoDeGasto = toDto.IdTipoGasto,
                IdUsuario = toDto.IdUsuario,
                Descripcion = toDto.Descripcion,
                Monto = toDto.Monto,
                SaldoPendiente = toDto.CalcularSaldoPendiente(toDto.Monto),
                FechaDesde = toDto.ObtenerFechaDesde(),
                FechaHasta = toDto.ObtenerFechaHasta(),
                FechaDePago = toDto.ObtenerFechaDePago(),
                NroRecibo = toDto.ObtenerNroRecibo()
            };

            if (toDto.TipoGasto != null)
            {
                pago.TipoGasto = TipoDeGastoMapper.ToDTO(toDto.TipoGasto);
            }

            if(toDto.Usuario != null)
            {
                pago.Usuario = UsuarioMapper.ToDTO(toDto.Usuario);
            }
            
   

            return pago;
        }
    }
}
