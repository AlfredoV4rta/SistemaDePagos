using LaEmpresa.LogicaAplicacion.DTOs;
using LaEmpresa.LogicaAplicacion.InterfacesCU.CasosUsuario;
using LaEmpresa.LogicaAplicacion.Mappers;
using LaEmpresa.LogicaNegocio.Entidades;
using LaEmpresa.LogicaNegocio.Exceptions;
using LaEmpresa.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEmpresa.LogicaAplicacion.CasosDeUso.UsuarioCU
{
    public class ObtenerUsuariosCU : IObtenerUsuarios
    {
        private IUsuarioRepositorio _repositorio;

        public ObtenerUsuariosCU(IUsuarioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public IEnumerable<UsuarioDTO> ObtenerUsuarios()
        {
            IEnumerable<Usuario> usuarios = _repositorio.FindAll();

            if (usuarios.Count() == 0)
            {
                throw new UsuarioException("No hay usuarios en el sistema");
            }

            return usuarios.Select(
                user => UsuarioMapper.ToDTO(user)
            );
        }
    }
}
