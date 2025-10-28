using SmileSoft.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;

namespace SmileSoft.Data
{
    public class PersonaRepository
    {
        private MiDbContext CreateContext()
        {
            return new MiDbContext();
        }

        public void Add(Persona persona)
        {
            using var context = CreateContext();
            context.Personas.Add(persona);
            context.SaveChanges();
        }

        public bool Delete(int id)
        {
            using var context = CreateContext();
            var persona = context.Personas.Find(id);
            if (persona != null)
            {
                context.Personas.Remove(persona);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Persona? Get(int id)
        {
            using var context = CreateContext();
            return context.Personas
                .FirstOrDefault(p => p.Id == id);
        }
        public Persona? GetByDni(string dni)
        {
            using var context = CreateContext();
            return context.Personas
                .FirstOrDefault(p => p.NroDni == dni);
        }

        public IEnumerable<Persona> GetAll()
        {
            using var context = CreateContext();
            return context.Personas.ToList();
        }
        public IEnumerable<Persona> GetAllTutores()
        {
            using var context = CreateContext();
            return context.Personas
                .Where(p => p.PacientesTutelados.Any())
                .ToList();
        }
        public Persona? GetTutorById(int id)
        {
            using var context = CreateContext();
            return context.Personas
                .FirstOrDefault(p => p.Id == id); 
                //&& p.PacientesTutelados.Any
        }
        public Persona? GetTutorByDni(string dni)
        {
            using var context = CreateContext();
            return context.Personas
                .FirstOrDefault(p => p.NroDni == dni && p.PacientesTutelados.Any());
        }
        public bool Update(Persona persona)
        {
            using var context = CreateContext();
            var existingPersona = context.Personas.Find(persona.Id);
            if (existingPersona != null)
            {
                existingPersona.SetNombre(persona.Nombre);
                existingPersona.SetApellido(persona.Apellido);
                existingPersona.SetNroDni(persona.NroDni);
                existingPersona.SetDireccion(persona.Direccion);
                existingPersona.SetEmail(persona.Email);
                existingPersona.SetFechaNacimiento(persona.FechaNacimiento);
                existingPersona.SetTelefono(persona.Telefono);

                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DNIExists(string nroDni, int? excludeId = null)
        {
            using var context = CreateContext();
            var query = context.Personas.Where(p => p.NroDni.ToLower() == nroDni.ToLower());
            if (excludeId.HasValue)
            {
                query = query.Where(p => p.Id != excludeId.Value);
            }
            return query.Any();
        }
        public IEnumerable<Paciente> GetPacientesByTutorId(int tutorId)
        {
            using var context = CreateContext();
            return context.Pacientes
                .Where(p => p.TutorId == tutorId)
                .ToList();
        }

    }
}