using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmileSoft.Dominio
{
    public class ObraSocial
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        //public ICollection<TipoPlan> Planes { get; set; }
        
        public ObraSocial(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
            //Planes = new List<TipoPlan>();
        }

        public static readonly List<ObraSocial> ListaOS = new();
        public static int ObtenerProximoID()
        {
            if (ListaOS.Count == 0)
            {
                return 1;
            }
            else
            {
                return ListaOS.Max(p => p.Id) + 1;
            }
        }
    }
}
