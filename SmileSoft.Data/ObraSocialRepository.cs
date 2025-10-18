using SmileSoft.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;

namespace SmileSoft.Data
{
    public class ObraSocialRepository
    {
        private MiDbContext CreateContext()
        {
            return new MiDbContext();
        }

        public void Add(ObraSocial obraSocial)
        {
            using var context = CreateContext();
            context.ObrasSociales.Add(obraSocial);
            context.SaveChanges();
        }

        public bool Delete(int id)
        {
            using var context = CreateContext();
            var obraSocial = context.ObrasSociales.Find(id);
            if (obraSocial != null)
            {
                context.ObrasSociales.Remove(obraSocial);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public ObraSocial? Get(int id)
        {
            using var context = CreateContext();
            return context.ObrasSociales
                //.Include(p => )
                .FirstOrDefault(os => os.Id == id);
        }
        public ObraSocial? GetByName(string nombre)
        {
            using var context = CreateContext();
            return context.ObrasSociales
                .Include(os => os.TipoPlanes)
                .FirstOrDefault(os => os.Nombre.ToLower() == nombre.ToLower());
                
        }

        public IEnumerable<ObraSocial> GetAll()
        {
            using var context = CreateContext();
            return context.ObrasSociales
                //.Include(c => c.Pais)
                .ToList();
        }

        public bool Update(ObraSocial obraSocial)
        {
            using var context = CreateContext();
            var existingObraSocial = context.ObrasSociales.Find(obraSocial.Id);
            if (existingObraSocial != null)
            {
                existingObraSocial.SetNombre(obraSocial.Nombre);

                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool OSExists(string nombre, int? excludeId = null)
        {
            using var context = CreateContext();
            var query = context.ObrasSociales.Where(os => os.Nombre.ToLower() == nombre.ToLower());
            if (excludeId.HasValue)
            {
                query = query.Where(os => os.Id != excludeId.Value);
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