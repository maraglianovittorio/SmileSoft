using DTO;
using SmileSoft.Dominio;
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

            client.BaseAddress = new Uri("https://localhost:54145/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public static async Task<IEnumerable<PacienteDTO>> GetAllAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("pacientes");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<IEnumerable<PacienteDTO>>();
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener lista de pacientes. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener lista de pacientes: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener lista de pacientes: {ex.Message}", ex);
            }
        }
        public static async Task<Paciente> GetOneAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"pacientes/id?id={id}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<Paciente>();
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener paciente con Id {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener paciente con Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener paciente con Id {id}: {ex.Message}", ex);
            }
        }
        public static async Task<Paciente> GetByDni(string dni)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"pacientes/dni?dni={dni}");
                if(response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<Paciente>();
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener paciente con DNI {dni}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch(HttpRequestException ex) {
                throw new Exception($"Error de conexión al obtener paciente con DNI {dni}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener paciente con DNI {dni}: {ex.Message}", ex);
            }
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
        public static async Task DeleteAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync($"pacientes/id?id={id}");

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al eliminar paciente con Id {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al eliminar paciente con Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al eliminar paciente con Id {id}: {ex.Message}", ex);
            }
        }
        public static async Task UpdateAsync(PacienteDTO paciente,int id)
        {
            try
            {

                HttpResponseMessage response = await client.PutAsJsonAsync($"pacientes/{id}", paciente);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al actualizar paciente con Id {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al actualizar paciente con Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al actualizar paciente con Id {id}: {ex.Message}", ex);
            }
        }
    }
}
