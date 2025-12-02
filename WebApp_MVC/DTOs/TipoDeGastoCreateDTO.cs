using System.ComponentModel.DataAnnotations;

namespace LaEmpresa.WebApp.DTOs
{
    public class TipoDeGastoCreateDTO
    {
        [Required(ErrorMessage = "El nombre del tipo de gasto es obligatorio")]
        [StringLength(50, ErrorMessage = "El nombre no puede superar los 50 caracteres")]
        public string Nombre { get; set; }

        [StringLength(200, ErrorMessage = "La descripción no puede superar los 200 caracteres")]
        public string Descripcion { get; set; }
    }
}
