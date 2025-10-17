using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class PacienteDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [StringLength(100, ErrorMessage = "El apellido no puede exceder 100 caracteres")]
        public string Apellido { get; set; } = string.Empty;

        [Required(ErrorMessage = "El DNI es obligatorio")]
        [StringLength(20, ErrorMessage = "El DNI no puede exceder 20 caracteres")]
        public string NroDni { get; set; } = string.Empty;

        [StringLength(200, ErrorMessage = "La dirección no puede exceder 200 caracteres")]
        public string Direccion { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "El formato del email no es válido")]
        [StringLength(100, ErrorMessage = "El email no puede exceder 100 caracteres")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        public DateTime FechaNacimiento { get; set; }

        [StringLength(20, ErrorMessage = "El teléfono no puede exceder 20 caracteres")]
        public string Telefono { get; set; } = string.Empty;

        [StringLength(50, ErrorMessage = "El número de afiliado no puede exceder 50 caracteres")]
        public string NroAfiliado { get; set; } = string.Empty;
        public int? TipoPlanId { get; set; } 

        [Required(ErrorMessage = "El número de historia clínica es obligatorio")]
        [StringLength(20, ErrorMessage = "El número de historia clínica no puede exceder 20 caracteres")]
        
        public string NroHC { get; set; } = string.Empty;
        public PacienteDTO()
        {

        }
    }
}
