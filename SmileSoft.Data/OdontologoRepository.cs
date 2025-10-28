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
                try { 
                    context.Odontologos.Remove(odontologo);
                    context.SaveChanges();
                    return true;
                }
                catch (DbUpdateException)
                {
                    throw new Exception("No se puede eliminar el odontólogo porque tiene registros relacionados.");
                }
            }
            return false;
        }

        public Odontologo? Get(int id)
        {
            using var context = CreateContext();
            return context.Odontologos
                .Include(o => o.ObrasSociales) 
                .Include(o => o.Usuario)
                .Include(o => o.Atenciones)
                .FirstOrDefault(o => o.Id == id);
        }

        public IEnumerable<Odontologo> GetAll()
        {
            using var context = CreateContext();
            return context.Odontologos
                .Include(o => o.ObrasSociales) // Incluir ObrasSociales
                .Include(o => o.Usuario)
                .Include(o => o.Atenciones)
                .ToList();
        }

        public bool Update(Odontologo odontologo,int id)
        {
            using var context = CreateContext();
            var existingOdontologo = context.Odontologos.Find(id);
            if (existingOdontologo != null)
            {
                existingOdontologo.SetNombre(odontologo.Nombre);
                existingOdontologo.SetApellido(odontologo.Apellido);
                existingOdontologo.SetNroMatricula(odontologo.NroMatricula);
                existingOdontologo.SetEmail(odontologo.Email);
                existingOdontologo.SetTelefono(odontologo.Telefono);
                existingOdontologo.SetDireccion(odontologo.Direccion);
                existingOdontologo.SetNroDni(odontologo.NroDni);
                existingOdontologo.SetFechaNacimiento(odontologo.FechaNacimiento);
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

       
        public Odontologo? GetByUsuarioId(int usuarioId)
        {
            using var context = CreateContext();
            return context.Odontologos
                .FirstOrDefault(o => o.UsuarioId == usuarioId);
        }
    }
}