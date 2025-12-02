using LaEmpresa.LogicaAplicacion.DTOs;
using LaEmpresa.LogicaAplicacion.InterfacesCU.CasosAuditoria;
using LaEmpresa.LogicaAplicacion.Mappers;
using LaEmpresa.LogicaNegocio.Entidades;
using LaEmpresa.LogicaNegocio.Exceptions;
using LaEmpresa.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEmpresa.LogicaAplicacion.CasosDeUso.AuditoriaCU
{
    public class ObtenerAuditoriasTipoDeGastoIdCU: IObtenerAuditoriasTipoDeGasto
    {
        private IAuditoriaRepositorio _obtenerAuditoriaTipoDeGasto;

        public ObtenerAuditoriasTipoDeGastoIdCU( IAuditoriaRepositorio obtenerAuditoriaTipoDeGasto)
        {
            _obtenerAuditoriaTipoDeGasto = obtenerAuditoriaTipoDeGasto;
        }

        public IEnumerable<AuditoriaDTO> ObtenerAuditoriasIdTipoGasto(int id)
        {
            IEnumerable<Auditoria> toReturn = _obtenerAuditoriaTipoDeGasto.ObtenerAuditoriasTipoDeGasto(id);

            if (toReturn == null || toReturn.Count() == 0)
            {
                throw new AuditoriaException("No hay auditorias para este tipo de gasto");
            }

            return toReturn.Select(auditoria => AuditoriaMapper.toDTO(auditoria));
        }
    }
}
