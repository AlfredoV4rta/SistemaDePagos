using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEmpresa.LogicaNegocio.Exceptions
{
    public class TipoDeGastoException: Exception
    {
        public TipoDeGastoException() { }

        public TipoDeGastoException(string message) : base(message) { }

        public TipoDeGastoException(string message, Exception ex) : base(message, ex) { }
    }
}
