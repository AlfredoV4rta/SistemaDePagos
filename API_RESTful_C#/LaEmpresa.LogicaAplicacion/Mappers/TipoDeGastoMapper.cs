using LaEmpresa.LogicaAplicacion.DTOs;
using LaEmpresa.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEmpresa.LogicaAplicacion.Mappers
{
    public class TipoDeGastoMapper
    {
        public static TipoDeGasto FromDTO(TipoDeGastoDTO dto)
        {
            return new TipoDeGasto
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion
            };
        }

        public static TipoDeGastoDTO ToDTO(TipoDeGasto toDto)
        {
            return new TipoDeGastoDTO
            {
                Id = toDto.Id,
                Nombre = toDto.Nombre,
                Descripcion = toDto.Descripcion
            };
        }
    }
}
