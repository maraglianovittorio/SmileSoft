using SmileSoft.DTO;
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
        private List<AtencionDetalleDTO> atenciones = new List<AtencionDetalleDTO>();
        public FormHomeSecretario()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
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
            FormHomeOS formHomeOS = new FormHomeOS("SECRETARIO");
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
                atenciones = turnosDelDia.ToList();
                if (turnosDelDia != null && turnosDelDia.Count() > 0)
                {

                    var turnosList = turnosDelDia.ToList();
                    foreach (var turno in turnosList)
                    {
                        turno.PacienteNombre = $"{turno.PacienteApellido}, {turno.PacienteNombre}";
                        turno.OdontologoNombre = $"{turno.OdontologoApellido}, {turno.OdontologoNombre}";
                    }

                    dgvAtencionesDelDia.DataSource = turnosDelDia;
                    ConfiguraDgv();

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
                MessageBox.Show($"Error al cargar las atenciones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void ConfiguraDgv()
        {
            dgvAtencionesDelDia.Columns["Id"].Visible = false;
            dgvAtencionesDelDia.Columns["FechaHoraAtencion"].HeaderText = "Fecha y hora";
            dgvAtencionesDelDia.Columns["TipoAtencionId"].Visible = false;
            dgvAtencionesDelDia.Columns["Observaciones"].Visible = false;
            dgvAtencionesDelDia.Columns["OdontologoId"].Visible = false;
            dgvAtencionesDelDia.Columns["PacienteId"].Visible = false;
            dgvAtencionesDelDia.Columns["PacienteNombre"].HeaderText = "Paciente";
            dgvAtencionesDelDia.Columns["PacienteApellido"].Visible = false;
            dgvAtencionesDelDia.Columns["PacienteDni"].HeaderText = "Dni";
            dgvAtencionesDelDia.Columns["OdontologoNombre"].HeaderText = "Odontólogo";
            dgvAtencionesDelDia.Columns["OdontologoApellido"].Visible = false;
            dgvAtencionesDelDia.Columns["TipoAtencionDescripcion"].HeaderText = "Atención";
            dgvAtencionesDelDia.Columns["TipoAtencionDuracion"].HeaderText = "Duración";

            // Configurar anchos de columnas
            dgvAtencionesDelDia.Columns["FechaHoraAtencion"].Width = 150;
            dgvAtencionesDelDia.Columns["PacienteNombre"].Width = 200;
            dgvAtencionesDelDia.Columns["PacienteDni"].Width = 100;
            dgvAtencionesDelDia.Columns["OdontologoNombre"].Width = 200;
            dgvAtencionesDelDia.Columns["Estado"].Width = 100;
            dgvAtencionesDelDia.Columns["TipoAtencionDescripcion"].Width = 150;
            dgvAtencionesDelDia.Columns["TipoAtencionDuracion"].Width = 100;
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

        private async void btnRegistrarLlegada_Click(object sender, EventArgs e)
        {
            if (dgvAtencionesDelDia.SelectedRows.Count > 0)
            {
                var atencionSeleccionada = dgvAtencionesDelDia.SelectedRows[0].DataBoundItem as AtencionDetalleDTO;
                if (atencionSeleccionada != null)
                {
                    await AtencionApiClient.ActualizaLlegada(atencionSeleccionada.Id);
                    await ObtenerDatos();
                }
            }
        }

        private void cmbFiltroEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            // creo un filtro de las atenciones dependiendo del estado
            string filtro = cmbFiltroEstado.SelectedItem.ToString();
            if (filtro == "Todas")
            {
                dgvAtencionesDelDia.DataSource = atenciones;
            }
            else
            {
                var atencionesFiltradas = atenciones.Where(a => a.Estado == filtro).ToList();
                dgvAtencionesDelDia.DataSource = atencionesFiltradas;
            }
            ConfiguraDgv();
        }

        private async void txtBuscaAtencion_TextChanged(object sender, EventArgs e)
        {
            // filtro por nombre de paciente o por dni
            string busqueda = txtBuscaAtencion.Text.ToLower();
            var atencionesFiltradas = atenciones.Where(a =>
                a.PacienteNombre.ToLower().Contains(busqueda)
                || a.PacienteApellido.ToLower().Contains(busqueda)||
                a.PacienteDni.ToLower().Contains(busqueda)
            ).ToList();
            ConfiguraDgv();

            dgvAtencionesDelDia.DataSource = atencionesFiltradas;
        }
    }
}
