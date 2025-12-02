using LaEmpresa.LogicaAplicacion.DTOs;
using LaEmpresa.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEmpresa.LogicaAplicacion.Mappers
{
    public class AuditoriaMapper
    {
        public static AuditoriaDTO toDTO(Auditoria auditoria)
        {
            return new AuditoriaDTO
            {
                Id = auditoria.Id,
                Email = auditoria.Email,
                Accion = auditoria.Accion,
                IdTipoDeGasto = auditoria.IdTipoDeGasto,
                Fecha = auditoria.Fecha,
            };
        }

        public static Auditoria fromDTO(AuditoriaDTO auditoriaDTO)
        {
            return new Auditoria
            {
                Id = auditoriaDTO.Id,
                Email = auditoriaDTO.Email,
                Accion = auditoriaDTO.Accion,
                IdTipoDeGasto = auditoriaDTO.IdTipoDeGasto,
                Fecha = auditoriaDTO.Fecha
            };
        }
    }
}
