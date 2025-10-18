using SmileSoft.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;

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
            var cliente = context.Pacientes.Find(id);
            if (cliente != null)
            {
                context.Pacientes.Remove(cliente);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Paciente? Get(int id)
        {
            using var context = CreateContext();
            return context.Pacientes
                .Include(p => p.TipoPlan)
                .FirstOrDefault(p => p.Id == id);
        }
        public Paciente? GetByDni(string dni)
        {
            using var context = CreateContext();
            return context.Pacientes
                .Include(p => p.TipoPlan)
                .FirstOrDefault(p => p.NroDni == dni);
        }

        public IEnumerable<Paciente> GetAll()
        {
            using var context = CreateContext();
            return context.Pacientes
                .Include(p => p.TipoPlan)
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

        //public IEnumerable<Paciente> GetByCriteria(PacienteCriteria criteria)
        //{
        //    const string sql = @"
        //        SELECT c.Id, c.Nombre, c.Apellido, c.Email, c.PaisId, c.FechaAlta,
        //               p.Nombre as PaisNombre
        //        FROM Pacientes c
        //        INNER JOIN Paises p ON c.PaisId = p.Id
        //        WHERE c.Nombre LIKE @SearchTerm 
        //           OR c.Apellido LIKE @SearchTerm 
        //           OR c.Email LIKE @SearchTerm
        //        ORDER BY c.Nombre, c.Apellido";

        //    var pacientes = new List<Paciente>();
        //    string connectionString = new TPIContext().Database.GetConnectionString();
        //    string searchPattern = $"%{criteria.Texto}%";

        //    using var connection = new SqlConnection(connectionString);
        //    using var command = new SqlCommand(sql, connection);

        //    command.Parameters.AddWithValue("@SearchTerm", searchPattern);

        //    connection.Open();
        //    using var reader = command.ExecuteReader();

        //    while (reader.Read())
        //    {
        //        var cliente = new Cliente(
        //            reader.GetInt32(0),    // Id
        //            reader.GetString(1),   // Nombre
        //            reader.GetString(2),   // Apellido
        //            reader.GetString(3),   // Email
        //            reader.GetInt32(4),    // PaisId
        //            reader.GetDateTime(5)  // FechaAlta
        //        );

        //        // Crear y asignar el País
        //        var pais = new Pais(reader.GetInt32(4), reader.GetString(6)); // PaisId, PaisNombre
        //        cliente.SetPais(pais);

        //        clientes.Add(cliente);
        //    }

        //    return clientes;
        //}

    }
}