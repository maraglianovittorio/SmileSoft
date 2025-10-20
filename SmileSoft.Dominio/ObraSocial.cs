using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmileSoft.Dominio
{
    public class ObraSocial
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public ICollection<TipoPlan> TipoPlanes { get; private set; } = new List<TipoPlan>();

        public ObraSocial(int id, string nombre)
        {
            SetId(id);
            SetNombre(nombre);
        }
        //public ObraSocial(string nombre)
        //{
        //    SetNombre(nombre);
        //}
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
                throw new ArgumentException("El nombre de la obra social no puede estar vacío.");
            }
            Nombre = nombre;
        }

    }
}
