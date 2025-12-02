using LaEmpresa.LogicaAplicacion.DTOs;
using LaEmpresa.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaEmpresa.LogicaNegocio.ValueObjects;

namespace LaEmpresa.LogicaAplicacion.Mappers
{
    public class UsuarioMapper
    {
        public static Usuario FromDTO(UsuarioDTO dto)
        {
            return new Usuario
            {
                Id = dto.Id,
                NombreCompleto = new NombreCompleto(dto.Nombre, dto.Apellido),
                Email = new EmailCompleto(new NombreCompleto(dto.Nombre, dto.Apellido)),
                Contrasenia = dto.Contrasenia,
                IdEquipo = dto.IdEquipo,
                Rol = dto.Rol
            };
        }

        public static UsuarioDTO ToDTO(Usuario toDto)
        {
            return new UsuarioDTO
            {
                Id = toDto.Id,
                IdEquipo = toDto.IdEquipo,
                Nombre = toDto.NombreCompleto.Nombre,
                Apellido = toDto.NombreCompleto.Apellido,
                Email = toDto.Email.Email,
                Rol = toDto.Rol
            };
        }
    }
}
