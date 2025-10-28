using SmileSoft.DTO;
using SmileSoft.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SmileSoft.API.Clients
{
    public class ObraSocialApiClient : BaseApiClient
    {
        public static async Task<IEnumerable<ObraSocialDTO>> GetAllAsync()
        {
            try
            {
                await EnsureAuthenticatedAsync();
                using var httpClient = await CreateHttpClientAsync();
                HttpResponseMessage response = await httpClient.GetAsync("obrasocial");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<IEnumerable<ObraSocialDTO>>();
                }
                else
                {
                    await HandleUnauthorizedResponseAsync(response);
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener lista de obras sociales. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener lista de obras sociales: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener lista de obras sociales: {ex.Message}", ex);
            }
        }

        public static async Task<ObraSocialDTO> GetOneAsync(int id)
        {
            try
            {
                await EnsureAuthenticatedAsync();
                using var httpClient = await CreateHttpClientAsync();
                HttpResponseMessage response = await httpClient.GetAsync($"obrasocial/id?id={id}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<ObraSocialDTO>();
                }
                else
                {
                    await HandleUnauthorizedResponseAsync(response);
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener obra social con Id {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener obra social con Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener obra social con Id {id}: {ex.Message}", ex);
            }
        }

        public static async Task<ObraSocialDTO> GetByNameAsync(string nombre)
        {
            try
            {
                await EnsureAuthenticatedAsync();
                using var httpClient = await CreateHttpClientAsync();
                HttpResponseMessage response = await httpClient.GetAsync($"obrasocial/nombre?nombre={nombre}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<ObraSocialDTO>();
                }
                else
                {
                    await HandleUnauthorizedResponseAsync(response);
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener obra social con nombre '{nombre}'. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener obra social con nombre '{nombre}': {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener obra social con nombre '{nombre}': {ex.Message}", ex);
            }
        }

        public async static Task CreateAsync(ObraSocialDTO obraSocial)
        {
            try
            {
                await EnsureAuthenticatedAsync();
                using var httpClient = await CreateHttpClientAsync();
                HttpResponseMessage response = await httpClient.PostAsJsonAsync("obrasocial", obraSocial);

                if (!response.IsSuccessStatusCode)
                {
                    await HandleUnauthorizedResponseAsync(response);
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al crear la obra social. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al crear obra social: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al crear obra social: {ex.Message}", ex);
            }
        }

        public static async Task DeleteAsync(int id)
        {
            try
            {
                await EnsureAuthenticatedAsync();
                using var httpClient = await CreateHttpClientAsync();
                HttpResponseMessage response = await httpClient.DeleteAsync($"obrasocial/{id}");

                if (!response.IsSuccessStatusCode)
                {
                    await HandleUnauthorizedResponseAsync(response);
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al eliminar obra social con Id {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al eliminar obra social con Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al eliminar obra social con Id {id}: {ex.Message}", ex);
            }
        }

        public static async Task UpdateAsync(ObraSocialDTO obraSocial, int id)
        {
            try
            {
                await EnsureAuthenticatedAsync();
                using var httpClient = await CreateHttpClientAsync();
                HttpResponseMessage response = await httpClient.PutAsJsonAsync($"obrasocial/{id}", obraSocial);

                if (!response.IsSuccessStatusCode)
                {
                    await HandleUnauthorizedResponseAsync(response);
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al actualizar obra social con Id {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al actualizar obra social con Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al actualizar obra social con Id {id}: {ex.Message}", ex);
            }
        }
    }
}
