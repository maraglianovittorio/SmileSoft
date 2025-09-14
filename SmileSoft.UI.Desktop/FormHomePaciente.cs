using DTO;
using SmileSoft.API.Clients;
using SmileSoft.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;



namespace SmileSoft.UI.Desktop
{
    public partial class FormHomePaciente : Form
    {
        private static readonly HttpClient httpClient = new HttpClient()
        {
            BaseAddress = new Uri("http://localhost:54145")

        };
        private List<Paciente> pacientes = new();
        public FormHomePaciente()
        {
            InitializeComponent();
            ConfigurarEstilos();
            ConfigurarResponsive();
        }

        private void ConfigurarEstilos()
        {
            // Estilo principal - Tema azul elegante
            this.BackColor = Color.FromArgb(240, 248, 255); // AliceBlue
            this.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            this.Text = "SmileSoft - Página Principal";
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
                var pacientesResponse = await PacienteApiClient.GetAllAsync();
                if (pacientesResponse != null && pacientesResponse.Count() > 0 )
                {
                    dgvFormPaciente.DataSource = pacientesResponse;
                    pacientes = (List<Paciente>)pacientesResponse;
                    dgvFormPaciente.Columns["Id"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los pacientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private async void FormHomePage_Load(object sender, EventArgs e)
        {
            btnBorrarPaciente.Enabled = false;
            btnEditarPaciente.Enabled = false;
            PacienteDTO vitto = new PacienteDTO
            {
                Nombre = "Vittorio",
                Apellido = "Maragliano",
                NroDni = "111111",
                Direccion = "avenida 123",
                Email = "v@gmail.com",
                FechaNacimiento = new DateTime(2003, 11, 8),
                Telefono = "111111",
                NroAfiliado = "222222os",
                NroHC = "1"
            };
            PacienteDTO lucho = new PacienteDTO
            {
                Nombre = "Luciano",
                Apellido = "Casado",
                NroDni = "51085",
                Direccion = "Avenida siempre viva 673",
                Email = "lucho@gmail.com",
                FechaNacimiento = new DateTime(1999, 2, 20),
                Telefono = "11111",
                NroAfiliado = "22222os",
                NroHC = "2"
            };
            //Descomentar para crear pacientes de prueba
            //await PacienteApiClient.CreateAsync(vitto);
            //await PacienteApiClient.CreateAsync(lucho);
            await ObtenerDatos();
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
            dgvFormPaciente.Columns["Id"].Visible = false;

        }

        private async void btnAgregarPaciente_Click(object sender, EventArgs e)
        {
            FormPaciente formPaciente = new FormPaciente();
            formPaciente.ShowDialog();
            await ObtenerDatos();
        }



        private void dgvFormHome_SelectionChanged(object sender, EventArgs e)
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
                var pacienteSeleccionado = dgvFormPaciente.SelectedRows[0].DataBoundItem as Paciente;
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
                var pacienteSeleccionado = dgvFormPaciente.SelectedRows[0].DataBoundItem as Paciente;
                if (pacienteSeleccionado != null)
                {
                    var confirmResult = MessageBox.Show("¿Estás seguro de que deseas eliminar este paciente?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirmResult == DialogResult.Yes)
                    {
                        await PacienteApiClient.DeleteAsync(pacienteSeleccionado.Id);
                        MessageBox.Show("Paciente eliminado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
