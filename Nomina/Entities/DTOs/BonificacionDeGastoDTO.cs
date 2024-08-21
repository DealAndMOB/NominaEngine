using System.ComponentModel.DataAnnotations;

namespace Nomina.Entities.DTOs
{
    public class BonificacionDeGastoDTO
    {
        public int Id { get; set; }

        public int empleadoId { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "La fecha es obligatoria.")]
        public DateTime fecha { get; set; }

        [Required(ErrorMessage = "El monto es obligatorio.")]
        [Range(0, double.MaxValue, ErrorMessage = "El monto debe ser un valor positivo.")]
        public decimal monto { get; set; }

        [Required(ErrorMessage = "El concepto es obligatorio.")]
        public string concepto { get; set; }

        public bool estado { get; set; } = true;
    }
}
