using DTO;
using SmileSoft.API.Clients;
using SmileSoft.Dominio;
using System.Data;



namespace SmileSoft.UI.Desktop
{
    public partial class FormHomeTutor : Form
    {
        private static readonly HttpClient httpClient = new HttpClient()
        {
            BaseAddress = new Uri("http://localhost:54145")

        };
        private List<PersonaDTO> tutores = new();
        public FormHomeTutor()
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
            this.Text = "SmileSoft - Home de pacientes";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(800, 450); // Tamaño mínimo

            // Estilo para botones
            foreach (Control control in this.Controls)
            {
                if (control is Button btn)
                {
                    btnAgregarTutor.BackColor = Color.FromArgb(70, 130, 180); // SteelBlue
                    btnBorrarTutor.BackColor = Color.FromArgb(220, 20, 60); // Crimson
                    btnEditarTutor.BackColor = Color.FromArgb(34, 139, 34); // ForestGreen
                    btn.ForeColor = Color.White;
                    btn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btnAgregarTutor.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 149, 237); // CornflowerBlue
                    btnBorrarTutor.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 99, 71); // Tomato
                    btnEditarTutor.FlatAppearance.MouseOverBackColor = Color.FromArgb(144, 238, 144); // LightGreen
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
                var personasResponse = await PersonaApiClient.GetAllTutorsAsync();
                if (personasResponse != null && personasResponse.Count() > 0)
                {
                    dgvFormTutor.DataSource = personasResponse;
                    tutores = (List<PersonaDTO>)personasResponse;
                    dgvFormTutor.Columns["Id"].Visible = false;
                }
                else
                {
                    dgvFormTutor.DataSource = null;
                    tutores.Clear();
                    MessageBox.Show("No se encontraron tutores.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los tutores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private async void FormHomeTutor_Load(object sender, EventArgs e)
        {
            btnBorrarTutor.Enabled = false;
            btnEditarTutor.Enabled = false;

            await ObtenerDatos();
        }

        private void txtBuscarTutor_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscarTutor.Text.ToLower();
            if (!string.IsNullOrWhiteSpace(filtro))
            {
                var filtrados = tutores.Where(p => p.Apellido.ToLower().Contains(filtro) || p.NroDni.Contains(filtro)).ToList();
                dgvFormTutor.DataSource = filtrados;
            }
            else
            {
                dgvFormTutor.DataSource = tutores;

            }
            dgvFormTutor.Columns["Id"].Visible = false;

        }

        private async void btnAgregarTutor_Click(object sender, EventArgs e)
        {
            FormTutor formTutor = new FormTutor();
            formTutor.ShowDialog();
            await ObtenerDatos();
        }



        private void dgvFormHomeTutor_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvFormTutor.SelectedRows.Count > 0)
            {
                btnEditarTutor.Enabled = true;
                btnBorrarTutor.Enabled = true;
            }
            else
            {
                btnEditarTutor.Enabled = false;
                btnBorrarTutor.Enabled = false;

            }
        }

        private async void BtnEditarTutor_Click(object sender, EventArgs e)
        {
            if (dgvFormTutor.SelectedRows.Count > 0)
            {
                var tutorSeleccionado = dgvFormTutor.SelectedRows[0].DataBoundItem as PersonaDTO;
                if (tutorSeleccionado != null)
                {
                    FormTutor formTutor = new FormTutor(tutorSeleccionado.Id);
                    formTutor.ShowDialog();
                    await ObtenerDatos();
                }
            }
        }

        private async void BtnBorrarTutor_Click(object sender, EventArgs e)
        {
            if (dgvFormTutor.SelectedRows.Count > 0)
            {
                var tutorSeleccionado = dgvFormTutor.SelectedRows[0].DataBoundItem as PersonaDTO;
                if (tutorSeleccionado != null)
                {
                    var confirmResult = MessageBox.Show("¿Estás seguro de que deseas eliminar este tutor?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirmResult == DialogResult.Yes)
                    {
                        await PersonaApiClient.DeleteAsync(tutorSeleccionado.Id);
                        MessageBox.Show("Tutor eliminado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
