using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmileSoft.Dominio
{
    public class Atencion
    {
        public int Id { get; set; }
        public DateTime FechaHoraAtencion { get; set; }
        public string Estado { get; set; } = "Otorgada";// Los estados posibles son: "Otorgada", "En espera","Cancelada" y "Finalizada"
        public string Observaciones { get; set; } = string.Empty;
        public int OdontologoId { get; set; }
        public Odontologo Odontologo { get; set; }
        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }
        public int TipoAtencionId { get; set; }
        public TipoAtencion TipoAtencion { get; set; }
        public Atencion(DateTime fechaHoraAtencion,string estado,string observaciones,int odontologoId,int pacienteId,int tipoAtencionId)
        {
            FechaHoraAtencion = fechaHoraAtencion;
            Estado = estado;
            Observaciones = observaciones;
            OdontologoId = odontologoId;
            PacienteId = pacienteId;
            TipoAtencionId = tipoAtencionId;
        }
    }
}
