using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmileSoft.Dominio
{
    public class TipoPlan
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        // Clave foránea
        public int ObraSocialId { get; set; }
        
        // Propiedad de navegación
        public ObraSocial ObraSocial { get; set; }
        
        public ICollection<Paciente> Pacientes { get; set; }
    }
}
