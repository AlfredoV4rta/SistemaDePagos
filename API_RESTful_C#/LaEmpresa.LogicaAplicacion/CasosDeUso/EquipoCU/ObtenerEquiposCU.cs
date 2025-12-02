using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaEmpresa.LogicaAplicacion.DTOs;
using LaEmpresa.LogicaAplicacion.InterfacesCU.CasosEquipo;
using LaEmpresa.LogicaAplicacion.Mappers;
using LaEmpresa.LogicaNegocio.Entidades;
using LaEmpresa.LogicaNegocio.InterfacesRepositorio;

namespace LaEmpresa.LogicaAplicacion.CasosDeUso.EquipoCU
{
    public class ObtenerEquiposCU : IObtenerEquipos
    {
        private IEquipoRepositorio _repositorio;
        public ObtenerEquiposCU(IEquipoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }
        public IEnumerable<EquipoDTO> ObtenerEquipos()
        {
            IEnumerable<Equipo> equipos = _repositorio.FindAll();

            return equipos.Select(equipo => EquipoMapper.toDTO(equipo));
        }
    }
}
