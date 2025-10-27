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
            ConfigurarLayoutResponsivo();
        }

        private void ConfigurarEstilos()
        {
            // Estilo principal - Tema azul elegante
            this.BackColor = Color.FromArgb(240, 248, 255); // AliceBlue
            this.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            this.Text = "SmileSoft - Pagina Principal";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(850, 500); // Tamaño mínimo consistente con FormBaseHome

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

        private void ConfigurarLayoutResponsivo()
        {
            // Márgenes y espaciado consistentes con FormBaseHome
            int margen = 15;
            int espacioBotones = 8;
            int alturaMenu = menuStrip1.Height;

            // --- Configurar botones de acción ---
            // Ajustar tamaños más compactos
            BtnCerrarSesion.Height = 38;
            BtnCerrarSesion.Width = 120;
            BtnCerrarSesion.AutoSize = false;
            BtnCerrarSesion.Padding = new Padding(10, 0, 10, 0);
            BtnCerrarSesion.TextAlign = ContentAlignment.MiddleCenter;

            btnEditarAtencion.Height = 38;
            btnEditarAtencion.Width = 130;
            btnEditarAtencion.AutoSize = false;
            btnEditarAtencion.Padding = new Padding(10, 0, 10, 0);
            btnEditarAtencion.TextAlign = ContentAlignment.MiddleCenter;

            btnRegistrarLlegada.Height = 38;
            btnRegistrarLlegada.Width = 150;
            btnRegistrarLlegada.AutoSize = false;
            btnRegistrarLlegada.Padding = new Padding(10, 0, 10, 0);
            btnRegistrarLlegada.TextAlign = ContentAlignment.MiddleCenter;

            // --- Label "Atenciones del día" ---
            lblAtencionesDelDia.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            lblAtencionesDelDia.Location = new Point(margen, alturaMenu + 11);

            // --- TextBox de búsqueda ---
            txtBuscaAtencion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscaAtencion.Location = new Point(margen, lblAtencionesDelDia.Bottom + 8);

            // --- ComboBox de filtro de estado ---
            cmbFiltroEstado.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbFiltroEstado.Width = 151;

            // Ajustar ancho del buscador para dejar espacio al combo
            txtBuscaAtencion.Width = this.ClientSize.Width - cmbFiltroEstado.Width - (margen * 2) - espacioBotones;
            cmbFiltroEstado.Location = new Point(txtBuscaAtencion.Right + espacioBotones, txtBuscaAtencion.Top);

            // --- DataGridView (Centro) ---
            dgvAtencionesDelDia.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvAtencionesDelDia.Location = new Point(margen, txtBuscaAtencion.Bottom + margen);
            dgvAtencionesDelDia.Size = new Size(
                this.ClientSize.Width - (margen * 2),
                this.ClientSize.Height - txtBuscaAtencion.Bottom - BtnCerrarSesion.Height - (margen * 3)
            );

            // --- Panel Inferior (Botones de Acción) ---
            BtnCerrarSesion.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            BtnCerrarSesion.Location = new Point(margen, this.ClientSize.Height - BtnCerrarSesion.Height - margen);

            btnRegistrarLlegada.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRegistrarLlegada.Location = new Point(
                this.ClientSize.Width - btnRegistrarLlegada.Width - margen,
                this.ClientSize.Height - btnRegistrarLlegada.Height - margen
            );

            btnEditarAtencion.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnEditarAtencion.Location = new Point(
                btnRegistrarLlegada.Left - btnEditarAtencion.Width - espacioBotones,
                this.ClientSize.Height - btnEditarAtencion.Height - margen
            );

            // Manejar el evento Resize para mantener el layout responsivo
            this.Resize += FormHomeSecretario_Resize;
        }

        private void FormHomeSecretario_Resize(object sender, EventArgs e)
        {
            // Recalcular posiciones cuando se redimensiona el formulario
            if (this.WindowState != FormWindowState.Minimized)
            {
                int margen = 15;
                int espacioBotones = 8;

                // Ajustar ancho del buscador
                txtBuscaAtencion.Width = this.ClientSize.Width - cmbFiltroEstado.Width - (margen * 2) - espacioBotones;
                cmbFiltroEstado.Location = new Point(txtBuscaAtencion.Right + espacioBotones, txtBuscaAtencion.Top);
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

        private void txtBuscaAtencion_TextChanged(object sender, EventArgs e)
        {
            // filtro por nombre de paciente o por dni
            string busqueda = txtBuscaAtencion.Text.ToLower();
            var atencionesFiltradas = atenciones.Where(a =>
                a.PacienteNombre.ToLower().Contains(busqueda)
                || a.PacienteApellido.ToLower().Contains(busqueda) ||
                a.PacienteDni.ToLower().Contains(busqueda)
            ).ToList();

            dgvAtencionesDelDia.DataSource = atencionesFiltradas;
            ConfiguraDgv();
        }

        private async void atencionesDelDíaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Formulario para seleccionar fecha
                using (var formFecha = new Form())
                {
                    formFecha.Text = "Seleccionar fecha del reporte";
                    formFecha.Size = new Size(350, 150);
                    formFecha.StartPosition = FormStartPosition.CenterParent;

                    var lblFecha = new Label { Text = "Fecha:", Location = new Point(20, 20), AutoSize = true };
                    var dtpFecha = new DateTimePicker { Location = new Point(100, 20), Width = 200, Value = DateTime.Now };

                    var btnGenerar = new Button { Text = "Generar", Location = new Point(100, 60), Width = 100 };
                    var btnCancelar = new Button { Text = "Cancelar", Location = new Point(210, 60), Width = 90 };

                    btnGenerar.Click += (s, ev) => { formFecha.DialogResult = DialogResult.OK; formFecha.Close(); };
                    btnCancelar.Click += (s, ev) => { formFecha.DialogResult = DialogResult.Cancel; formFecha.Close(); };

                    formFecha.Controls.AddRange(new Control[] { lblFecha, dtpFecha, btnGenerar, btnCancelar });

                    if (formFecha.ShowDialog() == DialogResult.OK)
                    {
                        var request = new ReporteAtencionesOdontologoRequestDTO
                        {
                            Fecha = dtpFecha.Value.Date
                        };

                        var pdfBytes = await ReporteApiClient.GenerarReporteAtencionesOdontologoAsync(request);

                        using (var saveDialog = new SaveFileDialog())
                        {
                            saveDialog.Filter = "PDF Files|*.pdf";
                            saveDialog.FileName = $"Agenda_Odontologos_{dtpFecha.Value:yyyyMMdd}.pdf";
                            saveDialog.Title = "Guardar Reporte de Agenda Diaria";

                            if (saveDialog.ShowDialog() == DialogResult.OK)
                            {
                                File.WriteAllBytes(saveDialog.FileName, pdfBytes);
                                MessageBox.Show("Reporte de agenda generado exitosamente", "Éxito",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                                {
                                    FileName = saveDialog.FileName,
                                    UseShellExecute = true
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar reporte: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
