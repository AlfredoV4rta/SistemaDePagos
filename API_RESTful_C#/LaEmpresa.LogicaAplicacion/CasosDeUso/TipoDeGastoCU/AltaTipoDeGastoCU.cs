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
    public class AltaTipoDeGastoCU : IAltaTipoDeGasto
    {
        private ITipoDeGastoRepositorio _repositorio;
        private IAuditoriaRepositorio _auditoriaRepositorio;

        public AltaTipoDeGastoCU(ITipoDeGastoRepositorio repositorio, IAuditoriaRepositorio auditoria)
        {
            _repositorio = repositorio;
            _auditoriaRepositorio = auditoria;
        }
        public void AgregarTipoDeGasto(TipoDeGastoDTO nuevoTipoGasto, string email)
        {
            TipoDeGasto tipoDeGasto = TipoDeGastoMapper.FromDTO(nuevoTipoGasto);

            _repositorio.Add(tipoDeGasto);

            _auditoriaRepositorio.Add(new Auditoria(email, "Alta", tipoDeGasto.Id));
        }
    }
}
