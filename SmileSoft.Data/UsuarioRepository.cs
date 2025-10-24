using DTO;
using Microsoft.EntityFrameworkCore;
using SmileSoft.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmileSoft.Data
{
    public class UsuarioRepository
    {
        private MiDbContext CreateContext()
        {
            return new MiDbContext();
        }

        public void Add(Usuario usuario)
        {
            using var context = CreateContext();
            context.Usuarios.Add(usuario);
            context.SaveChanges();
        }

        public bool Delete(int id)
        {
            using var context = CreateContext();
            var usuario = context.Usuarios.Find(id);
            if (usuario != null)
            {
                context.Usuarios.Remove(usuario);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Usuario? Get(int id)
        {
            using var context = CreateContext();
            return context.Usuarios
                //.Include(p => )
                .FirstOrDefault(u => u.Id == id);
        }

        public Usuario? GetByUsername(string username)
        {
            using var context = CreateContext();
            return context.Usuarios
                .AsEnumerable()
                .FirstOrDefault(u => string.Equals(u.Username,username,StringComparison.Ordinal));
        }
        public async Task<Usuario?> GetByUsernameAsync(string username)
        {
            using var context = CreateContext();
            return await context.Usuarios.FirstOrDefaultAsync(u => string.Equals(u.Username,username,StringComparison.Ordinal));
        }

        public IEnumerable<Usuario> GetAll()
        {
            using var context = CreateContext();
            return context.Usuarios
                //.Include(c => c.Pais)
                .ToList();
        }

        public bool Update(Usuario usuario)
        {
            using var context = CreateContext();
            context.Usuarios.Update(usuario);
            context.SaveChanges();
            return true;
        }

        public bool UsernameExists(string username, int? excludeId = null)
        {
            using var context = CreateContext();
            var query = context.Usuarios.Where(u => u.Username.ToLower() == username.ToLower());
            if (excludeId.HasValue)
            {
                query = query.Where(u => u.Id != excludeId.Value);
            }
            return query.Any();
        }

        //public Usuario? ValidateCredentials(string username, string password)
        //{
        //    using var context = CreateContext();
        //    return context.Usuarios.FirstOrDefault(u => 
        //        u.Username.ToLower() == username.ToLower() && 
        //        u.Password == password);
        //}
    }
}
