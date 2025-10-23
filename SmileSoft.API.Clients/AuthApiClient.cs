using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using SmileSoft.Dominio;
using DTO;

namespace SmileSoft.API.Clients
{
    public class AuthApiClient
    {
        private static HttpClient client = new HttpClient();
        static AuthApiClient()
        {
            client.BaseAddress = new Uri("https://localhost:54145/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        
        public async static Task<LoginResponse?> LoginAsync(string username, string password)
        {
            try
            {
                var credentials = new
                {
                    Username = username,
                    Password = password
                };
                
                HttpResponseMessage response = await client.PostAsJsonAsync("auth/login", credentials);
                
                if (response.IsSuccessStatusCode)
                {
                    // Login exitoso - obtener información del usuario
                    UsuarioDTO user = await UsuarioApiClient.GetByUsernameAsync(username);
                    if (user == null)
                        return null;

                    return new LoginResponse 
                    { 
                        Username = user.Username,
                        Rol = user.Rol,
                        IsSuccess = true
                    };
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    // Credenciales inválidas - devolver null
                    return null;
                }
                else
                {
                    // Otro tipo de error del servidor
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error del servidor. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión durante la autenticación: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout durante la autenticación: {ex.Message}", ex);
            }
        }
    }
}
