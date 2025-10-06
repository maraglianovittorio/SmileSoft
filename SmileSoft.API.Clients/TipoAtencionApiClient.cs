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
    public class TipoAtencionApiClient
    {
        private static HttpClient client = new HttpClient();
        static TipoAtencionApiClient()
        {

            client.BaseAddress = new Uri("https://localhost:54145/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public static async Task<IEnumerable<TipoAtencion>> GetAllAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("tipoatencion");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<IEnumerable<TipoAtencion>>();
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener lista de tipos de atención. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener lista de tipos de atención: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener lista de tipos de atención: {ex.Message}", ex);
            }
        }
        public static async Task<TipoAtencionDTO> GetOneAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"tipoatencion/id?id={id}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<TipoAtencionDTO>();
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener tipo de atención con Id {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener tipo de atención con Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener tipo de atención con Id {id}: {ex.Message}", ex);
            }
        }
        public async static Task CreateAsync(TipoAtencionDTO tipoAtencion)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("tipoatencion", tipoAtencion);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al crear el tipo de atención. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al crear tipo de atención: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al crear tipo de atención: {ex.Message}", ex);
            }



        }
        public static async Task DeleteAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync($"tipoatencion/{id}");

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al eliminar tipo de atención con Id {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al eliminar tipo de atención con Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al eliminar tipo de atención con Id {id}: {ex.Message}", ex);
            }
        }
        public static async Task UpdateAsync(TipoAtencionDTO tipoAtencion, int id)
        {
            try
            {

                HttpResponseMessage response = await client.PutAsJsonAsync($"tipoatencion/{id}", tipoAtencion);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al actualizar tipo de atención con Id {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al actualizar tipo de atención con Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al actualizar tipo de atención con Id {id}: {ex.Message}", ex);
            }
        }
    }
}

