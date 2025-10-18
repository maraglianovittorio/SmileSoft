using SmileSoft.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;

namespace SmileSoft.Data
{
    public class OdontologoRepository
    {
        private MiDbContext CreateContext()
        {
            return new MiDbContext();
        }

        public void Add(Odontologo odontologo)
        {
            using var context = CreateContext();
            context.Odontologos.Add(odontologo);
            context.SaveChanges();
        }

        public bool Delete(int id)
        {
            using var context = CreateContext();
            var odontologo = context.Odontologos.Find(id);
            if (odontologo != null)
            {
                context.Odontologos.Remove(odontologo);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Odontologo? Get(int id)
        {
            using var context = CreateContext();
            return context.Odontologos
                .FirstOrDefault(o => o.Id == id);
        }

        public IEnumerable<Odontologo> GetAll()
        {
            using var context = CreateContext();
            return context.Odontologos
                .Include(p => p.ObrasSociales) // Incluir ObrasSociales
                //.Include(p => p.Atenciones)
                .ToList();
        }

        public bool Update(Odontologo odontologo)
        {
            using var context = CreateContext();
            var existingOdontologo = context.Odontologos.Find(odontologo.Id);
            if (existingOdontologo != null)
            {
                existingOdontologo.SetNombre(odontologo.Nombre);
                existingOdontologo.SetApellido(odontologo.Apellido);
                existingOdontologo.SetNroMatricula(odontologo.NroMatricula);
                existingOdontologo.SetEmail(odontologo.Email);
                //existingOdontologo.SetUsername(odontologo.Username);
                //existingOdontologo.SetPassword(odontologo.Password);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool NroMatriculaExists(string nroMatricula, int? excludeId = null)
        {
            using var context = CreateContext();
            var query = context.Odontologos.Where(o => o.NroMatricula.ToLower() == nroMatricula.ToLower());
            if (excludeId.HasValue)
            {
                query = query.Where(o => o.Id != excludeId.Value);
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