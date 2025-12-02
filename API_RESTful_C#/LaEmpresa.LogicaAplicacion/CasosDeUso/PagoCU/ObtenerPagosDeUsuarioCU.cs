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
    public class ObtenerPagosDeUsuarioCU : IObtenerPagosDeUsuario
    {
        private IPagoRepositorio _repo;

        public ObtenerPagosDeUsuarioCU(IPagoRepositorio repo)
        {
            _repo = repo;
        }
        
        public IEnumerable<PagoDTO> ObtenerPagosDeUsuario(int idUsuario)
        {
            IEnumerable<Pago> toReturn = _repo.PagosDeUsuario(idUsuario);
            
            return toReturn.Select(pago => PagoMapper.ToDTO(pago));
        }
    }
}
