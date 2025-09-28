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
    public class UsuarioApiClient
    {
        private static HttpClient client = new HttpClient();
        static UsuarioApiClient()
        {

            client.BaseAddress = new Uri("https://localhost:54145/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public static async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("usuarios");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<IEnumerable<Usuario>>();
                }
                else
                {
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
                HttpResponseMessage response = await client.GetAsync($"usuarios/id?id={id}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<Usuario>();
                }
                else
                {
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
        public async static Task CreateAsync(UsuarioCreateDTO usuario)
        {
            try
            {
                Usuario usuarioPost = new Usuario(usuario.Username, usuario.Password, usuario.Rol);
                HttpResponseMessage response = await client.PostAsJsonAsync("usuarios", usuarioPost);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al crear el usuario. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex) { 
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
                HttpResponseMessage response = await client.DeleteAsync($"usuarios/{id}");

                if (!response.IsSuccessStatusCode)
                {
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

                HttpResponseMessage response = await client.PutAsJsonAsync($"usuarios/{id}", usuario);

                if (!response.IsSuccessStatusCode)
                {
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
        //El login ya se trata con el auth
        //public static async void Login(string username, string password)
        //{
        //    try
        //    {
        //        HttpResponseMessage response = await client.GetAsync($"usuarios/login?username={username}&password={password}");
        //        if (response.IsSuccessStatusCode)
        //        {
        //            var usuario = await response.Content.ReadAsAsync<Usuario>();
        //            // Aquí puedes manejar el usuario autenticado según tus necesidades
        //        }
        //        else
        //        {
        //            string errorContent = await response.Content.ReadAsStringAsync();
        //            throw new Exception($"Error al autenticar usuario. Status: {response.StatusCode}, Detalle: {errorContent}");
        //        }
        //    }
        //    catch (HttpRequestException ex)
        //    {
        //        throw new Exception($"Error de conexión al autenticar usuario: {ex.Message}", ex);
        //    }
        //    catch (TaskCanceledException ex)
        //    {
        //        throw new Exception($"Timeout al autenticar usuario: {ex.Message}", ex);
        //    }
        //}
        public static async Task<Usuario> GetByUsernameAsync(string username)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"usuarios/{username}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<Usuario>();
                }
                else
                {
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
    }
}

