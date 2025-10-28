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


    }
}