using SmileSoft.DTO;
using SmileSoft.Dominio;
using System.Net.Http.Headers;
using System.Text;  
using System.Text.Json;

namespace SmileSoft.API.Clients
{
    public class AuthApiClient : BaseApiClient
    {
        public async static Task<LoginResponse?> LoginAsync(LoginRequest request)
        {
            using var httpClient = await CreateHttpClientAsync();
            var json = JsonSerializer.Serialize(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.PostAsync("auth/login", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<LoginResponse>(responseContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new Exception("Error interno del servidor. Por favor, intente nuevamente más tarde.");
            }

            return null;
        }
    }
}
