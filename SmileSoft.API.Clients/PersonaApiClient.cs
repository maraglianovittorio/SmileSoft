using SmileSoft.DTO;
using SmileSoft.Dominio;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

namespace SmileSoft.API.Clients
{
    public class PersonaApiClient : BaseApiClient
    {
        public static async Task<IEnumerable<Persona>> GetAllAsync()
        {
            try
            {
                await EnsureAuthenticatedAsync();
                using var httpClient = await CreateHttpClientAsync();
                HttpResponseMessage response = await httpClient.GetAsync("personas");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<IEnumerable<Persona>>();
                }
                else
                {
                    await HandleUnauthorizedResponseAsync(response);
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
        public static async Task<IEnumerable<PersonaDTO>> GetAllTutorsAsync()
        {
            try
            {
                await EnsureAuthenticatedAsync();
                using var httpClient = await CreateHttpClientAsync();
                HttpResponseMessage response = await httpClient.GetAsync("personas/tutores");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<IEnumerable<PersonaDTO>>();
                }
                else
                {
                    await HandleUnauthorizedResponseAsync(response);
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
        public static async Task<PersonaDTO> GetTutorById(int id)
        {
            try
            {
                await EnsureAuthenticatedAsync();
                using var httpClient = await CreateHttpClientAsync();
                HttpResponseMessage response = await httpClient.GetAsync($"personas/tutor/id?id={id}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<PersonaDTO>();
                }
                else
                {
                    await HandleUnauthorizedResponseAsync(response);
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
        public static async Task<PersonaDTO> GetOneAsync(int id)
        {
            try
            {
                await EnsureAuthenticatedAsync();
                using var httpClient = await CreateHttpClientAsync();
                HttpResponseMessage response = await httpClient.GetAsync($"personas/id?id={id}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<PersonaDTO>();
                }
                else
                {
                    await HandleUnauthorizedResponseAsync(response);
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
        public static async Task<PersonaDTO>? GetTutorByDni(string dni) { 
            try
            {
                await EnsureAuthenticatedAsync();
                using var httpClient = await CreateHttpClientAsync();
                HttpResponseMessage response = await httpClient.GetAsync($"personas/tutor/dni?dni={dni}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<PersonaDTO>();
                }
                else
                {
                    await HandleUnauthorizedResponseAsync(response);
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
                await EnsureAuthenticatedAsync();
                using var httpClient = await CreateHttpClientAsync();
                HttpResponseMessage response = await httpClient.GetAsync($"personas/dni?dni={dni}");
                if(response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<PersonaDTO>();
                }
                else
                {
                    await HandleUnauthorizedResponseAsync(response);
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
                await EnsureAuthenticatedAsync();
                using var httpClient = await CreateHttpClientAsync();
                HttpResponseMessage response = await httpClient.PostAsJsonAsync("personas", persona);

                if (!response.IsSuccessStatusCode)
                {
                    await HandleUnauthorizedResponseAsync(response);
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
                await EnsureAuthenticatedAsync();
                using var httpClient = await CreateHttpClientAsync();
                HttpResponseMessage response = await httpClient.DeleteAsync($"personas/id?id={id}");

                if (!response.IsSuccessStatusCode)
                {
                    await HandleUnauthorizedResponseAsync(response);
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
                await EnsureAuthenticatedAsync();   
                using var httpClient = await CreateHttpClientAsync();
                HttpResponseMessage response = await httpClient.PutAsJsonAsync($"personas/id?id={id}", persona);

                if (!response.IsSuccessStatusCode)
                {
                    await HandleUnauthorizedResponseAsync(response);
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
