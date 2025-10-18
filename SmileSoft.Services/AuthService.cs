using DTO;
using Microsoft.Extensions.Configuration;
using SmileSoft.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmileSoft.Services
{
    public class AuthService
    {
        private readonly UsuarioRepository usuarioRepository;
        private readonly IConfiguration configuration;

        public AuthService(IConfiguration configuration)
        {
            usuarioRepository = new UsuarioRepository();
            this.configuration = configuration;
        }

        public async Task<LoginResponse?> LoginAsync(LoginRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
                return null;

            var usuario = usuarioRepository.GetByUsername(request.Username);

            if (usuario == null || !usuario.ValidatePassword(request.Password))
                return null;
            //if (usuario == null || !usuario.ValidatePassword(request.Password))
            //    return null;


            return new LoginResponse
            {
                Username = usuario.Username,
                Rol = usuario.Rol
            };
        }
    }
}
