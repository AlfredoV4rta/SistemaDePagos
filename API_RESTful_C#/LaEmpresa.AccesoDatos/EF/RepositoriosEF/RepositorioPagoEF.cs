using LaEmpresa.LogicaNegocio.Entidades;
using LaEmpresa.LogicaNegocio.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaEmpresa.LogicaNegocio.Exceptions;

namespace LaEmpresa.AccesoDatos.EF.RepositoriosEF
{
    public class RepositorioPagoEF : IPagoRepositorio
    {
        private LaEmpresaContext _context;

        public RepositorioPagoEF(LaEmpresaContext context)
        {
            _context = context;
        }
        public void Add(Pago obj)
        {
            obj.Validar();
            _context.Add(obj);
            _context.SaveChanges();
        }

        public IEnumerable<Pago> FindAll()
        {
            return _context.Pagos;
        }

        public Pago FindById(int id)
        {
            Pago pagoBuscado = _context.Pagos
                .Include(pago => pago.TipoGasto)
                .Include(pago => pago.Usuario)
                .FirstOrDefault(pago => pago.Id == id);


            if (pagoBuscado == null)
            {
                throw new PagoException("Pago no encontrado");
            }

            return pagoBuscado;
        }

        public IEnumerable<Pago> GetByMonthYear(int month, int year)
        {
            DateTime fechaBuscada = new DateTime(year, month, 1);

            IEnumerable<Pago> pagos = _context.Pagos.Include(pago => pago.TipoGasto)
                                             .Include(pago =>pago.Usuario).ToList();
            pagos = pagos.Where(p =>
                (p is Unico && ((Unico)p).FechaDePago.Month == month && ((Unico)p).FechaDePago.Year == year)
                ||
                (p is Recurrente && fechaBuscada >= ((Recurrente)p).FechaDesde
                    && fechaBuscada <= ((Recurrente)p).FechaHasta)).ToList();

            return pagos;
        }

        public IEnumerable<Pago> PagosDeUsuario(int idUsuario)
        {
            IEnumerable<Pago> pagos = _context.Pagos
                                        .Include(p => p.TipoGasto)
                                        .Include(p => p.Usuario)
                                        .Where(u => u.IdUsuario == idUsuario)
                                        .ToList();

            if (pagos == null)
            {
                throw new Exception("No hay pagos asociados a este id");
            }

            return pagos;

        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Pago obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> UsuarioMayorMonto(double monto)
        {
            List<Usuario> pagosMonto = _context.Pagos.Where(
                    pago => pago.Monto > monto)
                    .Include(pago => pago.Usuario)
                    .Select(pago => pago.Usuario)
                    .Distinct()
                    .ToList();


            return pagosMonto;
        }

        public IEnumerable<Equipo> EquiposMayorMonto(double monto)
        {
            List<Equipo> equiposMonto = _context.Pagos
                .Include(pago => pago.Usuario)
                .ThenInclude(usuario => usuario.EquipoUsuario)
                .Where(pago => pago.Monto > monto)
                .Select(pago => pago.Usuario.EquipoUsuario)
                .OrderByDescending(equipo => equipo.Nombre)
                .Distinct()
                .ToList();
            return equiposMonto;
        }

    }
}
