using LaEmpresa.LogicaAplicacion.DTOs;
using LaEmpresa.LogicaAplicacion.InterfacesCU.CasosUsuario;
using LaEmpresa.LogicaAplicacion.Mappers;
using LaEmpresa.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEmpresa.LogicaAplicacion.CasosDeUso.UsuarioCU
{
    public class LoginCU : ILogin
    {
        private IUsuarioRepositorio _repositorio;

        public LoginCU(IUsuarioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }
        
        public UsuarioDTO Login(string email, string password)
        {
            return UsuarioMapper.ToDTO(_repositorio.Login(email.ToLower(), password));
        }
    }
}
