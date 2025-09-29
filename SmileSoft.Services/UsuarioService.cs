using DTO;
using SmileSoft.Data;
using SmileSoft.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmileSoft.Services
{
    public class UsuarioService
    {
        public UsuarioCreateDTO Add(UsuarioCreateDTO dto)
        {
            var usuarioRepository = new UsuarioRepository();
            // Validar que el nombre de usuario no exista
            if (usuarioRepository.UsernameExists(dto.Username))
            {
                throw new Exception("Ya existe un usuario con el mismo nombre de usuario.");
            }
            
            Usuario usuario = new Usuario(dto.Username, dto.Password, dto.Rol);
            usuarioRepository.Add(usuario);

            return dto;
        }
        
        public bool Delete(int id)
        {
            var usuarioRepository = new UsuarioRepository();
            return usuarioRepository.Delete(id);
        }
        
        public UsuarioUpdateDTO GetUsuario(int id)
        {
            var usuarioRepository = new UsuarioRepository();
            Usuario? usuario = usuarioRepository.Get(id);
            if (usuario == null)
            {
                throw new Exception("No se encontró el usuario.");
            }
            return new UsuarioUpdateDTO
            {
                Id = usuario.Id,
                Password = usuario.Password,
                Username = usuario.Username,
                Rol = usuario.Rol
            };
        }
        
        public IEnumerable<UsuarioDTO> GetAll()
        {
            var usuarioRepository = new UsuarioRepository();
            var usuarios = usuarioRepository.GetAll();
            return usuarios.Select(u => new UsuarioDTO
            {
                Id = u.Id,
                Username = u.Username,
                Rol = u.Rol
            }).ToList();
        }
        
        public bool Update(int id, UsuarioUpdateDTO dto)
        {
            var usuarioRepository = new UsuarioRepository();
            // Validar que el nombre de usuario no exista en otro usuario
            if (usuarioRepository.UsernameExists(dto.Username, id))
            {
                throw new ArgumentException($"Ya existe otro usuario con el nombre de usuario '{dto.Username}'.");
            }
            
            Usuario usuario = new Usuario
            {
                Id = id,
                Username = dto.Username,
                Password = dto.Password,
                Rol = dto.Rol
            };
            return usuarioRepository.Update(usuario);
        }

        public Usuario? ValidateCredentials(string username, string password)
        {
            var usuarioRepository = new UsuarioRepository();
            return usuarioRepository.ValidateCredentials(username, password);
        }
        public Usuario? GetByUsername(string username)
        {
            var usuarioRepository = new UsuarioRepository();
            return usuarioRepository.GetByUsername(username);
        }
    }
}
