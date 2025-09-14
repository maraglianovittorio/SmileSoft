using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

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
        public async static Task Login(string username, string password)
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
                    //var result = await response.Content.ReadAsAsync<Dictionary<string, string>>();
                    //if (result != null && result.ContainsKey("token"))
                    //{
                    //    string token = result["token"];
                    //    // Aquí puedes almacenar el token para usarlo en futuras solicitudes
                    //    Console.WriteLine("Login exitoso. Token: " + token);
                    //}
                    //else
                    //{
                    //    throw new Exception("Respuesta inesperada del servidor.");
                    //}
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error de autenticación. Status: {response.StatusCode}, Detalle: {errorContent}");
                
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
