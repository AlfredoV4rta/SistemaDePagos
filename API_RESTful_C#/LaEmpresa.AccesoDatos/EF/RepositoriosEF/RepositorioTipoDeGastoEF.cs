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
    public class RepositorioTipoDeGastoEF : ITipoDeGastoRepositorio
    {
        private LaEmpresaContext _context;

        public RepositorioTipoDeGastoEF(LaEmpresaContext context)
        {
            _context = context;
        }
        
        public void Add(TipoDeGasto obj)
        {
            obj.Validar();
            _context.Add(obj);
            _context.SaveChanges();
        }

        public IEnumerable<TipoDeGasto> FindAll()
        {
            IEnumerable<TipoDeGasto> tipos = _context.TipoDeGastos;

            if (tipos == null)
            {
                throw new TipoDeGastoException("No hay tipos de gasto");
            }

            return tipos;
        }

        public TipoDeGasto FindById(int id)
        {
            TipoDeGasto tipoDeGasto = _context.TipoDeGastos.Where(
                tdg => tdg.Id == id).FirstOrDefault();

            if (tipoDeGasto == null)
            {
                throw new TipoDeGastoException("Tipo de gasto no encontrado");
            }

            return tipoDeGasto;
        }

        public void Remove(int id)
        {
            TipoDeGasto aBorrar = FindById(id);

            if(aBorrar == null)
            {
                throw new TipoDeGastoException("No hay tipo de gasto con ese id");
            }

            _context.TipoDeGastos.Remove(aBorrar);
            _context.SaveChanges();
        }

        public void Update(TipoDeGasto obj)
        {
            _context.TipoDeGastos.Update(obj);
            _context.SaveChanges();
        }
    }
}
