using System.ComponentModel.DataAnnotations;

namespace Nomina.Entities.DTOs
{
    public class AbonoDTO
    {
        public int Id { get; set; }

        public int PrestamoId { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "La fecha del abono es obligatoria.")]
        public DateTime FechaAbono { get; set; }

        [Required(ErrorMessage = "El monto del abono es obligatorio.")]
        [Range(0, double.MaxValue, ErrorMessage = "El monto debe ser un valor positivo.")]
        public decimal MontoAbono { get; set; }
    }
}
