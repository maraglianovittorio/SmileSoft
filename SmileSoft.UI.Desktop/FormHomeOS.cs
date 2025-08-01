using SmileSoft.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http.Json;

namespace SmileSoft.UI.Desktop
{
    public partial class FormHomeOS : Form
    {
        private static readonly HttpClient httpClient = new HttpClient()
        {
            BaseAddress = new Uri("http://localhost:5279")

        };
        private List<ObraSocial> obrasSociales = new();
        public FormHomeOS()
        {
            InitializeComponent();
        }

        private async void FormHomeOS_Load(object sender, EventArgs e)
        {
            ObraSocial os1 = new ObraSocial(1, "Obra Social 1");
            ObraSocial os2 = new ObraSocial(2, "Obra Social 2");
            await httpClient.PostAsJsonAsync("/obrasociales", os1);
            await httpClient.PostAsJsonAsync("/obrasociales", os2);
            btnEditarOS.Enabled = false;
            btnBorrarOS.Enabled = false;
            await ObtenerDatos();
        }

        private async Task ObtenerDatos()
        {
            try
            {
                var OSResponse = await httpClient.GetFromJsonAsync<List<ObraSocial>>("/obraSocial");
                if (OSResponse != null && OSResponse.Count > 0)
                {
                    dgvFormOS.DataSource = OSResponse;
                    dgvFormOS.Columns["Id"].Visible = false; // Ocultar columna Id
                    obrasSociales = OSResponse;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las Obras sociales: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private async void btnAgregarOS_Click(object sender, EventArgs e)
        {
            FormOS formOS = new FormOS();
            formOS.ShowDialog();
            await ObtenerDatos();
        }

        private void dgvFormOS_SelectionChanged_1(object sender, EventArgs e)
        {
            if (dgvFormOS.SelectedRows.Count > 0)
            {
                btnEditarOS.Enabled = true;
                btnBorrarOS.Enabled = true;
            }
            else
            {
                btnEditarOS.Enabled = false;
                btnBorrarOS.Enabled = false;

            }

        }

    }
}
