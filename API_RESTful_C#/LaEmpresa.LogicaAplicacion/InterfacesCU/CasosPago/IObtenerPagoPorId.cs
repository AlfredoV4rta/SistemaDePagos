using LaEmpresa.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaEmpresa.LogicaAplicacion.DTOs;

namespace LaEmpresa.LogicaAplicacion.InterfacesCU.CasosPago
{
    public interface IObtenerPagoPorId
    {
        public PagoDTO ObtenerPagoPorId(int id);
    }
}
