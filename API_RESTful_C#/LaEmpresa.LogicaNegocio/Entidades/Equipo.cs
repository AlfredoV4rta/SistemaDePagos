using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaEmpresa.LogicaNegocio.Exceptions;
using LaEmpresa.LogicaNegocio.Interfaces;
using LaEmpresa.LogicaNegocio.ValueObjects;

namespace LaEmpresa.LogicaNegocio.Entidades
{
    public class Equipo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }


        public void Validar()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new EquipoException("El nombre del equipo no debe estar vacio");
            }
        }
    }
}
