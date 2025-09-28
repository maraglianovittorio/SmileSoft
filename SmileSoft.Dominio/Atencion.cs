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
        //public TimeSpan Hora { get; set; }
        public string Estado { get; set; } = string.Empty;// Los estados posibles son: "Otorgada", "En espera","Cancelada" y "Finalizada"
        public string Observaciones { get; set; } = string.Empty;

        //public TipoAtencion TipoAtencion { get; set; } = new TipoAtencion();
        public Odontologo Odontologo { get; set; } = new Odontologo();
        public Paciente Paciente { get; set; }
    }
}
