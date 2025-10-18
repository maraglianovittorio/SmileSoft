using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmileSoft.Dominio
{
    // NO hacemos Persona abstracta porque el tutor puede NO ser paciente o NO ser odontologo
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NroDni { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public virtual ICollection<Paciente> PacientesTutelados { get; set; } = new List<Paciente>();
        public bool EsTutor()
        {
            return PacientesTutelados != null && PacientesTutelados.Count > 0;
        }
        public Persona(int id, string nombre, string apellido, string nroDni,DateTime fechaNacimiento,string direccion, string email, string telefono)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            NroDni = nroDni;
            FechaNacimiento = fechaNacimiento;
            Direccion = direccion;
            Email = email;
            Telefono = telefono;
        }
        public Persona() { }

    }
}
