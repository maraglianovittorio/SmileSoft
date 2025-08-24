using DTO;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

namespace SmileSoft.API.Clients
{
    public class PacienteApiClient
    {
        private static HttpClient client = new HttpClient();
        static PacienteApiClient()
        {
            client.BaseAddress = new Uri("https://localhost:7173/api/Paciente/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public static async Task<string> GetAllAsync()
        {
            HttpResponseMessage response = await client.GetAsync("GetAll");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return data;
            }
            return null;
        }
        public static async Task<string> GetByIdAsync(int id)
        {
            HttpResponseMessage response = await client.GetAsync($"GetById/{id}");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return data;
            }
            return null;
        }
        public async static Task CreateAsync(PacienteDTO paciente)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("pacientes", paciente);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al crear el paciente. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al crear paciente: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al crear paciente: {ex.Message}", ex);
            }


        
        }
       public static async Task<bool> DeleteAsync(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"Delete/{id}");
            return response.IsSuccessStatusCode;
        }
       public static async Task<string> UpdateAsync(int id, string pacienteJson)
        {
            var content = new StringContent(pacienteJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync($"Update/{id}", content);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return data;
            }
            return null;
        }
    }
}
