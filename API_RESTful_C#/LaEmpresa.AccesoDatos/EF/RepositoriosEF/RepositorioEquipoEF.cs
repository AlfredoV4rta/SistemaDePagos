using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaEmpresa.LogicaNegocio.Entidades;
using LaEmpresa.LogicaNegocio.InterfacesRepositorio;

namespace LaEmpresa.AccesoDatos.EF.RepositoriosEF
{
    public class RepositorioEquipoEF : IEquipoRepositorio
    {
        private LaEmpresaContext _context;
        public RepositorioEquipoEF(LaEmpresaContext context)
        {
            _context = context;
        }
        public void Add(Equipo obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Equipo> FindAll()
        {
            return _context.Equipos;
        }

        public Equipo FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Equipo> GetByNombre(string nombre)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Equipo obj)
        {
            throw new NotImplementedException();
        }
    }
}
