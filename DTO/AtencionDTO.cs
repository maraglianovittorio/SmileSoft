using SmileSoft.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmileSoft.DTO
{
    public class AtencionDTO
    {
        public int Id { get; set; }
       
        [Required(ErrorMessage = "La fecha y hora de la atencion es obligatoria")]
        public DateTime FechaHoraAtencion { get; set; }

        public string Estado { get; set; } = "Otorgada";// Los estados posibles son: "Otorgada", "En espera","Cancelada" y "Finalizada"
        public string Observaciones { get; set; } = string.Empty;
        [Required(ErrorMessage = "El id del odontologo es obligatorio")]
        public int OdontologoId { get; set; }
        [Required(ErrorMessage = "El id del paciente es obligatorio")]
        public int PacienteId { get; set; }
        [Required(ErrorMessage = "El id del tipo de atencion es obligatorio")]
        public int TipoAtencionId { get; set; }
    }

    // DTO with navigation properties for display purposes
    public class AtencionDetalleDTO
    {
        public int Id { get; set; }
        public DateTime FechaHoraAtencion { get; set; }
        public string Estado { get; set; } = string.Empty;
        public string Observaciones { get; set; } = string.Empty;
        
        // Foreign Keys
        public int OdontologoId { get; set; }
        public int PacienteId { get; set; }
        public int TipoAtencionId { get; set; }
        
        // Navigation properties for display
        public string PacienteNombre { get; set; } = string.Empty;
        public string PacienteApellido { get; set; } = string.Empty;
        public string PacienteDni { get; set; } = string.Empty;
        public string OdontologoNombre { get; set; } = string.Empty;
        public string OdontologoApellido { get; set; } = string.Empty;
        public string TipoAtencionDescripcion { get; set; } = string.Empty;
        public TimeSpan TipoAtencionDuracion { get; set; }
    }
}
public class AtencionSecretarioDTO()
{
    public int Id { get; set; }
    public DateTime FechaHoraAtencion { get; set; }
    public string Estado { get; set; } = string.Empty;
    public int OdontologoId { get; set; }
    public int PacienteId { get; set; }
    public int TipoAtencionId { get; set; }
    public string PacienteNombre { get; set; } = string.Empty;
    public string PacienteApellido { get; set; } = string.Empty;
    public string PacienteDni { get; set; } = string.Empty;
    public string OdontologoNombre { get; set; } = string.Empty;
    public string OdontologoApellido { get; set; } = string.Empty;
    public string TipoAtencionDescripcion { get; set; } = string.Empty;
    public TimeSpan TipoAtencionDuracion { get; set; }

}
public class HistoriaClinicaDTO
{
    public int PacienteId { get; set; }
    public string PacienteNombre { get; set; } = string.Empty;
    public string PacienteApellido { get; set; } = string.Empty;
    public string PacienteDni { get; set; } = string.Empty;
    public List<string> Observaciones { get; set; } = new List<string>();
}
