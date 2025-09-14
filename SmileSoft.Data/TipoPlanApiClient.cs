using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmileSoft.Dominio;

namespace SmileSoft.Data
{
    public class TipoPlanApiClient
    {
        private MiDbContext CreateContext()
        {
            return new MiDbContext();
        }

        public void Add(TipoPlan tipoPlan)
        {
            using var context = CreateContext();
            context.TipoPlanes.Add(tipoPlan);
            context.SaveChanges();
        }

        public bool Delete(int id)
        {
            using var context = CreateContext();
            var tipoPlan = context.TipoPlanes.Find(id);
            if (tipoPlan != null)
            {
                context.TipoPlanes.Remove(tipoPlan);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public TipoPlan? Get(int id)
        {
            using var context = CreateContext();
            return context.TipoPlanes
                //.Include(p => )
                .FirstOrDefault(tp => tp.Id == id);
        }

        public IEnumerable<TipoPlan> GetAll()
        {
            using var context = CreateContext();
            return context.TipoPlanes
                //.Include(c => c.Pais)
                .ToList();
        }

        public bool Update(TipoPlan tipoPlan)
        {
            using var context = CreateContext();
            var existingTipoPlan = context.TipoPlanes.Find(tipoPlan.Id);
            if (existingTipoPlan != null)
            {
                existingTipoPlan.Nombre = tipoPlan.Nombre;
                existingTipoPlan.Descripcion = tipoPlan.Descripcion;
                existingTipoPlan.ObraSocial = tipoPlan.ObraSocial; //esto iria o no se deberia poder cambiar?

                context.SaveChanges();
                return true;
            }
            return false;
        }
        // valido que el id de obra social que se pone al agregar exista(hace falta?)
        public bool ValidaOS(int idOS)
        {
            using var context = CreateContext();
            var existe = context.ObrasSociales.Any(os => os.Id == idOS);
            return existe;
        }
        // valido que no exista ya un plan con ese nombre para esa obra social
        public bool TipoPlanExists(string nombre, int idOS, int? excludeId = null)
        {
            using var context = CreateContext();
            return context.TipoPlanes.Any(tp => tp.Nombre == nombre && tp.ObraSocial.Id == idOS && (!excludeId.HasValue || tp.Id != excludeId.Value));
        }
    }
}
