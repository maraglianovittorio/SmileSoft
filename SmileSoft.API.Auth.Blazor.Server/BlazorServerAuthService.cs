using SmileSoft.DTO;
using SmileSoft.API.Clients;
using System.IdentityModel.Tokens.Jwt;

namespace SmileSoft.API.Auth.Blazor.Server
{
    public class BlazorServerAuthService : IAuthService
    {
        // Almacenamiento global para el usuario actual (singleton per app)
        private SessionData? _currentSession;

        public event Action<bool>? AuthenticationStateChanged;

        public BlazorServerAuthService()
        {
        }

        private class SessionData
        {
            public string? Token { get; set; }
            public string? Username { get; set; }
            public string? Rol { get; set; }
            public DateTime Expiration { get; set; }
            
            // Datos del odontólogo
            public int? OdontologoId { get; set; }
            public string? OdontologoNombre { get; set; }
            public string? OdontologoApellido { get; set; }
            
            // AGREGAR: Datos del paciente
            public int? PacienteId { get; set; }
            public string? PacienteNombre { get; set; }
            public string? PacienteApellido { get; set; }
            public string? NroHistoriaClinica { get; set; }
        }

        public Task<bool> IsAuthenticatedAsync()
        {
            try
            {
                if (_currentSession != null)
                {
                    return Task.FromResult(!string.IsNullOrEmpty(_currentSession.Token) && DateTime.UtcNow < _currentSession.Expiration);
                }
                return Task.FromResult(false);
            }
            catch
            {
                return Task.FromResult(false);
            }
        }

        public Task<string?> GetTokenAsync()
        {
            try
            {
                return Task.FromResult(_currentSession?.Token);
            }
            catch
            {
                return Task.FromResult<string?>(null);
            }
        }

        public Task<string?> GetUsernameAsync()
        {
            try
            {
                return Task.FromResult(_currentSession?.Username);
            }
            catch
            {
                return Task.FromResult<string?>(null);
            }
        }

        public Task<string?> GetRolAsync()
        {
            try
            {
                return Task.FromResult(_currentSession?.Rol);
            }
            catch
            {
                return Task.FromResult<string?>(null);
            }
        }

        public Task<int?> GetOdontologoIdAsync()
        {
            try
            {
                return Task.FromResult(_currentSession?.OdontologoId);
            }
            catch
            {
                return Task.FromResult<int?>(null);
            }
        }

        public Task<string?> GetOdontologoNombreCompletoAsync()
        {
            try
            {
                if (_currentSession?.OdontologoNombre != null && _currentSession?.OdontologoApellido != null)
                {
                    return Task.FromResult<string?>($"{_currentSession.OdontologoNombre} {_currentSession.OdontologoApellido}");
                }
                return Task.FromResult<string?>(null);
            }
            catch
            {
                return Task.FromResult<string?>(null);
            }
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            var request = new LoginRequest
            {
                Username = username,
                Password = password
            };

            var response = await AuthApiClient.LoginAsync(request);

            if (response != null)
            {
                _currentSession = new SessionData
                {
                    Token = response.Token,
                    Username = response.Username,
                    Rol = response.Rol,
                    Expiration = response.ExpiresAt,
                    OdontologoId = response.OdontologoId,
                    OdontologoNombre = response.OdontologoNombre,
                    OdontologoApellido = response.OdontologoApellido,
                    // AGREGAR:
                    PacienteId = response.PacienteId,
                    PacienteNombre = response.PacienteNombre,
                    PacienteApellido = response.PacienteApellido,
                    NroHistoriaClinica = response.NroHistoriaClinica
                };

                AuthenticationStateChanged?.Invoke(true);
                return true;
            }

            return false;
        }

        public Task LogoutAsync()
        {
            _currentSession = null;
            AuthenticationStateChanged?.Invoke(false);
            return Task.CompletedTask;
        }

        public async Task CheckTokenExpirationAsync()
        {
            if (!await IsAuthenticatedAsync())
            {
                await LogoutAsync();
            }
        }

        public Task<bool> HasPermissionAsync(string permission)
        {
            try
            {
                var token = _currentSession?.Token;
                if (string.IsNullOrEmpty(token))
                    return Task.FromResult(false);

                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadJwtToken(token);

                var permissionClaims = jsonToken.Claims
                    .Where(c => c.Type == "permission")
                    .Select(c => c.Value);

                return Task.FromResult(permissionClaims.Contains(permission));
            }
            catch
            {
                return Task.FromResult(false);
            }
        }

        // AGREGAR métodos:
        public Task<int?> GetPacienteIdAsync()
        {
            return Task.FromResult(_currentSession?.PacienteId);
        }

        public Task<string?> GetPacienteNombreCompletoAsync()
        {
            if (_currentSession?.PacienteNombre != null && _currentSession?.PacienteApellido != null)
            {
                return Task.FromResult<string?>($"{_currentSession.PacienteNombre} {_currentSession.PacienteApellido}");
            }
            return Task.FromResult<string?>(null);
        }
        public Task<string?> GetNroHistoriaClinicaAsync()
        {
            return Task.FromResult(_currentSession?.NroHistoriaClinica);
        }
    }
}