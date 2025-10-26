using DTO;
using SmileSoft.API.Clients;
using SmileSoft.Dominio;
using System.Data;
using SmileSoft.WindowsForms;



namespace SmileSoft.UI.Desktop
{
    public partial class FormHomeOS : FormBaseHome
    {
        private static readonly HttpClient httpClient = new HttpClient()
        {
            BaseAddress = new Uri("http://localhost:54145")

        };
        private List<ObraSocial> obrasSociales = new();
        public FormHomeOS(string rol)
        {

            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            ConfigurarEstilos();
            //ConfigurarResponsive();
            ConfigurarLayoutResponsivo(dgvFormOS, txtBuscarOS, lupaPng, btnAgregarOS, btnEditarOS, btnBorrarOS, BtnVolver);

            if (rol.ToUpper() != "ADMIN")
            {
                btnBorrarOS.Visible = false;
                btnEditarOS.Visible = false;
            }
        }

        private void ConfigurarEstilos()
        {
            // Estilo principal
            this.BackColor = Color.FromArgb(240, 248, 255); // AliceBlue
            this.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            this.Text = "SmileSoft - Home Obras sociales";
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
                var OSResponse = await ObraSocialApiClient.GetAllAsync();
                if (OSResponse != null && OSResponse.Count() > 0 )
                {
                    dgvFormOS.DataSource = OSResponse;
                    obrasSociales = (List<ObraSocial>)OSResponse;
                    ConfiguraDgv();
                }
                else
                {
                    dgvFormOS.DataSource = null;
                    obrasSociales.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las obras sociales: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void ConfiguraDgv()
        {
            dgvFormOS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvFormOS.Columns["Id"].Visible = false;
            dgvFormOS.Columns["TipoPlanes"].Visible = false;

        }
        private async void FormHomeOS_Load(object sender, EventArgs e)
        {
            btnBorrarOS.Enabled = false;
            btnEditarOS.Enabled = false;
            await ObtenerDatos();
        }

        private void txtBuscarOS_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscarOS.Text.ToLower();
            if (!string.IsNullOrWhiteSpace(filtro))
            {
                var filtrados = obrasSociales.Where(os => os.Nombre.ToLower().Contains(filtro)).ToList();
                dgvFormOS.DataSource = filtrados;
            }
            else
            {
                dgvFormOS.DataSource = obrasSociales;

            }
            ConfiguraDgv();

        }

        private async void btnAgregarOS_Click(object sender, EventArgs e)
        {
            FormOS formOS = new FormOS();
            formOS.ShowDialog();
            await ObtenerDatos();
        }



        private void dgvFormHomeOS_SelectionChanged(object sender, EventArgs e)
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

        private async void BtnEditarOS_Click(object sender, EventArgs e)
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

        private async void BtnBorrarOS_Click(object sender, EventArgs e)
        {
            if (dgvFormOS.SelectedRows.Count > 0)
            {
                var obraSocialSeleccionada = dgvFormOS.SelectedRows[0].DataBoundItem as ObraSocial;
                if (obraSocialSeleccionada != null)
                {
                    var confirmResult = MessageBox.Show("¿Estás seguro de que deseas eliminar esta obra social?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirmResult == DialogResult.Yes)
                    {
                        await ObraSocialApiClient.DeleteAsync(obraSocialSeleccionada.Id);
                        MessageBox.Show("Obra social eliminada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await ObtenerDatos();
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
