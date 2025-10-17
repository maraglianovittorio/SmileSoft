using System;
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
        public string NroHC { get; set; }

        //public Tutor Tutor { get; set; }
        public int? TipoPlanId { get; set; }
        public TipoPlan? TipoPlan { get; set; }
        public ICollection<Atencion> Atenciones { get; set; } = new List<Atencion>();

        public Paciente(int id, string nombre, string apellido, string nroDni, string direccion, string email, DateTime fechaNacimiento, string telefono, string nroAfiliado, string nroHC, int? tipoPlanId)
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
            //Tutor = new Tutor();
            TipoPlanId = tipoPlanId;
        }
        public Paciente() { }

    }
}
