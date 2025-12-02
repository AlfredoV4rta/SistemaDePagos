using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEmpresa.WebApp.DTOs
{
    public class TipoDeGastoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del tipo de gasto es obligatorio")]
        [StringLength(50, ErrorMessage = "El nombre no puede superar los 50 caracteres")]
        public string Nombre { get; set; }

        [StringLength(200, ErrorMessage = "La descripción no puede superar los 200 caracteres")]
        public string Descripcion { get; set; }
    }
}
