using LaEmpresa.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaEmpresa.LogicaNegocio.Entidades;

namespace LaEmpresa.LogicaNegocio.InterfacesRepositorio
{
    public interface IPagoRepositorio : IRepositorio<Pago>
    {
        public IEnumerable<Pago> GetByMonthYear(int month, int year);

        public IEnumerable<Usuario> UsuarioMayorMonto(double monto);

        public IEnumerable<Pago> PagosDeUsuario(int idUsuario);

        public IEnumerable<Equipo> EquiposMayorMonto(double monto);
    }
}
