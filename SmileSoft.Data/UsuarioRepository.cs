using SmileSoft.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

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
            var usuario = context.Usuarios.FirstOrDefault(u => u.Username.ToLower() == username.ToLower());
            if (usuario == null) return null;

            return new Usuario
            {
                Id = usuario.Id,
                Username = usuario.Username,
                Password = usuario.Password,
                Rol = usuario.Rol
            };
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
            var existingUsuario = context.Usuarios.Find(usuario.Id);
            if (existingUsuario != null)
            {
                existingUsuario.Username = usuario.Username;
                existingUsuario.Password = usuario.Password;
                existingUsuario.Rol = usuario.Rol;

                context.SaveChanges();
                return true;
            }
            return false;
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

        public Usuario? ValidateCredentials(string username, string password)
        {
            using var context = CreateContext();
            return context.Usuarios.FirstOrDefault(u => 
                u.Username.ToLower() == username.ToLower() && 
                u.Password == password);
        }
    }
}
