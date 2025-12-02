using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEmpresa.LogicaAplicacion.DTOs
{
    public class EquipoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del equipo es obligatorio")]
        [StringLength(50, ErrorMessage = "El nombre del equipo no puede superar los 50 caracteres")]
        public string Nombre { get; set; }
    }
}
