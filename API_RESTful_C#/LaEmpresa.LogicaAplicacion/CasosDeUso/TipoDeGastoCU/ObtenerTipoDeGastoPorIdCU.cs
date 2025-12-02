using LaEmpresa.LogicaAplicacion.DTOs;
using LaEmpresa.LogicaAplicacion.InterfacesCU.CasosTipoDeGasto;
using LaEmpresa.LogicaAplicacion.Mappers;
using LaEmpresa.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEmpresa.LogicaAplicacion.CasosDeUso.TipoDeGastoCU
{
    public class ObtenerTipoDeGastoPorIdCU : IObtenerTipoDeGastoPorId
    {
        private ITipoDeGastoRepositorio _repositorio;

        public ObtenerTipoDeGastoPorIdCU(ITipoDeGastoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public TipoDeGastoDTO ObtenerTipoDeGastoPorId(int id)
        {
            return TipoDeGastoMapper.ToDTO(_repositorio.FindById(id));
        }
    }
}
