namespace LaEmpresa.WebApp.DTOs
{
    public class AuditoriaDTO
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Accion { get; set; }

        public int IdTipoDeGasto { get; set; }

        public DateTime Fecha { get; set; }
    }
}
