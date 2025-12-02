using LaEmpresa.LogicaAplicacion.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEmpresa.LogicaAplicacion.InterfacesCU.CasosTipoDeGasto
{
    public interface IAltaTipoDeGasto
    {
        public void AgregarTipoDeGasto(TipoDeGastoDTO nuevoTipoGasto, string email);
    }
}
