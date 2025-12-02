using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaEmpresa.LogicaAplicacion.DTOs;
using LaEmpresa.LogicaAplicacion.InterfacesCU.CasosPago;
using LaEmpresa.LogicaAplicacion.Mappers;
using LaEmpresa.LogicaNegocio.Entidades;
using LaEmpresa.LogicaNegocio.Exceptions;
using LaEmpresa.LogicaNegocio.InterfacesRepositorio;

namespace LaEmpresa.LogicaAplicacion.CasosDeUso.PagoCU
{
    public class ObtenerPagoPorIdCU : IObtenerPagoPorId
    {
        private IPagoRepositorio _repositorio;

        public ObtenerPagoPorIdCU(IPagoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public PagoDTO ObtenerPagoPorId(int id)
        {
            PagoDTO pago = PagoMapper.ToDTO(_repositorio.FindById(id));

            if(pago == null)
            {
                throw new PagoException("No hay pago para ese id");
            }

            return pago;
        }
    }
}
