﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmileSoft.Dominio
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NroDni { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string NroAfiliado { get; set; }
        public string CodHistoriaClinica { get; set; }

        public Tutor Tutor { get; set; }
        public ICollection<TipoPlan> TipoPlanes { get; set; }
        public ICollection<Atencion> Atenciones { get; set; }
    }
}
