using LaEmpresa.LogicaAplicacion.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEmpresa.LogicaAplicacion.InterfacesCU.CasosAuditoria
{
    public interface IObtenerAuditoriasTipoDeGasto
    {
        public IEnumerable<AuditoriaDTO> ObtenerAuditoriasIdTipoGasto(int id);
    }
}
