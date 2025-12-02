using LaEmpresa.LogicaAplicacion.DTOs;
using LaEmpresa.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEmpresa.LogicaAplicacion.InterfacesCU.CasosTipoDeGasto
{
    public interface IObtenerTipoDeGasto
    {
        public IEnumerable<TipoDeGastoDTO> ObtenerTiposDeGasto();
    }
}
