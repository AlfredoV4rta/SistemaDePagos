using LaEmpresa.LogicaAplicacion.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEmpresa.LogicaAplicacion.InterfacesCU.CasosUsuario
{
    public interface IObtenerUsuarios
    {
        public IEnumerable<UsuarioDTO> ObtenerUsuarios();
    }
}
