using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaEmpresa.LogicaNegocio.Exceptions;
using LaEmpresa.LogicaNegocio.Interfaces;
using LaEmpresa.LogicaNegocio.ValueObjects;

namespace LaEmpresa.LogicaNegocio.Entidades
{
    public class Usuario : IValidable
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(EquipoUsuario))]
        public int IdEquipo { get; set; }

        [Required]
        public Equipo EquipoUsuario { get; set; }

        [Required]
        public NombreCompleto NombreCompleto { get; set; }

        [Required]
        [StringLength(100)]
        public string Contrasenia { get; set; }

        [Required]
        public EmailCompleto Email { get; set; }

        [Required]
        public Rol Rol { get; set; }


        public Usuario() {}

        public Usuario(int id, int idEquipo, NombreCompleto nombreCompleto, string contrasenia, Rol rol)
        {
            Id = id;
            IdEquipo = idEquipo;
            NombreCompleto = nombreCompleto;
            Contrasenia = contrasenia;
            Email = new EmailCompleto(nombreCompleto);
            Rol = rol;
        }

        public void Validar()
        {
            this.ValidarRol();
            this.ValidarIdEquipo();
            this.ValidarContrasenia();
            this.ValidarNombreCompleto();
            this.ValidarEmial();

        }

        public void ValidarIdEquipo()
        {
            if(this.IdEquipo < 0)
            {
                throw new UsuarioException("Id de equipo mal ingresado");
            }
        }
        public void ValidarNombreCompleto()
        {
            NombreCompleto.Validar();
        }


        public void ValidarContrasenia()
        {
            if (string.IsNullOrEmpty(Contrasenia) || Contrasenia.Length < 8)
            {
                throw new UsuarioException("Contrasenia vacia o muy corta. Minimo 8 caracteres");
            }
        }

        public void ValidarRol()
        {
            if (Rol == null)
            {
                throw new UsuarioException("El usuario debe tener rol");
            }
        }

        public void ValidarEmial()
        {
            Email.Validar();
        }
    }
}
