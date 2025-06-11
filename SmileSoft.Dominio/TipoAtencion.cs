using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmileSoft.Dominio
{
    public class TipoAtencion
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public TimeSpan Duracion { get; set; }

        public ICollection<Atencion> Atenciones { get; set; }
    }
}
