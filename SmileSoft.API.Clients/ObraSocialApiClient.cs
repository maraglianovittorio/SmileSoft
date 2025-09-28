﻿using DTO;
using SmileSoft.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SmileSoft.API.Clients
{
    public class ObraSocialApiClient
    {
        private static HttpClient client = new HttpClient();
        static ObraSocialApiClient()
        {

            client.BaseAddress = new Uri("https://localhost:54145/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public static async Task<IEnumerable<ObraSocial>> GetAllAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("obrasocial");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<IEnumerable<ObraSocial>>();
                }
                else
                {
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
        public static async Task<ObraSocial> GetOneAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"obrasocial/id?id={id}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<ObraSocial>();


                }
                else
                {
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
        public async static Task CreateAsync(ObraSocialDTO obraSocial)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("obrasocial", obraSocial);

                if (!response.IsSuccessStatusCode)
                {
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
                HttpResponseMessage response = await client.DeleteAsync($"obrasocial/{id}");

                if (!response.IsSuccessStatusCode)
                {
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

                HttpResponseMessage response = await client.PutAsJsonAsync($"obrasocial/{id}", obraSocial);

                if (!response.IsSuccessStatusCode)
                {
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
