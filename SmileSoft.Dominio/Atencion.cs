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
        public DateTime FechaAtencion { get; set; }
        public TimeSpan Hora { get; set; }
        public string Estado { get; set; }
        public string Observaciones { get; set; }

        public TipoAtencion TipoAtencion { get; set; }
        public Odontologo Odontologo { get; set; }
        public Paciente Paciente { get; set; }
        public Pago Pago { get; set; }
    }
}
