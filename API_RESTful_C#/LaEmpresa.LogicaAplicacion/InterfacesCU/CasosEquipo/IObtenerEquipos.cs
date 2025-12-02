using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaEmpresa.LogicaAplicacion.DTOs;


namespace LaEmpresa.LogicaAplicacion.InterfacesCU.CasosEquipo
{
    public interface IObtenerEquipos
    {
        public IEnumerable<EquipoDTO> ObtenerEquipos();
    }
}
