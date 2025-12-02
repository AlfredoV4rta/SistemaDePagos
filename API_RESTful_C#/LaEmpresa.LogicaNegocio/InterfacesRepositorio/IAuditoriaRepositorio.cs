using LaEmpresa.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEmpresa.LogicaNegocio.InterfacesRepositorio
{
    public interface IAuditoriaRepositorio : IRepositorio<Auditoria>
    {
        public IEnumerable<Auditoria> ObtenerAuditoriasTipoDeGasto(int idTipoDeGasto);
    }
}
