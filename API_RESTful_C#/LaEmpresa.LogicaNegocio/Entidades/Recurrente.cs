using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaEmpresa.LogicaNegocio.Exceptions;
using LaEmpresa.LogicaNegocio.Interfaces;

namespace LaEmpresa.LogicaNegocio.Entidades
{
    public class Recurrente : Pago, IValidable
    {
        [Required]
        public DateTime FechaDesde { get; set; }

        [Required]
        public DateTime FechaHasta { get; set; }

        public Recurrente() { }

        public override double CalcularSaldoPendiente(double monto)
        {
            int cantMeses = MesesDeDiferencia(FechaDesde, FechaHasta);

            return monto * cantMeses;
        }

        public void Validar()
        {
            base.Validar();
            this.ValidarFechaDesde();
            this.ValidarFechaHasta();
        }

        public void ValidarFechaDesde()
        {
            if (FechaDesde == DateTime.MinValue)
            {
                throw new PagoException("La fecha no puede ser vacia");
            }
        }

        public void ValidarFechaHasta()
        {
            if (FechaHasta == DateTime.MinValue)
            {
                throw new PagoException("La fecha no puede ser vacia");
            }
        }

        public int MesesDeDiferencia(DateTime fechaDesde, DateTime fechaHasta)
        {
            int anios = (fechaHasta.Year - fechaDesde.Year) * 12;
            int totalDiferencia = anios + (fechaHasta.Month - fechaDesde.Month);

            //Le agrego uno para incluir el primer mes
            return totalDiferencia + 1;
        }

        public override DateTime ObtenerFechaHasta()
        {
            return this.FechaHasta;
        }

        public override DateTime ObtenerFechaDesde()
        {
            return this.FechaDesde;
        }

        public override DateTime ObtenerFechaDePago()
        {
            return DateTime.MinValue;
        }

        public override string ObtenerNroRecibo()
        {
            return "";
        }
    }
}
