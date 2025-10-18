using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SmileSoft.Dominio
{
    // NO hacemos Persona abstracta porque el tutor puede NO ser paciente o NO ser odontologo
    public class Persona
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public string Apellido { get; private set; } 
        public string NroDni { get; private set; } 
        public string Direccion { get; private set; }
        public string Email { get; private set; }
        public DateTime FechaNacimiento { get; private set; }
        public string Telefono { get; private set; }
        public virtual ICollection<Paciente> PacientesTutelados { get; private set; } = new List<Paciente>();

        public Persona(int id, string nombre, string apellido, string nroDni,DateTime fechaNacimiento,string direccion, string email, string telefono)
        {
            SetId(id);
            SetNombre(nombre);
            SetApellido(apellido);
            SetNroDni(nroDni);
            SetFechaNacimiento(fechaNacimiento);
            SetDireccion(direccion);
            SetEmail(email);
            SetTelefono(telefono);
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
        public void SetApellido(string apellido)
        {
            if (string.IsNullOrWhiteSpace(apellido))
            {
                throw new ArgumentException("El apellido no puede estar vacío.");
            }
            Apellido = apellido;
        }
        public void SetNroDni(string nroDni)
        {
            if (string.IsNullOrWhiteSpace(nroDni))
            {
                throw new ArgumentException("El número de DNI no puede estar vacío.");
            }
            NroDni = nroDni;
        }
        public void SetDireccion(string direccion)
        {
            if (string.IsNullOrWhiteSpace(direccion))
            {
                throw new ArgumentException("La dirección no puede estar vacía.");
            }
            Direccion = direccion;
        }
        public void SetEmail(string email)
        {
            if (!EsEmailValido(email))
                throw new ArgumentException("El email no tiene un formato válido.", nameof(email));
            Email = email;
        }

        private static bool EsEmailValido(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
        public void SetFechaNacimiento(DateTime fechaNacimiento)
        {
            FechaNacimiento = fechaNacimiento;
        }
        public void SetTelefono(string telefono)
        {
            if (string.IsNullOrWhiteSpace(telefono))
            {
                throw new ArgumentException("El teléfono no puede estar vacío.");
            }
            Telefono = telefono;
        }


        public Persona() { }

    }
}
