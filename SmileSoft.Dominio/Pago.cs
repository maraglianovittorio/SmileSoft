using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmileSoft.Dominio
{
    public class Pago
    {
        public int Id { get; set; }
        public string FormaPago { get; set; }
        public DateTime FechaPago { get; set; }

        public Atencion Atencion { get; set; }
    }
}
