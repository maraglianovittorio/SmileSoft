﻿using SmileSoft.DTO;
using SmileSoft.API.Clients;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SmileSoft.API.Auth.WindowsForms
{
    public class WindowsFormsAuthService : IAuthService
    {
        private static string? _currentToken;
        private static DateTime _tokenExpiration;
        private static string? _currentUsername;

        public event Action<bool>? AuthenticationStateChanged;

        public async Task<bool> IsAuthenticatedAsync()
        {
            return !string.IsNullOrEmpty(_currentToken) && DateTime.UtcNow < _tokenExpiration;
        }

        public async Task<string?> GetTokenAsync()
        {
            var isAuth = await IsAuthenticatedAsync();
            return isAuth ? _currentToken : null;
        }

        public async Task<string?> GetUsernameAsync()
        {
            var isAuth = await IsAuthenticatedAsync();
            return isAuth ? _currentUsername : null;
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
                _currentToken = response.Token;
                _tokenExpiration = response.ExpiresAt;
                _currentUsername = response.Username;

                AuthenticationStateChanged?.Invoke(true);
                return true;
            }

            return false;
        }

        public async Task LogoutAsync()
        {
            _currentToken = null;
            _tokenExpiration = default;
            _currentUsername = null;

            AuthenticationStateChanged?.Invoke(false);
        }

        public async Task CheckTokenExpirationAsync()
        {
            if (!string.IsNullOrEmpty(_currentToken) && DateTime.UtcNow >= _tokenExpiration)
            {
                await LogoutAsync();
            }
        }

        public async Task<bool> HasPermissionAsync(string permission)
        {
            var token = await GetTokenAsync();
            if (string.IsNullOrEmpty(token))
                return false;

            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadJwtToken(token);

                // Buscar claims de "permission" 
                var permissionClaims = jsonToken.Claims
                    .Where(c => c.Type == "permission")
                    .Select(c => c.Value);

                return permissionClaims.Contains(permission);
            }
            catch
            {
                return false;
            }
        }

        public async Task<string?> GetRolAsync()
        {
            var token = await GetTokenAsync();
            if (string.IsNullOrEmpty(token))
                return null;

            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadJwtToken(token);

                // Buscar claims de "role"
                var roleClaim = jsonToken.Claims.FirstOrDefault(c => c.Type == "role");
                return roleClaim?.Value;
            }
            catch
            {
                return null;
            }
        }

        public async Task<string?> GetOdontologoNombreCompletoAsync()
        {
            // Sin implementación por ahora
            return null;
        }

        public async Task<int?> GetOdontologoIdAsync()
        {
            // Sin implementación por ahora
            return null;
        }
    }
}