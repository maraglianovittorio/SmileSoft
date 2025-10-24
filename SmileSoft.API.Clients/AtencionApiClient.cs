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
using Microsoft.AspNetCore.Http;

namespace SmileSoft.API.Clients
{
    public class AtencionApiClient : BaseApiClient
    {
        public static async Task<HistoriaClinicaDTO> GetHistoriaClinicaAsync(int pacienteId)
        {
            try
            {
                await EnsureAuthenticatedAsync();
                using var httpClient = await CreateHttpClientAsync();
                HttpResponseMessage response = await httpClient.GetAsync($"atenciones/historiaclinica?pacienteId={pacienteId}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<HistoriaClinicaDTO>();
                }
                else
                {
                    await HandleUnauthorizedResponseAsync(response);
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener la historia clínica para el paciente con Id {pacienteId}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener la historia clínica para el paciente con Id {pacienteId}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener la historia clínica para el paciente con Id {pacienteId}: {ex.Message}", ex);
            }
        }
        public static async Task<IEnumerable<AtencionDetalleDTO>> GetAllAsync()
        {
            try
            {
                await EnsureAuthenticatedAsync();
                using var httpClient = await CreateHttpClientAsync();
                HttpResponseMessage response = await httpClient.GetAsync("atenciones");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<IEnumerable<AtencionDetalleDTO>>();
                }
                else
                {
                    await HandleUnauthorizedResponseAsync(response);
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
        public static async Task<IEnumerable<AtencionSecretarioDTO>> GetAllForSecretarioAsync()
        {
            try
            {
                await EnsureAuthenticatedAsync();
                using var httpClient = await CreateHttpClientAsync();
                HttpResponseMessage response = await httpClient.GetAsync("atenciones/secretario");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<IEnumerable<AtencionSecretarioDTO>>();
                }
                else
                {   
                    await HandleUnauthorizedResponseAsync(response);
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener lista de atenciones para secretario. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener lista de atenciones para secretario: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener lista de atenciones para secretario: {ex.Message}", ex);
            }
        }
        public static async Task<AtencionSecretarioDTO?> GetOneForSecAsync(int id)
        {
            try
            {
                await EnsureAuthenticatedAsync();
                using var httpClient = await CreateHttpClientAsync();
                HttpResponseMessage response = await httpClient.GetAsync($"atenciones/secretario/id?id={id}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<AtencionSecretarioDTO>();
                }
                else
                {
                    await HandleUnauthorizedResponseAsync(response);
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener atencion con Id {id} para secretario. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener atencion con Id {id} para secretario: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener atencion con Id {id} para secretario: {ex.Message}", ex);
            }
        }
        public static async Task<AtencionDetalleDTO> GetOneAsync(int id)
        {
            try
            {
                await EnsureAuthenticatedAsync();
                using var httpClient = await CreateHttpClientAsync();
                HttpResponseMessage response = await httpClient.GetAsync($"atenciones/id?id={id}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<AtencionDetalleDTO>();

                }
                else
                { 
                    await HandleUnauthorizedResponseAsync(response);
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
        public static async Task<IEnumerable<Atencion>> GetByEstadoAsync(string estado)
        {
            try
            {
                await EnsureAuthenticatedAsync();
                using var httpClient = await CreateHttpClientAsync();
                HttpResponseMessage response = await httpClient.GetAsync($"atenciones/estado?estado={estado}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<IEnumerable<Atencion>>();
                }
                else
                {
                    await HandleUnauthorizedResponseAsync(response);
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
        public static async Task<IEnumerable<AtencionDetalleDTO>> GetByOdontologoIdAsync(int odontologoId)
        {
            try
            {
                await EnsureAuthenticatedAsync();
                using var httpClient = await CreateHttpClientAsync();
                HttpResponseMessage response = await httpClient.GetAsync($"atenciones/odontologo?id={odontologoId}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<IEnumerable<AtencionDetalleDTO>>();
                }
                else
                {
                    await HandleUnauthorizedResponseAsync(response);
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
        public static async Task<IEnumerable<Atencion>> GetByPacienteIdAsync(int pacienteId)
        {
            try
            {
                await EnsureAuthenticatedAsync();
                using var httpClient = await CreateHttpClientAsync();
                HttpResponseMessage response = await httpClient.GetAsync($"atenciones/paciente?id={pacienteId}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<IEnumerable<Atencion>>();
                }
                else
                {
                    await HandleUnauthorizedResponseAsync(response);
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
        public static async Task<IEnumerable<Atencion>> GetByTipoAtencionIdAsync(int tipoAtencionId)
        {
            try
            {
                await EnsureAuthenticatedAsync();
                using var httpClient = await CreateHttpClientAsync();
                HttpResponseMessage response = await httpClient.GetAsync($"atenciones/tipoatencion?id={tipoAtencionId}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<IEnumerable<Atencion>>();
                }
                else
                {
                    await HandleUnauthorizedResponseAsync(response);
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
        public static async Task<IEnumerable<AtencionDetalleDTO>> GetByFechaRangeAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                await EnsureAuthenticatedAsync();
                string url = $"atenciones/rango?startDate={fechaInicio}&endDate={fechaFin}";
                using var httpClient = await CreateHttpClientAsync();
                HttpResponseMessage response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<IEnumerable<AtencionDetalleDTO>>();
                }
                else
                {
                    await HandleUnauthorizedResponseAsync(response);
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
        public static async Task<IEnumerable<AtencionDetalleDTO>> GetByFechaRangeAndOdoAsync(DateTime fechaInicio, DateTime fechaFin, int id)
        {
            try
            {
                await EnsureAuthenticatedAsync();
                var fechaIni = fechaInicio.Date;
                // sumo un segundo para incluir todo el dia de fechaFin
                var fechaF = fechaIni.AddDays(1);
                string url = $"atenciones/rangoYOdo?startdate={fechaIni:yyyy-MM-dd}&enddate={fechaF:yyyy-MM-dd}&id={id}";
                using var httpClient = await CreateHttpClientAsync();
                HttpResponseMessage response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<IEnumerable<AtencionDetalleDTO>>();
                }
                else
                {   
                    await HandleUnauthorizedResponseAsync(response);
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
                await EnsureAuthenticatedAsync();
                using var httpClient = await CreateHttpClientAsync();
                HttpResponseMessage response = await httpClient.PostAsJsonAsync("atenciones", atencion);
                if (!response.IsSuccessStatusCode)
                {
                    await HandleUnauthorizedResponseAsync(response);
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
                await EnsureAuthenticatedAsync();
                using var httpClient = await CreateHttpClientAsync();
                HttpResponseMessage response = await httpClient.DeleteAsync($"atenciones/{id}");

                if (!response.IsSuccessStatusCode)
                {
                    await HandleUnauthorizedResponseAsync(response);
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
                await EnsureAuthenticatedAsync();
                using var httpClient = await CreateHttpClientAsync();
                HttpResponseMessage response = await httpClient.PutAsJsonAsync($"atenciones/{id}", atencion);

                if (!response.IsSuccessStatusCode)
                {
                    await HandleUnauthorizedResponseAsync(response);
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
        public static async Task CancelaAtencionAsync(int id)
        {
            try
            {
                await EnsureAuthenticatedAsync();
                using var httpClient = await CreateHttpClientAsync();
                HttpResponseMessage response = await httpClient.PutAsync($"atenciones/{id}/cancelar", null);
                if (!response.IsSuccessStatusCode)
                {
                    await HandleUnauthorizedResponseAsync(response);
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al cancelar atencion con Id {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al cancelar atencion con Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al cancelar atencion con Id {id}: {ex.Message}", ex);
            }
        }
        public static async Task ActualizaLlegada(int id)
        {
            try
            {
                await EnsureAuthenticatedAsync();
                using var httpClient = await CreateHttpClientAsync();
                HttpResponseMessage response = await httpClient.PutAsync($"atenciones/{id}/llegada", null);
                if (!response.IsSuccessStatusCode)
                {
                    await HandleUnauthorizedResponseAsync(response);
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al actualizar llegada de atencion con Id {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al actualizar llegada de atencion con Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al actualizar llegada de atencion con Id {id}: {ex.Message}", ex);
            }
        }

        public static async Task UpdateObservacionesAsync(int id, string observaciones)
        {
            try
            {
                await EnsureAuthenticatedAsync();
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
                using var httpClient = await CreateHttpClientAsync();
                HttpResponseMessage response = await httpClient.PutAsync($"atenciones/{id}/observaciones", content);

                if (!response.IsSuccessStatusCode)
                {
                    await HandleUnauthorizedResponseAsync(response);
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
