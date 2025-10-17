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
    public class OdontologoApiClient
    {
        private static HttpClient client = new HttpClient();
        static OdontologoApiClient()
        {

            client.BaseAddress = new Uri("https://localhost:54145/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public static async Task<IEnumerable<Odontologo>>? GetAllAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("odontologos");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<IEnumerable<Odontologo>>();
                }
                else
                {
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
        public static async Task<Odontologo> GetOneAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"odontologos/id?id={id}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<Odontologo>();
                }
                else
                {
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
        public async static Task CreateAsync(OdontologoDTO odontologo)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("odontologos", odontologo);

                if (!response.IsSuccessStatusCode)
                {
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
                HttpResponseMessage response = await client.DeleteAsync($"odontologos/{id}");

                if (!response.IsSuccessStatusCode)
                {
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

                HttpResponseMessage response = await client.PutAsJsonAsync($"odontologos/{id}", odontologo);

                if (!response.IsSuccessStatusCode)
                {
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
