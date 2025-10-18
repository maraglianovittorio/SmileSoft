using SmileSoft.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
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
}
