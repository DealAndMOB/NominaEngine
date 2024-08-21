using System.ComponentModel.DataAnnotations;

namespace Nomina.Entities
{
    public class Empleado
    {
        public int Id { get; set; }
        public int empleoID { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string nombre { get; set; }

        public bool estado { get; set; } = true;
        public int salarioSem { get; set; }
        public int diasLaborales { get; set; }
        public string curp { get; set; }

        [DataType(DataType.Date)]
        public DateTime fechaNacimiento { get; set; }

        [DataType(DataType.Date)]
        public DateTime fechaIngreso { get; set; }
        public virtual Empleo Empleo { get; set; }
        public virtual ICollection<BonificacionDeGasto> BonificacionesDeGastos { get; set; }

    }
}
