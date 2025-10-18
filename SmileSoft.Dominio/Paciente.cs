using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmileSoft.Dominio
{
    public class Paciente: Persona
    {
        //public DateTime FechaNacimiento { get; set; }
        public string NroAfiliado { get; set; }
        public string NroHC { get; set; }
        //public string NroDni { get; set; }

        public int? TutorId { get; set; } = 0;
        public Persona? Tutor { get; set; } = null;
        public int? TipoPlanId { get; set; }
        public TipoPlan? TipoPlan { get; set; }
        public ICollection<Atencion> Atenciones { get; set; } = new List<Atencion>();

        public Paciente(int id, string nombre, string apellido, string nroDni, string direccion, string email, DateTime fechaNacimiento, string telefono, string nroAfiliado, string nroHC,int? tutorId,int? tipoPlanId):base(id,nombre,apellido,nroDni,fechaNacimiento,direccion,email,telefono)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            NroDni = nroDni;
            Direccion = direccion;
            Email = email;
            FechaNacimiento = fechaNacimiento;
            Telefono = telefono;
            NroAfiliado = nroAfiliado;
            NroHC = nroHC;
            TutorId = tutorId;
            TipoPlanId = tipoPlanId;
        }
        public Paciente():base() { }

    }
}
