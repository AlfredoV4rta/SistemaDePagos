using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaEmpresa.LogicaAplicacion.DTOs;
using LaEmpresa.LogicaNegocio.InterfacesRepositorio;

namespace LaEmpresa.LogicaAplicacion.InterfacesCU.CasosPago
{
    public interface IObtenerEquiposMayorMonto
    {
        public IEnumerable<EquipoDTO> ObtenerEquiposMayorMonto(double monto);
    }
}
