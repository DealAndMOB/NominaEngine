using Microsoft.EntityFrameworkCore;
using Nomina.Entities;

namespace Nomina.Models
{
    public class Context: DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { }

        public virtual DbSet<Empleo> Empleos { get; set; }
        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<BonificacionDeGasto> BonificacionDeGastos { get; set; }
        public virtual DbSet<Prestamo> Prestamos { get; set; }
        public virtual DbSet<Abono> Abonos { get; set; }
    }
}
