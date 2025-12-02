using LaEmpresa.LogicaAplicacion.DTOs;
using LaEmpresa.LogicaAplicacion.InterfacesCU.CasosTipoDeGasto;
using LaEmpresa.LogicaNegocio.Entidades;
using LaEmpresa.LogicaNegocio.Exceptions;
using LaEmpresa.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEmpresa.LogicaAplicacion.CasosDeUso.TipoDeGastoCU
{
    public class BorrarTipoDeGastoCU : IBorrarTipoDeGasto
    {
        private ITipoDeGastoRepositorio _repositorio;
        private IAuditoriaRepositorio _auditoriaRepositorio;
        private IPagoRepositorio _pagoRepositorio;

        public BorrarTipoDeGastoCU(ITipoDeGastoRepositorio repositorio, IAuditoriaRepositorio auditoria, IPagoRepositorio pagoRepositorio)
        {
            _repositorio = repositorio;
            _auditoriaRepositorio = auditoria;
            _pagoRepositorio = pagoRepositorio;
        }

        public void BorrarTipoDeGasto(int id, string email)
        {
            if (_pagoRepositorio.FindAll().Any(pago => pago.IdTipoGasto == id))
            {
                throw new TipoDeGastoException("El tipo de gasto esta siendo usado");
            }

            _repositorio.Remove(id);
            _auditoriaRepositorio.Add(new Auditoria(email, "Borrar", id));

        }
    }
}