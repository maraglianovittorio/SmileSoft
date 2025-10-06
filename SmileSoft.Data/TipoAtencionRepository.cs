using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmileSoft.Dominio;
using Microsoft.EntityFrameworkCore;

namespace SmileSoft.Data
{
    public class TipoAtencionRepository
    {
        private MiDbContext CreateContext()
        {
            return new MiDbContext();
        }

        public void Add(TipoAtencion tipoAtencion)
        {
            using var context = CreateContext();
            context.TipoAtenciones.Add(tipoAtencion);
            context.SaveChanges();
        }

        public bool Delete(int id)
        {
            using var context = CreateContext();
            var tipoAtencion = context.TipoAtenciones.Find(id);
            if (tipoAtencion != null)
            {
                context.TipoAtenciones.Remove(tipoAtencion);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public TipoAtencion? Get(int id)
        {
            using var context = CreateContext();
            return context.TipoAtenciones
                .FirstOrDefault(ta => ta.Id == id);
        }

        public IEnumerable<TipoAtencion> GetAll()
        {
            using var context = CreateContext();
            return context.TipoAtenciones.ToList();
        }

        public bool Update(TipoAtencion tipoAtencion)
        {
            using var context = CreateContext();
            var existingTipoAtencion = context.TipoAtenciones.Find(tipoAtencion.Id);
            if (existingTipoAtencion != null)
            {
                existingTipoAtencion.Descripcion = tipoAtencion.Descripcion;
                existingTipoAtencion.Duracion = tipoAtencion.Duracion;

                context.SaveChanges();
                return true;
            }
            return false;
        }


        // valido que no exista un tipo de atencion con ese nombre
        public bool TipoAtencionExists(string descripcion, int? excludeId = null)
        {
            using var context = CreateContext();
            return context.TipoAtenciones.Any(ta => ta.Descripcion == descripcion && (excludeId == null || ta.Id != excludeId));
        }
    }
}
