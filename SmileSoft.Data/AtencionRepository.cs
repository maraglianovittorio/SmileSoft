using SmileSoft.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

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

        public IEnumerable<Atencion> GetAllByRangoAndOdo(DateTime startDate, DateTime endDate, int id)
        {
            using var context = CreateContext();
            return context.Atenciones
                .Include(a => a.Odontologo)
                .Include(a => a.Paciente)
                .Include(a => a.TipoAtencion)
                .Where(a => a.FechaHoraAtencion >= startDate && a.FechaHoraAtencion <= endDate && a.OdontologoId == id)
                .ToList();
        }

        public bool Update(Atencion atencion, int id)
        {
            using var context = CreateContext();
            var existingAtencion = context.Atenciones.Find(id);
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
                existingAtencion.AppendObservacion(observaciones);
                context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool CancelaAtencion(int id) {
            using var context = CreateContext();
            var existingAtencion = context.Atenciones.Find(id);
            if (existingAtencion != null)
            {
                existingAtencion.SetEstado("Cancelada");
                context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool ActualizaLlegada(int id)
        {
            using var context = CreateContext();
            var existingAtencion = context.Atenciones.Find(id);
            if (existingAtencion != null) {
                existingAtencion.SetEstado("En sala de espera");
                context.SaveChanges();
                return true;
            }
            return false;
        }
        //consulta con ADO.NET
        public IEnumerable<Atencion> GetByCriteria(AtencionCriteria atencionCriteria)
        {
            using var context = CreateContext();
            const string sql = @"
                SELECT a.Id, a.OdontologoId, a.PacienteId, a.TipoAtencionId, a.FechaHoraAtencion, a.Estado
                FROM Atenciones a
                WHERE a.OdontologoId = @SearchTerm
                   OR a.PacienteId = @SearchTerm
                   OR a.TipoAtencionId = @SearchTerm
                   OR a.FechaHoraAtencion = @SearchTerm
                   OR a.Estado = @SearchTerm
                ORDER BY a.FechaHoraAtencion";

            var atenciones = new List<Atencion>();
            string connectionString = context.Database.GetConnectionString();
            string searchPattern = $"%{atencionCriteria.Texto}%";

            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@SearchTerm", searchPattern);

            connection.Open();
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var atencion = new Atencion(
                    reader.GetDateTime(0),//fecha y hora de atencion
                    reader.GetString(1),//estado
                    reader.GetString(2),//observaciones
                    reader.GetInt32(3),//id del odontologo,
                    reader.GetInt32(4),//id del paciente,
                    reader.GetInt32(5)//id del tipo de atencion
                );

                atenciones.Add(atencion);
            }

            return atenciones;
        }



    }
}