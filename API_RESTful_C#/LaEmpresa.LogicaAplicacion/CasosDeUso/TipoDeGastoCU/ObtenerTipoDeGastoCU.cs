using LaEmpresa.LogicaAplicacion.DTOs;
using LaEmpresa.LogicaAplicacion.InterfacesCU.CasosTipoDeGasto;
using LaEmpresa.LogicaAplicacion.Mappers;
using LaEmpresa.LogicaNegocio.Entidades;
using LaEmpresa.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEmpresa.LogicaAplicacion.CasosDeUso.TipoDeGastoCU
{
    public class ObtenerTipoDeGastoCU : IObtenerTipoDeGasto
    {
        private ITipoDeGastoRepositorio _repositorioTipoGasto;

        public ObtenerTipoDeGastoCU(ITipoDeGastoRepositorio repositorioTipoGasto)
        {
            _repositorioTipoGasto = repositorioTipoGasto;
        }
        
        public IEnumerable<TipoDeGastoDTO> ObtenerTiposDeGasto()
        {
            IEnumerable<TipoDeGasto> toReturn = _repositorioTipoGasto.FindAll();

            return toReturn.Select(tipoGasto => TipoDeGastoMapper.ToDTO(tipoGasto));
        }
    }
}
