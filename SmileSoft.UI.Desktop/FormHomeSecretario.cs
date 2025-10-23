using DTO;
using SmileSoft.API.Clients;
using SmileSoft.Dominio;
using SmileSoft.WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmileSoft.UI.Desktop
{
    public partial class FormHomeSecretario : Form
    {
        public FormHomeSecretario()
        {
            InitializeComponent();
            ConfigurarEstilos();
        }
        private void ConfigurarEstilos()
        {
            // Estilo principal - Tema azul elegante
            this.BackColor = Color.FromArgb(240, 248, 255); // AliceBlue
            this.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            this.Text = "SmileSoft - Pagina Principal";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(800, 450); // Tamaño mínimo

            // Estilo para botones
            foreach (Control control in this.Controls)
            {
                if (control is Button btn)
                {
                    btn.ForeColor = Color.White;
                    btn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Cursor = Cursors.Hand;
                }
            }
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

        private void atencionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FormHomeAtencion formHomeAtencion = new FormHomeAtencion();
            //formHomeAtencion.ShowDialog();
        }

        private void pacientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHomePaciente formHomePagePaciente = new FormHomePaciente();
            formHomePagePaciente.ShowDialog();
        }

        private void tutoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHomeTutor formHomeTutor = new FormHomeTutor();
            formHomeTutor.ShowDialog();
        }

        private void oToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // este nose si iria, seria un formulario para nada mas VER las obras sociales con las que trabaja la clinica
            FormHomeOS formHomeOS = new FormHomeOS();
            formHomeOS.ShowDialog();
        }

        private async void FormHomeSecretario_Load(object sender, EventArgs e)
        {
            await ObtenerDatos();

        }
        private async Task ObtenerDatos()
        {
            try
            {
                var turnosDelDia = await AtencionApiClient.GetByFechaRangeAsync(DateTime.Today, DateTime.Today.AddHours(23));
                if (turnosDelDia!= null && turnosDelDia.Count() > 0)
                {
                    dgvAtencionesDelDia.DataSource = turnosDelDia;
                    //pacientes = (List<PacienteDTO>)turnosDelDia;
                    //dgvFormPaciente.Columns["Id"].Visible = false;
                    ////dgvFormPaciente.Columns["Atenciones"].Visible = false;
                    ////dgvFormPaciente.Columns["TipoPlan"].Visible = false;
                    //dgvFormPaciente.Columns["TutorId"].Visible = false;
                    ////dgvFormPaciente.Columns["Tutor"].Visible = false;

                    //// Ordenar las columnas visibles
                    //dgvFormPaciente.Columns["NroHC"].DisplayIndex = 0;
                    //dgvFormPaciente.Columns["Apellido"].DisplayIndex = 1;
                    //dgvFormPaciente.Columns["Nombre"].DisplayIndex = 2;
                    //dgvFormPaciente.Columns["NroDni"].DisplayIndex = 3;
                    //dgvFormPaciente.Columns["Telefono"].DisplayIndex = 4;
                    //dgvFormPaciente.Columns["Email"].DisplayIndex = 5;
                    //dgvFormPaciente.Columns["Direccion"].DisplayIndex = 6;
                    //dgvFormPaciente.Columns["FechaNacimiento"].DisplayIndex = 7;
                    //dgvFormPaciente.Columns["NroAfiliado"].DisplayIndex = 8;
                    //dgvFormPaciente.Columns["TipoPlanId"].DisplayIndex = 9;
                }
                else
                {
                    dgvAtencionesDelDia.DataSource = null;
                    //pacientes.Clear();
                    MessageBox.Show("No se encontraron atenciones para el dia de hoy.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los pacientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private async void agregarAtencionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAtencion formAtencion = new FormAtencion();
            formAtencion.ShowDialog();
            await ObtenerDatos();
        }

        private void verAtencionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHomeAtencion formHomeAtencion = new FormHomeAtencion();
            formHomeAtencion.ShowDialog();
        }

        private async void btnEditarAtencion_Click(object sender, EventArgs e)
        {
            if (dgvAtencionesDelDia.SelectedRows.Count > 0)
            {
                var atencionSeleccionada = dgvAtencionesDelDia.SelectedRows[0].DataBoundItem as AtencionDetalleDTO;
                if (atencionSeleccionada != null)
                {
                    FormAtencion formAtencion = new FormAtencion(atencionSeleccionada.Id);
                    formAtencion.ShowDialog();
                    await ObtenerDatos();
                }
            }
        }
    }
}
