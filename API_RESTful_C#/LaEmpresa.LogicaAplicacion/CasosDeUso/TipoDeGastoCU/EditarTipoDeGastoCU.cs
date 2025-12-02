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
    public class EditarTipoDeGastoCU : IEditarTipoDeGasto
    {
        private ITipoDeGastoRepositorio _repositorio;
        private IAuditoriaRepositorio _auditoriaRepositorio;

        public EditarTipoDeGastoCU(ITipoDeGastoRepositorio repositorio, IAuditoriaRepositorio auditoria)
        {
            _repositorio = repositorio;
            _auditoriaRepositorio = auditoria;
        }
        
        public void EditarTipoDeGasto(TipoDeGastoDTO tipoDeGastoDTO, string email)
        {
           _repositorio.Update(TipoDeGastoMapper.FromDTO(tipoDeGastoDTO));
            _auditoriaRepositorio.Add(new Auditoria(email, "Editar", tipoDeGastoDTO.Id));
        }
    }
}
