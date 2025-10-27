using SmileSoft.DTO;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SmileSoft.API.Clients
{
    public class ReporteApiClient : BaseApiClient
    {
        public static async Task<byte[]> GenerarReportePacientesAsync(ReportePacientesRequestDTO request)
        {
            try
            {
                await EnsureAuthenticatedAsync();
                using var httpClient = await CreateHttpClientAsync();
                
                HttpResponseMessage response = await httpClient.PostAsJsonAsync("reportes/pacientes", request);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsByteArrayAsync();
                }
                else
                {
                    await HandleUnauthorizedResponseAsync(response);
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al generar reporte de pacientes. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al generar reporte de pacientes: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al generar reporte de pacientes: {ex.Message}", ex);
            }
        }

        public static async Task<byte[]> GenerarReporteAtencionesAsync(ReporteAtencionesRequestDTO request)
        {
            try
            {
                await EnsureAuthenticatedAsync();
                using var httpClient = await CreateHttpClientAsync();
                
                HttpResponseMessage response = await httpClient.PostAsJsonAsync("reportes/atenciones", request);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsByteArrayAsync();
                }
                else
                {
                    await HandleUnauthorizedResponseAsync(response);
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al generar reporte de atenciones. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al generar reporte de atenciones: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al generar reporte de atenciones: {ex.Message}", ex);
            }
        }

        public static async Task<byte[]> GenerarReporteHistogramaAtencionesAsync(ReporteHistogramaAtencionesRequestDTO request)
        {
            try
            {
                await EnsureAuthenticatedAsync();
                using var httpClient = await CreateHttpClientAsync();
                
                HttpResponseMessage response = await httpClient.PostAsJsonAsync("reportes/histograma-atenciones", request);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsByteArrayAsync();
                }
                else
                {
                    await HandleUnauthorizedResponseAsync(response);
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al generar reporte de histograma. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al generar reporte de histograma: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al generar reporte de histograma: {ex.Message}", ex);
            }
        }

        public static async Task<byte[]> GenerarReporteAtencionesHorarioAsync(ReporteAtencionesHorarioRequestDTO request)
        {
            try
            {
                await EnsureAuthenticatedAsync();
                using var httpClient = await CreateHttpClientAsync();
                
                HttpResponseMessage response = await httpClient.PostAsJsonAsync("reportes/atenciones-horario", request);
                
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsByteArrayAsync();
                }
                else
                {
                    await HandleUnauthorizedResponseAsync(response);
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al generar el reporte de atenciones por horario. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al generar el reporte de atenciones por horario: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al generar el reporte de atenciones por horario: {ex.Message}", ex);
            }
        }

        public static async Task<byte[]> GenerarReporteAtencionesOdontologoAsync(ReporteAtencionesOdontologoRequestDTO request)
        {
            try
            {
                await EnsureAuthenticatedAsync();
                using var httpClient = await CreateHttpClientAsync();
                
                HttpResponseMessage response = await httpClient.PostAsJsonAsync("reportes/atenciones-odontologo", request);
                
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsByteArrayAsync();
                }
                else
                {
                    await HandleUnauthorizedResponseAsync(response);
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al generar el reporte de atenciones por odontólogo. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al generar el reporte de atenciones por odontólogo: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al generar el reporte de atenciones por odontólogo: {ex.Message}", ex);
            }
        }
        public static async Task<byte[]> GenerarReporteAtencionesPorOdontologoAsync(ReporteAtencionesPorOdontologoRequestDTO request)
        {
            try
            {
                await EnsureAuthenticatedAsync();
                using var httpClient = await CreateHttpClientAsync();

                HttpResponseMessage response = await httpClient.PostAsJsonAsync("reportes/atenciones-porodontologo", request);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsByteArrayAsync();
                }
                else
                {
                    await HandleUnauthorizedResponseAsync(response);
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al generar el reporte de atenciones por odontólogo. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al generar el reporte de atenciones por odontólogo: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al generar el reporte de atenciones por odontólogo: {ex.Message}", ex);
            }
        }
    }
}