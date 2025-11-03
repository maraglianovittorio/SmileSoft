using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmileSoft.Dominio
{
    public class AtencionCriteria
    {
        public string Texto { get; private set; }

        public AtencionCriteria(string texto)
        {
            Texto = texto.Trim();
        }

    }
}
