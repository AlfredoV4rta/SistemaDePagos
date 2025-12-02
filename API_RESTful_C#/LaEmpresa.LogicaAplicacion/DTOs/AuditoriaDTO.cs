using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEmpresa.LogicaAplicacion.DTOs
{
    public class AuditoriaDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }

        public string Accion {  get; set; }

        public int IdTipoDeGasto { get; set; }

        public DateTime Fecha { get; set; }
    }
}
