using DTO;
using SmileSoft.Dominio;
using System.Net.Http.Headers;
using System.Text;  
using System.Text.Json;

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

        public async static Task<LoginResponse?> LoginAsync(LoginRequest request)
        {

            var json = JsonSerializer.Serialize(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("auth/login", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<LoginResponse>(responseContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }

            return null;


        }
    }
}
