﻿using System;
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

        public ICollection<TipoPlan> Planes { get; set; }
    }
}
