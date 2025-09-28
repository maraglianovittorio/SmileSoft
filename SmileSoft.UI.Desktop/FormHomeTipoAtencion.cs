using DTO;
using SmileSoft.API.Clients;
using SmileSoft.Dominio;
using System.Data;
using System.Windows.Forms;

namespace SmileSoft.UI.Desktop
{
    public partial class FormHomeTipoAtencion : Form
    {
        private static readonly HttpClient httpClient = new HttpClient()
        {
            BaseAddress = new Uri("http://localhost:54145")
        };
        private List<TipoAtencionDTO> tiposAtencion = new();

        public FormHomeTipoAtencion()
        {
            InitializeComponent();
            ConfigurarEstilos();
            ConfigurarResponsive();
        }

        private void ConfigurarEstilos()
        {
            // Estilo principal
            this.BackColor = Color.FromArgb(240, 248, 255); // AliceBlue
            this.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            this.Text = "SmileSoft - Home Tipos de atenciones";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(800, 450); // Tamaño mínimo

            // Estilo para botones
            foreach (Control control in this.Controls)
            {
                if (control is Button btn)
                {
                    btnAgregarTipoAtencion.BackColor = Color.FromArgb(70, 130, 180); // SteelBlue
                    btnBorrarTipoAtencion.BackColor = Color.FromArgb(220, 20, 60); // Crimson
                    btnEditarTipoAtencion.BackColor = Color.FromArgb(34, 139, 34); // ForestGreen
                    btn.ForeColor = Color.White;
                    btn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btnAgregarTipoAtencion.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 149, 237); // CornflowerBlue
                    btnBorrarTipoAtencion.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 99, 71); // Tomato
                    btnEditarTipoAtencion.FlatAppearance.MouseOverBackColor = Color.FromArgb(144, 238, 144); // LightGreen
                    btn.Cursor = Cursors.Hand;
                }
            }
        }

        private void ConfigurarResponsive()
        {
            // Hacer que el formulario sea redimensionable
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;

            // Configurar anclajes para que los botones se mantengan centrados
            // Manejar el evento de redimensionado para centrar los botones
            this.Resize += FormHomePage_Resize;
        }

        private void FormHomePage_Resize(object sender, EventArgs e)
        {
            // Centrar los botones horizontalmente y verticalmente
            int buttonWidth = 112;
            int buttonHeight = 47;
            int spacing = 60; // Espacio entre botones
            int totalWidth = (buttonWidth * 4) + (spacing * 3);

            int startX = (this.ClientSize.Width - totalWidth) / 2;
            int centerY = this.ClientSize.Height / 2;
        }

        private async Task ObtenerDatos()
        {
            try
            {
                var tiposAtencionResponse = await TipoAtencionApiClient.GetAllAsync();
                if (tiposAtencionResponse != null && tiposAtencionResponse.Count() > 0)
                {
                    tiposAtencion = tiposAtencionResponse.ToList();
                    dgvFormTipoAtencion.DataSource = tiposAtencion;

                }

                else
                {
                    dgvFormTipoAtencion.DataSource = tiposAtencionResponse;
                    MessageBox.Show("No hay tipos de atención registrados.", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los tipos de atención: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void FormHomeTipoAtencion_Load(object sender, EventArgs e)
        {
            btnBorrarTipoAtencion.Enabled = false;
            btnEditarTipoAtencion.Enabled = false;
            await ObtenerDatos();
        }

        private void txtBuscarTipoAtencion_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscarTipoAtencion.Text.ToLower();
            if (!string.IsNullOrWhiteSpace(filtro))
            {
                var filtrados = tiposAtencion.Where(tp =>
                    tp.Descripcion.ToLower().Contains(filtro)
                ).ToList();
                dgvFormTipoAtencion.DataSource = filtrados;
            }
            else
            {
                dgvFormTipoAtencion.DataSource = tiposAtencion;
            }

            if (dgvFormTipoAtencion.Columns["Id"] != null)
                dgvFormTipoAtencion.Columns["Id"].Visible = false;
        }

        private async void btnAgregarTipoAtencion_Click(object sender, EventArgs e)
        {
            FormTipoAtencion formTipoAtencion = new FormTipoAtencion();
            formTipoAtencion.ShowDialog();
            await ObtenerDatos();
        }

        private void dgvFormHomeTipoAtencion_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvFormTipoAtencion.SelectedRows.Count > 0)
            {
                btnEditarTipoAtencion.Enabled = true;
                btnBorrarTipoAtencion.Enabled = true;
            }
            else
            {
                btnEditarTipoAtencion.Enabled = false;
                btnBorrarTipoAtencion.Enabled = false;
            }
        }

        private async void BtnEditarTipoAtencion_Click(object sender, EventArgs e)
        {
            if (dgvFormTipoAtencion.SelectedRows.Count > 0)
            {
                var idTipoAtencion = (int)dgvFormTipoAtencion.SelectedRows[0].Cells["Id"].Value;
                var tipoAtencionSeleccionado = tiposAtencion.FirstOrDefault(tp => tp.Id == idTipoAtencion);

                if (tipoAtencionSeleccionado != null)
                {
                    FormTipoAtencion formTipoAtencion = new FormTipoAtencion(tipoAtencionSeleccionado.Id);
                    formTipoAtencion.ShowDialog();
                    await ObtenerDatos();
                }
            }
        }

        private async void BtnBorrarTipoAtencion_Click(object sender, EventArgs e)
        {
            if (dgvFormTipoAtencion.SelectedRows.Count > 0)
            {
                var idTipoAtencion = (int)dgvFormTipoAtencion.SelectedRows[0].Cells["Id"].Value;
                var tipoAtencionSeleccionado = tiposAtencion.FirstOrDefault(tp => tp.Id == idTipoAtencion);

                if (tipoAtencionSeleccionado != null)
                {
                    var confirmResult = MessageBox.Show(
                        $"¿Estás seguro de que deseas eliminar el tipo de atención '{tipoAtencionSeleccionado.Descripcion}'?",
                        "Confirmar eliminación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (confirmResult == DialogResult.Yes)
                    {
                        try
                        {
                            await TipoAtencionApiClient.DeleteAsync(tipoAtencionSeleccionado.Id);
                            MessageBox.Show("Tipo de atención eliminado correctamente", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await ObtenerDatos();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al eliminar el tipo de atención: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }

        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
