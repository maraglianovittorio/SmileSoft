using SmileSoft.DTO;
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
        
        public UsuarioDTO? GetUsuario(int id)
        {
            var usuarioRepository = new UsuarioRepository();
            Usuario? usuario = usuarioRepository.Get(id);
            if (usuario == null)
            {
                throw new Exception("No se encontró el usuario.");
            }
            return new UsuarioDTO
            {
                Id = usuario.Id,
                Username = usuario.Username,
                Rol = usuario.Rol
            };
        }
        public UsuarioDTO? GetByUsername(string username)
        {
            var usuarioRepository = new UsuarioRepository();
            if (usuarioRepository.UsernameExists(username))
            {
                Usuario? usuario = usuarioRepository.GetByUsername(username);
                if (usuario == null)
                {
                    throw new Exception("No se encontró el usuario.");
                }
                return new UsuarioDTO
                {
                    Id = usuario.Id,
                    Username = usuario.Username,
                    Rol = usuario.Rol
                };
            }
            else
            {
                return null;
            }


        }
        public UsuarioUpdateDTO GetUsuarioForUpdate(int id)
        {
            var usuarioRepository = new UsuarioRepository();
            Usuario? usuario = usuarioRepository.Get(id);
            if (usuario == null)
            {
                throw new Exception("No se encontró el usuario.");
            }
            return new UsuarioUpdateDTO
            {
                Username = usuario.Username,
                Password = "",
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
            var usuario = usuarioRepository.GetByUsername(dto.Username);
            if (usuario != null && usuario.Id != id)
            {
                throw new ArgumentException($"Ya existe otro usuario con el nombre de usuario '{dto.Username}'.");
            }
            usuario.SetUsername(dto.Username);
            usuario.SetRol(dto.Rol);
            if (!string.IsNullOrEmpty(dto.Password))
            {
                usuario.SetPassword(dto.Password);
            }
            return usuarioRepository.Update(usuario);
        }
        public bool UpdatePassword(int id, UpdatePasswordDTO dto)
        {
            var usuarioRepository = new UsuarioRepository();
            var pacienteRepository = new PacienteRepository();
            var paciente = pacienteRepository.Get(id);
            var usuario = usuarioRepository.Get(paciente.UsuarioId.Value);
            if (usuario == null)
            {
                throw new Exception("No se encontró el usuario.");
            }
            if (!usuario.ValidatePassword(dto.CurrentPassword))
            {
                throw new Exception("La contraseña actual es incorrecta.");
            }
            usuario.SetPassword(dto.NewPassword);
            return usuarioRepository.Update(usuario);
        }
        //public Usuario? ValidateCredentials(string username, string password)
        //{
        //    var usuarioRepository = new UsuarioRepository();
        //    return usuarioRepository.ValidateCredentials(username, password);
        //}

    }
}
