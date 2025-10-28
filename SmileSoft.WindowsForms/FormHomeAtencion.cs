using SmileSoft.DTO;
using SmileSoft.API.Clients;
using SmileSoft.Dominio;
using SmileSoft.WindowsForms;
using System.Data;



namespace SmileSoft.UI.Desktop
{
    public partial class FormHomeAtencion : FormBaseHome
    {
        private static readonly HttpClient httpClient = new HttpClient()
        {
            BaseAddress = new Uri("http://localhost:54145")

        };
        private List<AtencionDetalleDTO> atenciones = new();
        public FormHomeAtencion()
        {
            InitializeComponent();

            ConfigurarEstilos();

            ConfigurarLayoutResponsivo(dgvFormAtencion, txtBuscarAtencion, lupaPng, btnAgregarAtencion, btnEditarAtencion, btnCancelarAtencion, BtnVolver);
        }
        #region
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
                    btnCancelarAtencion.BackColor = Color.FromArgb(220, 20, 60); // Crimson
                    btnEditarAtencion.BackColor = Color.FromArgb(34, 139, 34); // ForestGreen
                    btn.ForeColor = Color.White;
                    btn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btnAgregarAtencion.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 149, 237); // CornflowerBlue
                    btnCancelarAtencion.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 99, 71); // Tomato
                    btnEditarAtencion.FlatAppearance.MouseOverBackColor = Color.FromArgb(144, 238, 144); // LightGreen
                    btn.Cursor = Cursors.Hand;
                }
            }
        }
        #endregion
        private async Task ObtenerDatos()
        {
            try
            {
                var atencionesResponse = await AtencionApiClient.GetAllAsync();
                if (atencionesResponse != null && atencionesResponse.Count() > 0)
                {
                    var atencionesList = atencionesResponse.ToList();
                    foreach (var atencion in atencionesList)
                    {
                        atencion.PacienteNombre = $"{atencion.PacienteApellido}, {atencion.PacienteNombre}";
                        atencion.OdontologoNombre = $"{atencion.OdontologoApellido}, {atencion.OdontologoNombre}";
                    }

                    dgvFormAtencion.DataSource = atencionesList;
                    atenciones = atencionesList;
                    ConfiguraDgv();
                }
                else
                {
                    dgvFormAtencion.DataSource = null;
                    //atenciones.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las atenciones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void ConfiguraDgv()
        {
            dgvFormAtencion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvFormAtencion.Columns["Id"].Visible = false;
            dgvFormAtencion.Columns["FechaHoraAtencion"].HeaderText = "Fecha y hora";
            dgvFormAtencion.Columns["TipoAtencionId"].Visible = false;
            dgvFormAtencion.Columns["Observaciones"].Visible = false;
            dgvFormAtencion.Columns["OdontologoId"].Visible = false;
            dgvFormAtencion.Columns["PacienteId"].Visible = false;
            dgvFormAtencion.Columns["PacienteNombre"].HeaderText = "Paciente";
            dgvFormAtencion.Columns["PacienteApellido"].Visible = false;
            dgvFormAtencion.Columns["PacienteDni"].HeaderText = "Dni";
            dgvFormAtencion.Columns["OdontologoNombre"].HeaderText = "Odontólogo";
            dgvFormAtencion.Columns["OdontologoApellido"].Visible = false;
            dgvFormAtencion.Columns["TipoAtencionDescripcion"].HeaderText = "Atención";
            dgvFormAtencion.Columns["TipoAtencionDuracion"].HeaderText = "Duración";



            dgvFormAtencion.Columns["FechaHoraAtencion"].MinimumWidth = 150;
            dgvFormAtencion.Columns["Estado"].MinimumWidth = 120;
            dgvFormAtencion.Columns["PacienteNombre"].MinimumWidth = 140;
            dgvFormAtencion.Columns["PacienteDni"].MinimumWidth = 100;
            dgvFormAtencion.Columns["OdontologoNombre"].MinimumWidth = 140;
            dgvFormAtencion.Columns["TipoAtencionDescripcion"].MinimumWidth = 150;
            //dgvFormAtencion.Columns["TipoAtencionDuracion"].Width = 100;
            dgvFormAtencion.Columns["TipoAtencionDuracion"].MinimumWidth = 80;
        }
        private async void FormHomeAtenciones_Load(object sender, EventArgs e)
        {
            btnCancelarAtencion.Enabled = false;
            btnEditarAtencion.Enabled = false;


            await ObtenerDatos();
        }

        private void txtBuscarAtencion_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscarAtencion.Text.ToLower();
            if (!string.IsNullOrWhiteSpace(filtro))
            {
                var filtrados = atenciones.Where(a => a.PacienteNombre.ToLower().Contains(filtro) || a.PacienteApellido.ToLower().Contains(filtro) || a.PacienteDni.Contains(filtro)).ToList();
                dgvFormAtencion.DataSource = filtrados;
            }
            else
            {
                dgvFormAtencion.DataSource = atenciones;

            }
            ConfiguraDgv();

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
                btnCancelarAtencion.Enabled = true;
            }
            else
            {
                btnEditarAtencion.Enabled = false;
                btnCancelarAtencion.Enabled = false;

            }
        }

        private async void BtnEditarAtencion_Click(object sender, EventArgs e)
        {
            if (dgvFormAtencion.SelectedRows.Count > 0)
            {
                var atencionSeleccionada = dgvFormAtencion.SelectedRows[0].DataBoundItem as AtencionDetalleDTO;
                if (atencionSeleccionada != null)
                {
                    FormAtencion formAtencion = new FormAtencion(atencionSeleccionada.Id);
                    formAtencion.ShowDialog();
                    await ObtenerDatos();
                }
            }
        }

        private async void BtnBorrarAtencion_Click(object sender, EventArgs e)
        {
            MessageBox.Show("¿Está seguro que desea cancelar la atención seleccionada?", "Confirmar cancelación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            var atencion = dgvFormAtencion.SelectedRows[0].DataBoundItem as AtencionDetalleDTO;
            if (atencion != null)
            {

                await AtencionApiClient.CancelaAtencionAsync(atencion.Id);

            }
            await ObtenerDatos();
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvFormPaciente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnFiltros_Click(object sender, EventArgs e)
        {
        }
    }
}
