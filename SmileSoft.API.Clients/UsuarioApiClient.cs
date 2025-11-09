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
    public class UsuarioApiClient : BaseApiClient
    {
        public static async Task<IEnumerable<UsuarioDTO>> GetAllAsync()
        {
            try
            {
                await EnsureAuthenticatedAsync();
                using var httpClient = await CreateHttpClientAsync();
                HttpResponseMessage response = await httpClient.GetAsync("usuarios");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<IEnumerable<UsuarioDTO>>();
                }
                else
                {
                    await HandleUnauthorizedResponseAsync(response);
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener lista de usuarios. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener lista de usuarios: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener lista de usuarios: {ex.Message}", ex);
            }
        }
        public static async Task<Usuario> GetOneAsync(int id)
        {
            try
            {
                await EnsureAuthenticatedAsync();
                using var httpClient = await CreateHttpClientAsync();
                HttpResponseMessage response = await httpClient.GetAsync($"usuarios/id?id={id}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<Usuario>();
                }
                else
                {
                    await HandleUnauthorizedResponseAsync(response);
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener usuario con Id {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener usuario con Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener usuario con Id {id}: {ex.Message}", ex);
            }
        }
        public async static Task<UsuarioUpdateDTO> GetOneForUpdate(int id)
        {
            try
            {
                await EnsureAuthenticatedAsync();
                using var httpClient = await CreateHttpClientAsync();
                HttpResponseMessage response = await httpClient.GetAsync($"usuarios/update?id={id}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<UsuarioUpdateDTO>();
                }
                else
                {
                    await HandleUnauthorizedResponseAsync(response);
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener usuario para actualizar con Id {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener usuario para actualizar con Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener usuario para actualizar con Id {id}: {ex.Message}", ex);
            }
        }
        public async static Task CreateAsync(UsuarioCreateDTO usuario)
        {
            try
            {
                await EnsureAuthenticatedAsync();
                Usuario usuarioPost = new Usuario(usuario.Username, usuario.Password, usuario.Rol);
                using var httpClient = await CreateHttpClientAsync();
                HttpResponseMessage response = await httpClient.PostAsJsonAsync("usuarios", usuario);

                if (!response.IsSuccessStatusCode)
                {
                    await HandleUnauthorizedResponseAsync(response);
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al crear el usuario. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al crear usuario: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al crear usuario: {ex.Message}", ex);
            }
        }
        public static async Task DeleteAsync(int id)
        {
            try
            {
                await EnsureAuthenticatedAsync();
                using var httpClient = await CreateHttpClientAsync();
                HttpResponseMessage response = await httpClient.DeleteAsync($"usuarios/{id}");

                if (!response.IsSuccessStatusCode)
                {
                    await HandleUnauthorizedResponseAsync(response);
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al eliminar usuario con Id {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al eliminar usuario con Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al eliminar usuario con Id {id}: {ex.Message}", ex);
            }
        }
        public static async Task UpdateAsync(UsuarioUpdateDTO usuario, int id)
        {
            try
            {
                await EnsureAuthenticatedAsync();
                using var httpClient = await CreateHttpClientAsync();
                HttpResponseMessage response = await httpClient.PutAsJsonAsync($"usuarios/{id}", usuario);

                if (!response.IsSuccessStatusCode)
                {
                    await HandleUnauthorizedResponseAsync(response);
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al actualizar usuario con Id {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al actualizar usuario con Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al actualizar usuario con Id {id}: {ex.Message}", ex);
            }
        }
        public static async Task<UsuarioDTO> GetByUsernameAsync(string username)
         {
            try
            {
                await EnsureAuthenticatedAsync();
                using var httpClient = await CreateHttpClientAsync();
                HttpResponseMessage response = await httpClient.GetAsync($"usuarios/{username}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<UsuarioDTO>();
                }
                else
                {
                    await HandleUnauthorizedResponseAsync(response);
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener usuario con username {username}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener usuario con username {username}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener usuario con username {username}: {ex.Message}", ex);
            }
        }

        public static async Task<UpdatePasswordDTO> UpdatePasswordAsync(int id,UpdatePasswordDTO dto)
        {
            try
            {
                await EnsureAuthenticatedAsync();
                using var httpClient = await CreateHttpClientAsync();
                HttpResponseMessage response = await httpClient.PutAsJsonAsync($"usuarios/password/{id}", dto);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<UpdatePasswordDTO>();
                }
                else
                {
                    await HandleUnauthorizedResponseAsync(response);
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al actualizar la contraseña del usuario con Id {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al actualizar la contraseña del usuario con Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al actualizar la contraseña del usuario con Id {id}: {ex.Message}", ex);
            }

        }

    }
}