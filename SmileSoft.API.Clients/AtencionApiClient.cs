using DTO;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using SmileSoft.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace SmileSoft.API.Clients
{
    public class AtencionApiClient
    {
        private static HttpClient client = new HttpClient();
        static AtencionApiClient()
        {

            client.BaseAddress = new Uri("https://localhost:54145/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public static async Task<IEnumerable<AtencionDetalleDTO>> GetAllAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("atenciones");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<IEnumerable<AtencionDetalleDTO>>();
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener lista de atenciones. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener lista de atenciones: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener lista de atenciones: {ex.Message}", ex);
            }
        }
        public static async Task<AtencionDetalleDTO> GetOneAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"atenciones/id?id={id}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<AtencionDetalleDTO>();

                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener atencion con Id {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener atencion con Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener atencion con Id {id}: {ex.Message}", ex);
            }
        }
        public static async Task<ICollection<Atencion>> GetByEstadoAsync(string estado)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"atenciones/estado?estado={estado}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<ICollection<Atencion>>();
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener atenciones con estado '{estado}'. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener atenciones con estado '{estado}': {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener atenciones con estado '{estado}': {ex.Message}", ex);
            }
        }
        public static async Task<ICollection<AtencionDetalleDTO>> GetByOdontologoIdAsync(int odontologoId)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"atenciones/odontologo?id={odontologoId}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<ICollection<AtencionDetalleDTO>>();
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener atenciones para el odontólogo con Id {odontologoId}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener atenciones para el odontólogo con Id {odontologoId}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener atenciones para el odontólogo con Id {odontologoId}: {ex.Message}", ex);
            }
        }
        public static async Task<ICollection<Atencion>> GetByPacienteIdAsync(int pacienteId)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"atenciones/paciente?id={pacienteId}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<ICollection<Atencion>>();
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener atenciones para el paciente con Id {pacienteId}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener atenciones para el paciente con Id {pacienteId}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener atenciones para el paciente con Id {pacienteId}: {ex.Message}", ex);
            }
        }
        public static async Task<ICollection<Atencion>> GetByTipoAtencionIdAsync(int tipoAtencionId)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"atenciones/tipoatencion?id={tipoAtencionId}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<ICollection<Atencion>>();
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener atenciones para el tipo de atención con Id {tipoAtencionId}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener atenciones para el tipo de atención con Id {tipoAtencionId}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener atenciones para el tipo de atención con Id {tipoAtencionId}: {ex.Message}", ex);
            }
        }
        public static async Task<ICollection<Atencion>> GetByFechaRangeAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                string url = $"atenciones/fecharange?fechaInicio={fechaInicio.ToString("o")}&fechaFin={fechaFin.ToString("o")}";
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<ICollection<Atencion>>();
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener atenciones entre {fechaInicio} y {fechaFin}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener atenciones entre {fechaInicio} y {fechaFin}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener atenciones entre {fechaInicio} y {fechaFin}: {ex.Message}", ex);
            }
        }
        public static async Task<ICollection<AtencionDetalleDTO>> GetByFechaRangeAndOdoAsync(DateTime fechaInicio, DateTime fechaFin, int id)
        {
            try
            {
                var fechaIni = fechaInicio.Date;
                // sumo un segundo para incluir todo el dia de fechaFin
                var fechaF = fechaIni.AddDays(1);
                string url = $"atenciones1?startdate={fechaIni:yyyy-MM-dd}&enddate={fechaF:yyyy-MM-dd}&id={id}";
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<ICollection<AtencionDetalleDTO>>();
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener atenciones entre {fechaInicio} y {fechaFin} para el odontologo {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener atenciones entre {fechaInicio} y {fechaFin}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener atenciones entre {fechaInicio} y {fechaFin}: {ex.Message}", ex);
            }
        }
        public async static Task CreateAsync(AtencionDTO atencion)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("atenciones", atencion);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al crear la atencion. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al crear atencion: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al crear atencion: {ex.Message}", ex);
            }

        }
        public static async Task DeleteAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync($"atenciones/{id}");

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al eliminar atencion con Id {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al eliminar atencion con Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al eliminar atencion con Id {id}: {ex.Message}", ex);
            }
        }
        public static async Task UpdateAsync(AtencionDTO atencion, int id)
        {
            try
            {

                HttpResponseMessage response = await client.PutAsJsonAsync($"atenciones/{id}", atencion);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al actualizar atencion con Id {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al actualizar atencion con Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al actualizar atencion con Id {id}: {ex.Message}", ex);
            }
        }

        public static async Task UpdateObservacionesAsync(int id, string observaciones)
        {
            try
            {
                // Validate input parameters
                if (id <= 0)
                {
                    throw new ArgumentException("El ID debe ser un número positivo.", nameof(id));
                }

                if (observaciones == null)
                {
                    throw new ArgumentNullException(nameof(observaciones), "Las observaciones no pueden ser nulas.");
                }

                var content = new StringContent($"\"{observaciones}\"", Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync($"atenciones/{id}/observaciones", content);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al actualizar observaciones de atencion con Id {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al actualizar observaciones de atencion con Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al actualizar observaciones de atencion con Id {id}: {ex.Message}", ex);
            }
        }
    }
}
