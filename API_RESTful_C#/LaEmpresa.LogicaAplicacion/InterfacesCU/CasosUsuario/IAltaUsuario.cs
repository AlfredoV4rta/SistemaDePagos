using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaEmpresa.LogicaAplicacion.DTOs;

namespace LaEmpresa.LogicaAplicacion.InterfacesCU.CasosUsuario
{
    public interface IAltaUsuario
    {
        public void AltaUsuario(UsuarioDTO usuario);
    }
}
