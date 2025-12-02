using LaEmpresa.LogicaNegocio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEmpresa.AccesoDatos.EF
{
    public class LaEmpresaContext : DbContext
    {
        public DbSet<TipoDeGasto> TipoDeGastos { get; set; }

        public DbSet<Equipo> Equipos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Pago> Pagos { get; set; }

        public DbSet<Recurrente> Recurrentes { get; set; }

        public DbSet<Unico> Unicos { get; set; }

        public DbSet<Auditoria> Auditorias { get; set; }
        public LaEmpresaContext(DbContextOptions options) : base(options) { }
    }
}
