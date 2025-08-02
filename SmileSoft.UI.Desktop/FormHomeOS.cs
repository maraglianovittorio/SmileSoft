using SmileSoft.Dominio;
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
            ConfigurarEstilos();
        }
        private void ConfigurarEstilos()
        {
            // Estilo principal - Tema azul elegante
            this.BackColor = Color.FromArgb(240, 248, 255); // AliceBlue
            this.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            this.Text = "SmileSoft - Pagina Obras sociales";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(800, 450); // Tamaño mínimo

            // Estilo para botones
            foreach (Control control in this.Controls)
            {
                if (control is Button btn)
                {
                    btnAgregarOS.BackColor = Color.FromArgb(70, 130, 180); // SteelBlue
                    btnBorrarOS.BackColor = Color.FromArgb(220, 20, 60); // Crimson
                    btnEditarOS.BackColor = Color.FromArgb(34, 139, 34); // ForestGreen
                    btn.ForeColor = Color.White;
                    btn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btnAgregarOS.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 149, 237); // CornflowerBlue
                    btnBorrarOS.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 99, 71); // Tomato
                    btnEditarOS.FlatAppearance.MouseOverBackColor = Color.FromArgb(144, 238, 144); // LightGreen
                    btn.Cursor = Cursors.Hand;
                }
            }
        }
        private async void FormHomeOS_Load(object sender, EventArgs e)
        {
            btnEditarOS.Enabled = false;
            btnBorrarOS.Enabled = false;
            ObraSocial os1 = new ObraSocial(1, "Obra Social 1");
            ObraSocial os2 = new ObraSocial(2, "Obra Social 2");
            await httpClient.PostAsJsonAsync("/obraSocial", os1);
            await httpClient.PostAsJsonAsync("/obraSocial", os2);

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
                    obrasSociales = OSResponse;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las Obras sociales: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
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

        private async void btnAgregarOS_Click(object sender, EventArgs e)
        {
            FormOS formOS = new FormOS();
            formOS.ShowDialog();
            await ObtenerDatos();

        }

        private async void btnEditarOS_Click(object sender, EventArgs e)
        {
            if (dgvFormOS.SelectedRows.Count > 0)
            {
                var obraSocialSeleccionada = dgvFormOS.SelectedRows[0].DataBoundItem as ObraSocial;
                if (obraSocialSeleccionada != null)
                {
                    FormOS formOS = new FormOS(obraSocialSeleccionada.Id);
                    formOS.ShowDialog();
                    await ObtenerDatos();
                }
            }
        }

        private async void btnBorrarOS_Click(object sender, EventArgs e)
        {
            if (dgvFormOS.SelectedRows.Count > 0)
            {
                var obraSocialSeleccionada = dgvFormOS.SelectedRows[0].DataBoundItem as ObraSocial;
                if (obraSocialSeleccionada != null)
                {
                    var confirmResult = MessageBox.Show("¿Estás seguro de que deseas eliminar esta obra social?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirmResult == DialogResult.Yes)
                    {
                        var response = await httpClient.DeleteAsync($"/obraSocial/{obraSocialSeleccionada.Id}");
                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Obra social eliminada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await ObtenerDatos();
                        }
                        else
                            MessageBox.Show($"Error al eliminar la obra social. Código: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
    }
}
