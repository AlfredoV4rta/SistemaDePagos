using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEmpresa.LogicaNegocio.Exceptions
{
    public class PagoException : Exception
    {
        public PagoException() { }

        public PagoException(string message) : base(message) { }

        public PagoException(string message, Exception ex) : base(message, ex) { }
    }
}
