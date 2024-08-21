using System.ComponentModel.DataAnnotations;

namespace Nomina.Entities.DTOs
{
    public class PrestamoDTO
    {
        public int Id { get; set; }

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

        public List<AbonoDTO> Abonos { get; set; }
    }
}
