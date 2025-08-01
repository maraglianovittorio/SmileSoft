using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http.Json;
namespace SmileSoft.UI.Desktop
{
    public partial class FormOS : Form
    {
        public FormOS()
        {
            InitializeComponent();
        }
        private static readonly HttpClient httpClient = new HttpClient()
        {
            BaseAddress = new Uri("http://localhost:5279")

        };


        private void btnEnviarOS_Click(object sender, EventArgs e)
        {
            try
            {
                ObraSocialDTO obraSocial = new ObraSocialDTO
                {
                    Nombre = txtNombreOS.Text.Trim(),
                    
                };

                btnAgregarOS.Text = "Enviando...";
                btnAgregarOS.Enabled = false;

                var response = httpClient.PostAsJsonAsync("/obraSocial", obraSocial).Result;
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Obra social agregada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK; // Indicar que se agregó una obra social
                    this.Close(); // Cerrar el formulario después del éxito
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
                {
                    var errorContent = response.Content.ReadAsStringAsync().Result;
                    MessageBox.Show("Ya existe una obra social con ese nombre. Por favor use un nombre diferente.",
                        "Obra social duplicada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show($"Error al agregar la obra social. Código: {response.StatusCode}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnAgregarOS.Text = "Enviar";
                btnAgregarOS.Enabled = true;
            }
        }
    }
}
