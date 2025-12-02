using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaEmpresa.LogicaNegocio.Entidades;

namespace LaEmpresa.LogicaNegocio.InterfacesRepositorio
{
    public interface IEquipoRepositorio : IRepositorio<Equipo>
    {
        public IEnumerable<Equipo> GetByNombre(string nombre);
    }
}
