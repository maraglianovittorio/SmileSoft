using DTO;
using SmileSoft.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SmileSoft.API.Clients
{
    public class OdontologoApiClient : BaseApiClient
    {
        public static async Task<IEnumerable<OdontologoDTO>>? GetAllAsync()
        {
            try
            {
                await EnsureAuthenticatedAsync();
                using var httpClient = await CreateHttpClientAsync();
                HttpResponseMessage response = await httpClient.GetAsync("odontologos");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<IEnumerable<OdontologoDTO>>();
                }
                else
                {
                    await HandleUnauthorizedResponseAsync(response);
                    string errorContent = await response.Content.ReadAsStringAsync();
                    //throw new Exception($"Error al obtener lista de odontologos. Status: {response.StatusCode}, Detalle: {errorContent}");
                    return null;
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener lista de odontologos: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener lista de odontologos: {ex.Message}", ex);
            }
        }
        public static async Task<OdontologoDTO> GetOneAsync(int id)
        {
            try
            {
                await EnsureAuthenticatedAsync();
                using var httpClient = await CreateHttpClientAsync();
                HttpResponseMessage response = await httpClient.GetAsync($"odontologos/id?id={id}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<OdontologoDTO>();
                }
                else
                {
                    await HandleUnauthorizedResponseAsync(response);
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener odontologo con Id {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener odontologo con Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener odontologo con Id {id}: {ex.Message}", ex);
            }
        }
        public async static Task CreateAsync(OdontologoCreacionDTO odontologo)
        {
            try
            {
                await EnsureAuthenticatedAsync();
                using var httpClient = await CreateHttpClientAsync();
                HttpResponseMessage response = await httpClient.PostAsJsonAsync("odontologos", odontologo);

                if (!response.IsSuccessStatusCode)
                {
                    await HandleUnauthorizedResponseAsync(response);
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al crear el odontologo. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al crear odontologo: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al crear odontologo: {ex.Message}", ex);
            }
        }
        public static async Task DeleteAsync(int id)
        {
            try
            {
                await EnsureAuthenticatedAsync();
                using var httpClient = await CreateHttpClientAsync();
                HttpResponseMessage response = await httpClient.DeleteAsync($"odontologos/{id}");

                if (!response.IsSuccessStatusCode)
                {
                    await HandleUnauthorizedResponseAsync(response);
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al eliminar odontologo con Id {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al eliminar odontologo con Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al eliminar odontologo con Id {id}: {ex.Message}", ex);
            }
        }
        public static async Task UpdateAsync(OdontologoDTO odontologo, int id)
        {
            try
            {
                await EnsureAuthenticatedAsync();
                using var httpClient = await CreateHttpClientAsync();
                HttpResponseMessage response = await httpClient.PutAsJsonAsync($"odontologos/{id}", odontologo);

                if (!response.IsSuccessStatusCode)
                {
                    await HandleUnauthorizedResponseAsync(response);
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al actualizar odontologo con Id {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al actualizar odontologo con Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al actualizar odontologo con Id {id}: {ex.Message}", ex);
            }
        }
    }
}
