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
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;

        // Clave foránea
        public int ObraSocialId { get; set; }
        
        // Propiedad de navegación
        public ObraSocial ObraSocial { get; set; }
        
        public ICollection<Paciente> Pacientes { get; set; }


        public TipoPlan(int id, string nombre, string descripcion, int obraSocialId)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            ObraSocialId = obraSocialId;
        }
    }
}
