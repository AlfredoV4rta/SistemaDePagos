using LaEmpresa.LogicaAplicacion.DTOs;
using LaEmpresa.LogicaAplicacion.InterfacesCU.CasosPago;
using LaEmpresa.LogicaAplicacion.Mappers;
using LaEmpresa.LogicaNegocio.Entidades;
using LaEmpresa.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEmpresa.LogicaAplicacion.CasosDeUso.PagoCU
{
    public class ObtenerPagosCU : IObtenerPagos
    {
        private IPagoRepositorio _repositorioPago;

        public ObtenerPagosCU(IPagoRepositorio repositorioPago)
        {
            _repositorioPago = repositorioPago;
        }

        public IEnumerable<PagoDTO> ObtenerPagos()
        {
            IEnumerable<Pago> toReturn = _repositorioPago.FindAll();

            return toReturn.Select(pago => PagoMapper.ToDTO(pago)); 
        }

    }
}
