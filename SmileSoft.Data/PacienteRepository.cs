using SmileSoft.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace SmileSoft.Data
{
    public class PacienteRepository
    {
        private MiDbContext CreateContext()
        {
            return new MiDbContext();
        }

        public void Add(Paciente paciente)
        {
            using var context = CreateContext();
            context.Pacientes.Add(paciente);
            context.SaveChanges();
        }

        public bool Delete(int id)
        {
            using var context = CreateContext();
            var paciente = context.Pacientes.Find(id);
            if (paciente != null)
            {
                try
                {
                    context.Pacientes.Remove(paciente);
                    context.SaveChanges();
                    return true;
                
                }
                catch (DbUpdateException)
                {
                    throw new Exception("No se puede eliminar el paciente porque tiene registros relacionados.");
                }
            }
            return false;
        }

        public Paciente? Get(int id)
        {
            using var context = CreateContext();
            return context.Pacientes
                .Include(p => p.TipoPlan)
                .Include(p => p.Atenciones)
                .FirstOrDefault(p => p.Id == id);
        }
        public Paciente? GetByDni(string dni)
        {
            using var context = CreateContext();
            return context.Pacientes
                .Include(p => p.TipoPlan)
                .Include(p => p.Atenciones)
                .FirstOrDefault(p => p.NroDni == dni);
        }

        public IEnumerable<Paciente> GetAll()
        {
            using var context = CreateContext();
            return context.Pacientes
                .Include(p => p.TipoPlan)
                .Include(p => p.Atenciones)
                .ToList();
        }

        public bool Update(Paciente paciente)
        {
            using var context = CreateContext();
            var existingPaciente = context.Pacientes.Find(paciente.Id);
            if (existingPaciente != null)
            {
                existingPaciente.SetNombre(paciente.Nombre);
                existingPaciente.SetApellido(paciente.Apellido);
                existingPaciente.SetNroDni(paciente.NroDni);
                existingPaciente.SetDireccion(paciente.Direccion);
                existingPaciente.SetEmail(paciente.Email);
                existingPaciente.SetFechaNacimiento(paciente.FechaNacimiento);
                existingPaciente.SetTelefono(paciente.Telefono);
                existingPaciente.SetNroAfiliado(paciente.NroAfiliado);
                existingPaciente.SetNroHC(paciente.NroHC);
                existingPaciente.SetTipoPlanId(paciente.TipoPlanId);
                existingPaciente.SetTutorId(paciente.TutorId);

                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool HCExists(string nroHC, int? excludeId = null)
        {
            using var context = CreateContext();
            var query = context.Pacientes.Where(p => p.NroHC.ToLower() == nroHC.ToLower());
            if (excludeId.HasValue)
            {
                query = query.Where(p => p.Id != excludeId.Value);
            }
            return query.Any();
        }

    }
}