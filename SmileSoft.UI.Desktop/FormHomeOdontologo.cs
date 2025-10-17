using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmileSoft.WindowsForms;
using SmileSoft.API.Clients;
using SmileSoft.Dominio;

namespace SmileSoft.UI.Desktop
{
    public partial class FormHomeOdontologo : Form
    {
        private static readonly HttpClient httpClient = new HttpClient()
        {
            BaseAddress = new Uri("http://localhost:54145")
        };
        private List<Odontologo> odontologos = new();

        public FormHomeOdontologo()
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
            this.Text = "SmileSoft - Home de Odontólogos";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(800, 450); // Tamaño mínimo

            // Estilo para botones
            foreach (Control control in this.Controls)
            {
                if (control is Button btn)
                {
                    btnAgregarOdontologo.BackColor = Color.FromArgb(70, 130, 180); // SteelBlue
                    btnBorrarOdontologo.BackColor = Color.FromArgb(220, 20, 60); // Crimson
                    btnEditarOdontologo.BackColor = Color.FromArgb(34, 139, 34); // ForestGreen
                    btn.ForeColor = Color.White;
                    btn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btnAgregarOdontologo.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 149, 237); // CornflowerBlue
                    btnBorrarOdontologo.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 99, 71); // Tomato
                    btnEditarOdontologo.FlatAppearance.MouseOverBackColor = Color.FromArgb(144, 238, 144); // LightGreen
                    btn.Cursor = Cursors.Hand;
                }
            }
        }

        private void ConfigurarResponsive()
        {
            // Hacer que el formulario sea redimensionable
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;

            // Manejar el evento de redimensionado para centrar los botones
            this.Resize += FormHomeOdontologo_Resize;
        }

        private void FormHomeOdontologo_Resize(object sender, EventArgs e)
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
                var odontologosResponse = await OdontologoApiClient.GetAllAsync();
                if (odontologosResponse != null && odontologosResponse.Count() > 0)
                {
                    dgvFormOdontologo.DataSource = odontologosResponse;
                    odontologos = (List<Odontologo>)odontologosResponse;
                    dgvFormOdontologo.Columns["Id"].Visible = false;
                    //dgvFormOdontologo.Columns["Password"].Visible = false;
                    //dgvFormOdontologo.Columns["Rol"].Visible = false;
                    dgvFormOdontologo.Columns["ObrasSociales"].Visible = false;
                }
                else
                {
                    dgvFormOdontologo.DataSource = null;
                    odontologos.Clear();
                    MessageBox.Show("No se encontraron odontólogos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los odontólogos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void FormHomeOdontologo_Load(object sender, EventArgs e)
        {
            btnBorrarOdontologo.Enabled = false;
            btnEditarOdontologo.Enabled = false;

            await ObtenerDatos();
        }

        private void txtBuscarOdontologo_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscarOdontologo.Text.ToLower();
            if (!string.IsNullOrWhiteSpace(filtro))
            {
                var filtrados = odontologos.Where(o => o.Apellido.ToLower().Contains(filtro) || o.NroMatricula.Contains(filtro)).ToList();
                dgvFormOdontologo.DataSource = filtrados;
            }
            else
            {
                dgvFormOdontologo.DataSource = odontologos;
            }
            dgvFormOdontologo.Columns["Id"].Visible = false;
            dgvFormOdontologo.Columns["Password"].Visible = false;
            dgvFormOdontologo.Columns["Rol"].Visible = false;
            dgvFormOdontologo.Columns["ObrasSociales"].Visible = false;
        }

        private async void btnAgregarOdontologo_Click(object sender, EventArgs e)
        {
            FormOdontologo formOdontologo = new FormOdontologo();
            formOdontologo.ShowDialog();
            await ObtenerDatos();
        }

        private void dgvFormHomeOdontologo_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvFormOdontologo.SelectedRows.Count > 0)
            {
                btnEditarOdontologo.Enabled = true;
                btnBorrarOdontologo.Enabled = true;
            }
            else
            {
                btnEditarOdontologo.Enabled = false;
                btnBorrarOdontologo.Enabled = false;
            }
        }

        private async void btnEditarOdontologo_Click(object sender, EventArgs e)
        {
            if (dgvFormOdontologo.SelectedRows.Count > 0)
            {
                var odontologoSeleccionado = dgvFormOdontologo.SelectedRows[0].DataBoundItem as Odontologo;
                if (odontologoSeleccionado != null)
                {
                    FormOdontologo formOdontologo = new FormOdontologo(odontologoSeleccionado.Id);
                    formOdontologo.ShowDialog();
                    await ObtenerDatos();
                }
            }
        }

        private async void btnBorrarOdontologo_Click(object sender, EventArgs e)
        {
            if (dgvFormOdontologo.SelectedRows.Count > 0)
            {
                var odontologoSeleccionado = dgvFormOdontologo.SelectedRows[0].DataBoundItem as Odontologo;
                if (odontologoSeleccionado != null)
                {
                    var confirmResult = MessageBox.Show("¿Estás seguro de que deseas eliminar este odontólogo?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirmResult == DialogResult.Yes)
                    {
                        await OdontologoApiClient.DeleteAsync(odontologoSeleccionado.Id);
                        MessageBox.Show("Odontólogo eliminado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await ObtenerDatos();
                    }
                }
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPacientes_Click(object sender, EventArgs e)
        {
            FormHomePaciente formHomePagePaciente = new FormHomePaciente();
            formHomePagePaciente.ShowDialog();
        }

        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            this.Close();
            formLogin.Show();
        }

        private void dgvFormOdontologo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
