using LaEmpresa.LogicaAplicacion.DTOs;
using LaEmpresa.LogicaAplicacion.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEmpresa.LogicaAplicacion.InterfacesCU.CasosTipoDeGasto
{
    public interface IObtenerTipoDeGastoPorId
    {
        public TipoDeGastoDTO ObtenerTipoDeGastoPorId(int id);
    }
}
