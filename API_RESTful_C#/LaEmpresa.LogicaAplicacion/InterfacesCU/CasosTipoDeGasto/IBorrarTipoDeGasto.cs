using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEmpresa.LogicaAplicacion.InterfacesCU.CasosTipoDeGasto
{
    public interface IBorrarTipoDeGasto
    {
        public void BorrarTipoDeGasto(int id, string email);
    }
}
