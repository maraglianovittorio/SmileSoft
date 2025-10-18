using DTO;
using SmileSoft.API.Clients;
using SmileSoft.Dominio;
using SmileSoft.WindowsForms;
using System.Data;



namespace SmileSoft.UI.Desktop
{
    public partial class FormHomeAtencion : Form
    {
        private static readonly HttpClient httpClient = new HttpClient()
        {
            BaseAddress = new Uri("http://localhost:54145")

        };
        private List<Atencion> atenciones = new();
        public FormHomeAtencion()
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
            this.Text = "SmileSoft - Home de atenciones";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(800, 450); // Tamaño mínimo

            // Estilo para botones
            foreach (Control control in this.Controls)
            {
                if (control is Button btn)
                {
                    btnAgregarAtencion.BackColor = Color.FromArgb(70, 130, 180); // SteelBlue
                    btnBorrarAtencion.BackColor = Color.FromArgb(220, 20, 60); // Crimson
                    btnEditarAtencion.BackColor = Color.FromArgb(34, 139, 34); // ForestGreen
                    btn.ForeColor = Color.White;
                    btn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btnAgregarAtencion.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 149, 237); // CornflowerBlue
                    btnBorrarAtencion.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 99, 71); // Tomato
                    btnEditarAtencion.FlatAppearance.MouseOverBackColor = Color.FromArgb(144, 238, 144); // LightGreen
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
            this.Resize += FormHomeAtenciones_Resize;
        }

        private void FormHomeAtenciones_Resize(object sender, EventArgs e)
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
                var atencionesResponse = await AtencionApiClient.GetAllAsync();
                if (atencionesResponse != null && atencionesResponse.Count() > 0)
                {
                    dgvFormAtencion.DataSource = atencionesResponse;
                    atenciones = (List<Atencion>)atencionesResponse;
                    dgvFormAtencion.Columns["Id"].Visible = false;
                    dgvFormAtencion.Columns["TipoAtencion"].Visible = false;
                    dgvFormAtencion.Columns["Odontologo"].Visible = false;
                    dgvFormAtencion.Columns["Paciente"].Visible = false;

                }
                else
                {
                    dgvFormAtencion.DataSource = null;
                    atenciones.Clear();
                    MessageBox.Show("No se encontraron atenciones.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las atenciones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private async void FormHomeAtenciones_Load(object sender, EventArgs e)
        {
            btnBorrarAtencion.Enabled = false;
            btnEditarAtencion.Enabled = false;


            await ObtenerDatos();
        }

        private void txtBuscarAtencion_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscarAtencion.Text.ToLower();
            if (!string.IsNullOrWhiteSpace(filtro))
            {
                var filtrados = atenciones.Where(a => a.Paciente.Apellido.ToLower().Contains(filtro) || a.Paciente.NroDni.Contains(filtro)).ToList();
                dgvFormAtencion.DataSource = filtrados;
            }
            else
            {
                dgvFormAtencion.DataSource = atenciones;

            }
            dgvFormAtencion.Columns["Id"].Visible = false;
            dgvFormAtencion.Columns["TipoAtencion"].Visible = false;
            dgvFormAtencion.Columns["Odontologo"].Visible = false;
            dgvFormAtencion.Columns["Paciente"].Visible = false;

        }

        private async void btnAgregarAtencion_Click(object sender, EventArgs e)
        {
            FormAtencion formAtencion = new FormAtencion();
            formAtencion.ShowDialog();
            await ObtenerDatos();
        }



        private void dgvFormHomeAtenciones_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvFormAtencion.SelectedRows.Count > 0)
            {
                btnEditarAtencion.Enabled = true;
                btnBorrarAtencion.Enabled = true;
            }
            else
            {
                btnEditarAtencion.Enabled = false;
                btnBorrarAtencion.Enabled = false;

            }
        }

        private async void BtnEditarAtencion_Click(object sender, EventArgs e)
        {
            if (dgvFormAtencion.SelectedRows.Count > 0)
            {
                var atencionSeleccionada = dgvFormAtencion.SelectedRows[0].DataBoundItem as Atencion;
                if (atencionSeleccionada != null)
                {
                    FormAtencion formAtencion = new FormAtencion();
                    formAtencion.ShowDialog();
                    await ObtenerDatos();
                }
            }
        }

        private async void BtnBorrarAtencion_Click(object sender, EventArgs e)
        {
            if (dgvFormAtencion.SelectedRows.Count > 0)
            {
                var atencionSeleccionada = dgvFormAtencion.SelectedRows[0].DataBoundItem as Atencion;
                if (atencionSeleccionada != null)
                {
                    var confirmResult = MessageBox.Show("¿Estás seguro de que deseas eliminar esta atención?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirmResult == DialogResult.Yes)
                    {
                        await AtencionApiClient.DeleteAsync(atencionSeleccionada.Id);
                        MessageBox.Show("Atención eliminada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await ObtenerDatos();
                    }
                }
            }
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvFormPaciente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
