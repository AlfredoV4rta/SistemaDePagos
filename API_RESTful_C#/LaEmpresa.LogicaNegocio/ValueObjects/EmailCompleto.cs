using LaEmpresa.LogicaNegocio.Exceptions;
using LaEmpresa.LogicaNegocio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEmpresa.LogicaNegocio.ValueObjects
{
    [Owned]
    public class EmailCompleto: IValidable
    {
        public string Email { get; set; }

        public EmailCompleto(NombreCompleto nombreCompleto)
        {
            this.Email = Crear(nombreCompleto);
        }

        public EmailCompleto() { }

        public string Crear(NombreCompleto nc)
        {
            string email = nc.ObtenerPartes() + "@laEmpresa.com";
            
            return email;
           
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Email))
            {
                throw new UsuarioException("El email no puede ser vacio");
            }
        }
    }
}
