using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Nomina.Entities
{
    public class Prestamo
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Empleado")]
        public int EmpleadoId { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "La fecha del préstamo es obligatoria.")]
        public DateTime FechaPrestamo { get; set; }

        [Required(ErrorMessage = "El monto es obligatorio.")]
        [Range(0, double.MaxValue, ErrorMessage = "El monto debe ser un valor positivo.")]
        public decimal MontoOriginal { get; set; }

 
        [Range(0, double.MaxValue, ErrorMessage = "El monto debe ser un valor positivo.")]
        public decimal MontoRestante { get; set; }

        public bool Estado { get; set; } = true;

        public virtual Empleado Empleado { get; set; }

        public virtual ICollection<Abono> Abonos { get; set; }
    }
}
