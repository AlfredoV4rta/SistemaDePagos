using LaEmpresa.LogicaNegocio.Exceptions;
using LaEmpresa.LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEmpresa.LogicaNegocio.Entidades
{
    public abstract class Pago : IValidable, IEquatable<Pago>
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public MetodoPago MetodoDePago { get; set; }

        [ForeignKey(nameof(TipoGasto))]
        public int IdTipoGasto { get; set; }

        [Required]
        public TipoDeGasto TipoGasto { get; set; }

        [ForeignKey(nameof(Usuario))]
        public int IdUsuario { get; set; }

        [Required]
        public Usuario Usuario { get; set; }

        [Required]
        [StringLength(200)]
        public string Descripcion { get; set; }

        [Range(0.01, double.MaxValue)]
        public double Monto { get; set; }
        public Pago() { }

        public Pago(MetodoPago metodoDePago, int idTipoGasto, int idUsuario, string descripcion, double monto)
        {
            MetodoDePago = metodoDePago;
            IdTipoGasto = idTipoGasto;
            IdUsuario = idUsuario;
            Descripcion = descripcion;
            Monto = monto;
        }

        public abstract double CalcularSaldoPendiente(double monto);

        public abstract DateTime ObtenerFechaHasta();
        public abstract DateTime ObtenerFechaDesde();
        public abstract DateTime ObtenerFechaDePago();
        public abstract string ObtenerNroRecibo();

        public void Validar()
        {
            this.ValidarMetodoPago();
            this.ValidarDescripcion();
            this.ValidarTipoGasto();
            this.ValidarMonto();
        }

        public void ValidarMetodoPago()
        {
            if (this.MetodoDePago == null)
            {
                throw new PagoException("Metodo de pago no ingresado");
            }
        }

        public void ValidarMonto()
        {
            if (this.Monto <= 0)
            {
                throw new PagoException("El monto debe ser mayor a cero");
            }
        } 

        public void ValidarUsuario()
        {
            Usuario.Validar();
        }

        public void ValidarTipoGasto()
        {
            if (this.IdTipoGasto < 0)
            {
                throw new PagoException("Tipo de gasto no ingresado");
            }
        }

        public void ValidarDescripcion()
        {
            if (string.IsNullOrEmpty(Descripcion))
            {
                throw new PagoException("La descripcion no puede ser vacia");
            }
        }

        public bool Equals(Pago? other)
        {
            return this.Id.Equals(other.Id);
        }
    }
}
