using LaEmpresa.LogicaAplicacion.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEmpresa.LogicaAplicacion.InterfacesCU.CasosPago
{
    public interface IObtenerPagosMensuales
    {
        public IEnumerable<PagoDTO> ObtenerPagosMensuales(int mes, int anio);
    }
}
