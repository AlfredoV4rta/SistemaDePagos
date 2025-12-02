using LaEmpresa.LogicaNegocio.Entidades;
using LaEmpresa.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEmpresa.AccesoDatos.EF.RepositoriosEF
{
    public class RepositorioAuditoriaEF : IAuditoriaRepositorio
    {

        private LaEmpresaContext _context;

        public RepositorioAuditoriaEF(LaEmpresaContext context)
        {
            _context = context;
        }

        public void Add(Auditoria obj)
        {
            obj.Validar();
            _context.Add(obj);
            _context.SaveChanges();
        }

        public IEnumerable<Auditoria> FindAll()
        {
            throw new NotImplementedException();
        }

        public Auditoria FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Auditoria> ObtenerAuditoriasTipoDeGasto(int idTipoDeGasto)
        {
            IEnumerable<Auditoria> auditorias = _context.Auditorias
                                                .Where(a => a.IdTipoDeGasto == idTipoDeGasto)
                                                .ToList();

            return auditorias;
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Auditoria obj)
        {
            throw new NotImplementedException();
        }
    }
}
