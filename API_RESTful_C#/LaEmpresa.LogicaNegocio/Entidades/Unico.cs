using LaEmpresa.LogicaNegocio.Exceptions;
using LaEmpresa.LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEmpresa.LogicaNegocio.Entidades
{
    public class Unico : Pago, IValidable
    {
        [Required]
        public DateTime FechaDePago { get; set; }

        [StringLength(30)]
        public string NroRecibo { get; set; }

        public Unico() { }

        public override double CalcularSaldoPendiente(double monto)
        {
            return 0;
        }

        public void Validar()
        {
            base.Validar();
            this.ValidarFechaDePago();
            this.ValidarNroRecibo();
        }

        public void ValidarFechaDePago()
        {
            if(this.FechaDePago == DateTime.MinValue)
            {
                throw new PagoException("La fecha no puede ser vacia");
            }
        }

        public void ValidarNroRecibo()
        {
            if (string.IsNullOrEmpty(this.NroRecibo) || this.NroRecibo.Length < 3)
            {
                throw new PagoException("Numero de recibo no valido");
            }
        }

        public override DateTime ObtenerFechaHasta()
        {
            return DateTime.MinValue;
        }

        public override DateTime ObtenerFechaDesde()
        {
            return DateTime.MinValue;
        }

        public override DateTime ObtenerFechaDePago()
        {
            return this.FechaDePago;
        }

        public override string ObtenerNroRecibo()
        {
            return this.NroRecibo;
        }
    }
}
