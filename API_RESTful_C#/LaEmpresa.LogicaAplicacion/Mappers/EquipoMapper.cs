using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaEmpresa.LogicaAplicacion.DTOs;
using LaEmpresa.LogicaNegocio.Entidades;

namespace LaEmpresa.LogicaAplicacion.Mappers
{
    public class EquipoMapper
    {
        public static EquipoDTO toDTO(Equipo equipo)
        {
            return new EquipoDTO
            {
                Id = equipo.Id,
                Nombre = equipo.Nombre
            };
        }

        public static Equipo fromDTO(EquipoDTO equipoDTO)
        {
            return new Equipo
            {
                Id = equipoDTO.Id,
                Nombre = equipoDTO.Nombre
            };
        }
    }
}
