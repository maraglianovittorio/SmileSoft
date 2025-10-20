using DTO;
using SmileSoft.Dominio;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

namespace SmileSoft.API.Clients
{
    public class PersonaApiClient
    {
        private static HttpClient client = new HttpClient();
        static PersonaApiClient()
        {

            client.BaseAddress = new Uri("https://localhost:54145/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public static async Task<IEnumerable<Persona>> GetAllAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("personas");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<IEnumerable<Persona>>();
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener lista de personas. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener lista de personas: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener lista de personas: {ex.Message}", ex);
            }
        }
        public static async Task<IEnumerable<Persona>> GetAllTutorsAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("personas/tutores");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<IEnumerable<Persona>>();
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener lista de tutores. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener lista de tutores: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener lista de tutores: {ex.Message}", ex);
            }
        }
        public static async Task<Persona> GetTutorById(int id)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"personas/tutor/id?id={id}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<Persona>();
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener tutor con Id {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener tutor con Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener tutor con Id {id}: {ex.Message}", ex);
            }
        }
        public static async Task<Persona> GetOneAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"personas/id?id={id}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<Persona>();
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener persona con Id {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener persona con Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener persona con Id {id}: {ex.Message}", ex);
            }
        }
        public static async Task<Persona>? GetTutorByDni(string dni) { 
            try
            {
                HttpResponseMessage response = await client.GetAsync($"personas/tutor/dni?dni={dni}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<Persona>();
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    return null;

                    //throw new Exception($"Error al obtener tutor con DNI {dni}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener tutor con DNI {dni}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener tutor con DNI {dni}: {ex.Message}", ex);
            }
        }
        public static async Task<PersonaDTO> GetByDni(string dni)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"personas/dni?dni={dni}");
                if(response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<PersonaDTO>();
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener persona con DNI {dni}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch(HttpRequestException ex) {
                throw new Exception($"Error de conexión al obtener persona con DNI {dni}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener persona con DNI {dni}: {ex.Message}", ex);
            }
        }
        public async static Task CreateAsync(PersonaDTO persona)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("personas", persona);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al crear la persona. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al crear persona: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al crear persona: {ex.Message}", ex);
            }


        
        }
        public static async Task DeleteAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync($"personas/id?id={id}");

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al eliminar persona con Id {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al eliminar persona con Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al eliminar persona con Id {id}: {ex.Message}", ex);
            }
        }
        public static async Task UpdateAsync(PersonaDTO persona,int id)
        {
            try
            {

                HttpResponseMessage response = await client.PutAsJsonAsync($"personas/{id}", persona);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al actualizar persona con Id {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al actualizar persona con Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al actualizar persona con Id {id}: {ex.Message}", ex);
            }
        }
    }
}
