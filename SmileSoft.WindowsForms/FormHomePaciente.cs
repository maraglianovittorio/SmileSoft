using SmileSoft.DTO;
using SmileSoft.API.Clients;
using SmileSoft.Dominio;
using System.Data;
using Microsoft.EntityFrameworkCore;
using SmileSoft.WindowsForms;


namespace SmileSoft.UI.Desktop
{
    public partial class FormHomePaciente : FormBaseHome
    {
        private static readonly HttpClient httpClient = new HttpClient()
        {
            BaseAddress = new Uri("http://localhost:54145")

        };
        private List<PacienteDTO> pacientes = new();
        private Button btnGenerarReporte;
        public FormHomePaciente()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            ConfigurarEstilos();
            ConfigurarLayoutResponsivo(dgvFormPaciente, txtBuscarPaciente, lupaPng, btnAgregarPaciente, btnEditarPaciente, btnBorrarPaciente, BtnVolver);

            //ConfigurarResponsive();
        }

        private void ConfigurarEstilos()
        {
            // Estilo principal
            this.BackColor = Color.FromArgb(240, 248, 255); // AliceBlue
            this.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            this.Text = "SmileSoft - Home de pacientes";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(800, 450); // Tamaño mínimo

            // Estilo para botones
            foreach (Control control in this.Controls)
            {
                if (control is Button btn)
                {
                    btnAgregarPaciente.BackColor = Color.FromArgb(70, 130, 180); // SteelBlue
                    btnBorrarPaciente.BackColor = Color.FromArgb(220, 20, 60); // Crimson
                    btnEditarPaciente.BackColor = Color.FromArgb(34, 139, 34); // ForestGreen
                    btn.ForeColor = Color.White;
                    btn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btnAgregarPaciente.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 149, 237); // CornflowerBlue
                    btnBorrarPaciente.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 99, 71); // Tomato
                    btnEditarPaciente.FlatAppearance.MouseOverBackColor = Color.FromArgb(144, 238, 144); // LightGreen
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
            this.Resize += FormHomePacientes_Resize;
        }

        private void FormHomePacientes_Resize(object sender, EventArgs e)
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
                var pacientesResponse = await PacienteApiClient.GetAllAsync();
                if (pacientesResponse != null && pacientesResponse.Count() > 0)
                {
                    var pacientesList = pacientesResponse.ToList();
                    foreach (var paciente in pacientesList)
                    {
                        if (paciente.NroAfiliado == string.Empty)
                            paciente.NroAfiliado = $"Sin OS";   
                    }

                    dgvFormPaciente.DataSource = pacientesList;
                    pacientes = pacientesList;
                    ConfiguraDgv();
                }

                else
                {
                    dgvFormPaciente.DataSource = null;
                    pacientes.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los pacientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void ConfiguraDgv()
        {
            dgvFormPaciente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFormPaciente.Columns["Id"].Visible = false;
            dgvFormPaciente.Columns["TutorId"].Visible = false;
            dgvFormPaciente.Columns["NroDni"].HeaderText = "DNI";
            dgvFormPaciente.Columns["TipoPlanId"].Visible = false;


            // Ordenar las columnas visibles
            dgvFormPaciente.Columns["NroHC"].DisplayIndex = 0;
            dgvFormPaciente.Columns["Apellido"].DisplayIndex = 1;
            dgvFormPaciente.Columns["Nombre"].DisplayIndex = 2;
            dgvFormPaciente.Columns["NroDni"].DisplayIndex = 3;
            dgvFormPaciente.Columns["Telefono"].DisplayIndex = 4;
            dgvFormPaciente.Columns["Email"].DisplayIndex = 5;
            dgvFormPaciente.Columns["Direccion"].DisplayIndex = 6;
            dgvFormPaciente.Columns["FechaNacimiento"].DisplayIndex = 7;
            dgvFormPaciente.Columns["NroAfiliado"].DisplayIndex = 8;

        }
        private async void FormHomePacientes_Load(object sender, EventArgs e)
        {
            btnBorrarPaciente.Enabled = false;
            btnEditarPaciente.Enabled = false;

            ConfigurarBotones();
            await ObtenerDatos();
        }

        private void ConfigurarBotones()
        {
            btnGenerarReporte = new Button
            {
                Text = "Generar Reporte PDF",
                Location = new Point(600, 10),
                Size = new Size(180, 35),
                BackColor = Color.FromArgb(70, 130, 180),
                ForeColor = Color.White
            };
            btnGenerarReporte.Click += btnGenerarReporte_Click;
            this.Controls.Add(btnGenerarReporte);
        }

        private async void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            
        }

        private void txtBuscarPaciente_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscarPaciente.Text.ToLower();
            if (!string.IsNullOrWhiteSpace(filtro))
            {
                var filtrados = pacientes.Where(p => p.Apellido.ToLower().Contains(filtro) || p.NroDni.Contains(filtro)).ToList();
                dgvFormPaciente.DataSource = filtrados;
            }
            else
            {
                dgvFormPaciente.DataSource = pacientes;

            }
            ConfiguraDgv();

        }

        private async void btnAgregarPaciente_Click(object sender, EventArgs e)
        {
            FormPaciente formPaciente = new FormPaciente();
            formPaciente.ShowDialog();
            await ObtenerDatos();
        }



        private void dgvFormHomePacientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvFormPaciente.SelectedRows.Count > 0)
            {
                btnEditarPaciente.Enabled = true;
                btnBorrarPaciente.Enabled = true;
            }
            else
            {
                btnEditarPaciente.Enabled = false;
                btnBorrarPaciente.Enabled = false;

            }
        }

        private async void BtnEditarPaciente_Click(object sender, EventArgs e)
        {
            if (dgvFormPaciente.SelectedRows.Count > 0)
            {
                var pacienteSeleccionado = dgvFormPaciente.SelectedRows[0].DataBoundItem as PacienteDTO;
                if (pacienteSeleccionado != null)
                {
                    FormPaciente formPaciente = new FormPaciente(pacienteSeleccionado.Id);
                    formPaciente.ShowDialog();
                    await ObtenerDatos();
                }
            }
        }

        private async void BtnBorrarPaciente_Click(object sender, EventArgs e)
        {
            if (dgvFormPaciente.SelectedRows.Count > 0)
            {
                var pacienteSeleccionado = dgvFormPaciente.SelectedRows[0].DataBoundItem as PacienteDTO;
                if (pacienteSeleccionado != null)
                {
                    var confirmResult = MessageBox.Show("¿Estás seguro de que deseas eliminar este paciente?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirmResult == DialogResult.Yes)
                    {
                        var paciente = dgvFormPaciente.SelectedRows[0].DataBoundItem as PacienteDTO;
                        if (paciente != null)
                        {
                            try
                            {
                                await PacienteApiClient.DeleteAsync(paciente.Id);
                                MessageBox.Show(
                                    "Paciente eliminado correctamente.",
                                    "Éxito",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                                await ObtenerDatos();
                            }
                            catch (DbUpdateException ex)
                            {
                                MessageBox.Show(
                                    $"Error al eliminar el paciente: {ex.Message}",
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(
                                    "No se puede eliminar el paciente porque tiene registros relacionados.",
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                            }

                        }
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
