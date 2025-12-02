using LaEmpresa.LogicaAplicacion.InterfacesCU.CasosUsuario;
using LaEmpresa.LogicaNegocio.Entidades;
using LaEmpresa.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEmpresa.LogicaAplicacion.CasosDeUso.UsuarioCU
{
    public class ActualizarContraseniaCU: IActualizarContrasenia
    {
        private IUsuarioRepositorio _repo;

        public ActualizarContraseniaCU(IUsuarioRepositorio repo)
        {
            _repo = repo;
        }

        public string ActualizarContrasenia(int id)
        {
            Usuario usuario = _repo.FindById(id);

            if (usuario == null)
            {
                throw new Exception("Usuario no encontrado");
            }

            string nuevaContrasenia = GenerarContraseniaAleatoria();

            _repo.ActualizarContraseniaDeUsuario(id, nuevaContrasenia);

            return nuevaContrasenia;
        }

        private string GenerarContraseniaAleatoria()
        {
            string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            Random random = new Random();

            string contrasenia = "";

            for (int i = 0; i < 8; i++)
            {
                contrasenia += caracteres[random.Next(caracteres.Length)];
            }

            return contrasenia;
        }
    }
}
