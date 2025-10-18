using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmileSoft.Dominio
{
    public class TipoAtencion
    {
        public int Id { get; private set; }
        public string Descripcion { get; private set; }
        public TimeSpan Duracion { get; private set; }

        public ICollection<Atencion> Atenciones { get; private set; } = new List<Atencion>();
        public TipoAtencion(int id,string descripcion, TimeSpan duracion)
        {
            SetId(id);
            SetDescripcion(descripcion);
            SetDuracion(duracion);
        }

        public void SetId(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("El Id debe ser un número positivo.");
            }
            Id = id;
        }

        public void SetDescripcion(string descripcion)
        {
            if (string.IsNullOrWhiteSpace(descripcion))
            {
                throw new ArgumentException("La descripción no puede estar vacía.");
            }
            Descripcion = descripcion;
        }

        public void SetDuracion(TimeSpan duracion)
        {
            if (duracion <= TimeSpan.Zero)
            {
                throw new ArgumentException("La duración debe ser un tiempo positivo.");
            }
            Duracion = duracion;
        }
    }
}
