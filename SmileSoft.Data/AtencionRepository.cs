using SmileSoft.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;

namespace SmileSoft.Data
{
    public class AtencionRepository
    {
        private MiDbContext CreateContext()
        {
            return new MiDbContext();
        }

        public void Add(Atencion atencion)
        {
            using var context = CreateContext();
            context.Atenciones.Add(atencion);
            context.SaveChanges();
        }

        public bool Delete(int id)
        {
            using var context = CreateContext();
            var atencion = context.Atenciones.Find(id);
            if (atencion != null)
            {
                context.Atenciones.Remove(atencion);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Atencion? Get(int id)
        {
            using var context = CreateContext();
            return context.Atenciones
                .Include(a => a.Odontologo)
                .Include(a => a.Paciente)
                .Include(a => a.TipoAtencion)
                .FirstOrDefault(a => a.Id == id);
        }
        public IEnumerable<Atencion>? GetByEstado(string estado)
        {
            using var context = CreateContext();
            return context.Atenciones
                .Include(a => a.Odontologo)
                .Include(a => a.Paciente)
                .Include(a => a.TipoAtencion)
                .Where(a => a.Estado.ToLower() == estado.ToLower())
                .ToList();
        }
        public IEnumerable<Atencion> GetAllByPaciente(int pacienteId)
        {
            using var context = CreateContext();
            return context.Atenciones
                .Include(a => a.Odontologo)
                .Include(a => a.Paciente)
                .Include(a => a.TipoAtencion)
                .Where(a => a.PacienteId == pacienteId)
                .ToList();
        }
        public IEnumerable<Atencion> GetAllByOdontologo(int odontologoId)
        {
            using var context = CreateContext();
            return context.Atenciones
                .Include(a => a.Odontologo)
                .Include(a => a.Paciente)
                .Include(a => a.TipoAtencion)
                .Where(a => a.OdontologoId == odontologoId)
                .ToList();
        }
        public IEnumerable<Atencion> GetAllByTipoAtencion(int tipoAtencionId)
        {
            using var context = CreateContext();
            return context.Atenciones
                .Include(a => a.Odontologo)
                .Include(a => a.Paciente)
                .Include(a => a.TipoAtencion)
                .Where(a => a.TipoAtencionId == tipoAtencionId)
                .ToList();
        }
        public IEnumerable<Atencion> GetAll()
        {
            using var context = CreateContext();
            return context.Atenciones
                .Include(a => a.Odontologo)
                .Include(a => a.Paciente)
                .Include(a => a.TipoAtencion)
                .ToList();
        }

        public IEnumerable<Atencion> GetAllByRango(DateTime startDate, DateTime endDate)
        {
            using var context = CreateContext();
            return context.Atenciones
                .Include(a => a.Odontologo)
                .Include(a => a.Paciente)
                .Include(a => a.TipoAtencion)
                .Where(a => a.FechaHoraAtencion >= startDate && a.FechaHoraAtencion <= endDate)
                .ToList();
        }

        public IEnumerable<Atencion> GetAllByRangoAndOdo(DateTime startDate, DateTime endDate,int id)
        {
            using var context = CreateContext();
            return context.Atenciones
                .Include(a => a.Odontologo)
                .Include(a => a.Paciente)
                .Include(a => a.TipoAtencion)
                .Where(a => a.FechaHoraAtencion >= startDate && a.FechaHoraAtencion <= endDate && a.OdontologoId == id)
                .ToList();
        }

        public bool Update(Atencion atencion)
        {
            using var context = CreateContext();
            var existingAtencion = context.Atenciones.Find(atencion.Id);
            if (existingAtencion != null)
            {
                existingAtencion.SetOdontologoId(atencion.OdontologoId);
                existingAtencion.SetPacienteId(atencion.PacienteId);
                existingAtencion.SetTipoAtencionId(atencion.TipoAtencionId);
                existingAtencion.SetFechaHoraAtencion(atencion.FechaHoraAtencion);
                existingAtencion.SetEstado(atencion.Estado);

                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateObservaciones(int id, string observaciones)
        {
            using var context = CreateContext();
            var existingAtencion = context.Atenciones.Find(id);
            if (existingAtencion != null)
            {
                existingAtencion.SetObservaciones(observaciones);
                context.SaveChanges();
                return true;
            }
            return false;
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