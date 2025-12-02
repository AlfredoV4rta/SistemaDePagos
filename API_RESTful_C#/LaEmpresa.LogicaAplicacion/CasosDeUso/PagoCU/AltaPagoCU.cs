using LaEmpresa.LogicaAplicacion.DTOs;
using LaEmpresa.LogicaAplicacion.InterfacesCU.CasosPago;
using LaEmpresa.LogicaAplicacion.Mappers;
using LaEmpresa.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEmpresa.LogicaAplicacion.CasosDeUso.PagoCU
{
    public class AltaPagoCU : IAltaPago
    {
        private IPagoRepositorio _repositorio;

        public AltaPagoCU(IPagoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public void AltaPago(PagoDTO pagoDto)
        {
            if (pagoDto.FechaDesde != DateTime.MinValue)
            {
                _repositorio.Add(PagoMapper.toRecurrente(pagoDto));
            }
            else
            {
                _repositorio.Add(PagoMapper.toUnico(pagoDto));
            }
            
        }
    }
}
