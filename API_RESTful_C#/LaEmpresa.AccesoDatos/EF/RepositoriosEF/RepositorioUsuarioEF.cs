using LaEmpresa.LogicaNegocio.Entidades;
using LaEmpresa.LogicaNegocio.Exceptions;
using LaEmpresa.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEmpresa.AccesoDatos.EF.RepositoriosEF
{
    public class RepositorioUsuarioEF : IUsuarioRepositorio
    {
        private LaEmpresaContext _context;

        public RepositorioUsuarioEF(LaEmpresaContext context)
        {
            _context = context;
        }

        public string ActualizarContraseniaDeUsuario(int id, string contrasenia)
        {
            Usuario usuario = FindById(id);

            if (usuario == null)
            {
                throw new UsuarioException("No hay usuario con ese id");
            }

            usuario.Contrasenia = contrasenia;
            Update(usuario);
            return contrasenia;
        }

        public void Add(Usuario obj)
        {
            obj.Validar();
            _context.Add(obj);
            _context.SaveChanges();
        }

        public IEnumerable<Usuario> FindAll()
        {
            return _context.Usuarios.OrderBy(user => user.NombreCompleto.Nombre).ToList();
        }

        public Usuario FindbyEmail(string email)
        {
            return _context.Usuarios.Where(user => user.Email.Email == email)
                .FirstOrDefault();
        }

        public Usuario FindById(int id)
        {
            Usuario usuario = _context.Usuarios.Where(u => u.Id == id).FirstOrDefault();

            if (usuario == null)
            {
                throw new UsuarioException("No hay usuario con ese id");
            }

            return usuario;
        }

        public Usuario Login(string email, string contrasenia)
        {
            Usuario usuarioLogueado = _context.Usuarios.Where(
                    user => user.Email.Email == email &&
                    user.Contrasenia == contrasenia).FirstOrDefault();
            
            if(usuarioLogueado == null)
            {
                throw new UsuarioException("Credenciales invalidas");
            }

            return usuarioLogueado;
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Usuario obj)
        {
            obj.Validar();
            _context.Usuarios.Update(obj);
            _context.SaveChanges();
        }
    }
}
