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
    public class NombreCompleto : IValidable
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public NombreCompleto(string nombre, string apellido)
        {
            Nombre = nombre.Trim().ToLower();
            Apellido = apellido.Trim().ToLower();
        }

        public NombreCompleto() { }

        public void Validar()
        {
            this.ValidarNombre();
            this.ValidarApellido();
        }

        public void ValidarNombre()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new UsuarioException("El nombre no puede ser vacio");
            }
        }

        public void ValidarApellido()
        {
            if (string.IsNullOrEmpty(Apellido))
            {
                throw new UsuarioException("El apellido no puede ser vacio");
            }
        }

        public string ObtenerPartes()
        {
            string mezcla = CreadorCaracteres(Nombre, Apellido);

            return mezcla;
        }

        private string CreadorCaracteres(string nombre, string apellido)
        {
            int i = 0;
            string cadena = "";
            
            while (cadena.Length < 3)
            {
                if (i >= nombre.Length) { cadena += " "; }
                else
                {
                    cadena += QuitarCaracteresEspeciales(nombre[i]);
                }
                i++;
            }

            i = 0;

            while(cadena.Length < 6)
            {
                if (i >= apellido.Length) { cadena += " "; }
                else
                {
                    cadena += QuitarCaracteresEspeciales(apellido[i]);
                }
                i++;
            }

            return cadena.Trim();
        }

        private char QuitarCaracteresEspeciales(char caracter)
        {
            switch (caracter)
            {
                case 'á': return 'a';
                case 'é': return 'e';
                case 'í': return 'i';
                case 'ó': return 'o';
                case 'ú': return 'u';
                case 'ñ': return 'n';
                default: return caracter;
            }
        }
    }
}
