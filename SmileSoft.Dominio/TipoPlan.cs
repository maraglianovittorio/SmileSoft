using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmileSoft.Dominio
{
    public class TipoPlan
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public string Descripcion { get; private set; }

        // Clave foránea
        public int ObraSocialId { get; private set; }

        // Propiedad de navegación
        public ObraSocial ObraSocial { get; private set; }

        public ICollection<Paciente> Pacientes { get; private set; } = new List<Paciente>();

        public TipoPlan(int id, string nombre, string descripcion, int obraSocialId)
        {
            SetId(id);
            SetNombre(nombre);
            SetDescripcion(descripcion);
            SetObraSocialId(obraSocialId);
        }

        public void SetId(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("El Id debe ser un número positivo.");
            }
            Id = id;
        }

        public void SetNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre no puede estar vacío.");
            }
            Nombre = nombre;
        }
        public void SetDescripcion(string descripcion)
        {
            if (string.IsNullOrWhiteSpace(descripcion))
            {
                throw new ArgumentException("La descripción no puede estar vacía.");
            }
            Descripcion = descripcion;
        }
        public void SetObraSocialId(int obraSocialId)
        {
            if (obraSocialId < 0)
            {
                throw new ArgumentException("El Id de la obra social debe ser un número positivo.");
            }
            ObraSocialId = obraSocialId;
        }
    }
}
