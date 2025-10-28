using SmileSoft.DTO;
using SmileSoft.API.Clients;
using SmileSoft.WindowsForms;
using System.Data;


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
            this.BackColor = Color.FromArgb(240, 248, 255); // AliceBlue
            this.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            this.Text = "SmileSoft - Pagina Principal";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(850, 500); // Tamaño mínimo consistente con FormBaseHome

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

            if (btnAgregarAtencion != null)
            {
                btnAgregarAtencion.BackColor = Color.FromArgb(70, 130, 180); // SteelBlue
                btnAgregarAtencion.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 149, 237); // CornflowerBlue
            }
        }

        private void ConfigurarLayoutResponsivo()
        {
            int margen = 15;
            int espacioBotones = 8;
            int alturaMenu = menuStrip1.Height;

            btnAgregarAtencion.Height = txtBuscaAtencion.Height; // Misma altura que el textbox
            btnAgregarAtencion.AutoSize = true;
            btnAgregarAtencion.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnAgregarAtencion.Padding = new Padding(12, 0, 12, 0);
            btnAgregarAtencion.TextAlign = ContentAlignment.MiddleCenter;
            btnAgregarAtencion.MinimumSize = new Size(150, txtBuscaAtencion.Height);
            btnAgregarAtencion.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            BtnCerrarSesion.Height = 38;
            BtnCerrarSesion.AutoSize = true;
            BtnCerrarSesion.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BtnCerrarSesion.Padding = new Padding(12, 0, 12, 0);
            BtnCerrarSesion.TextAlign = ContentAlignment.MiddleCenter;
            BtnCerrarSesion.MinimumSize = new Size(120, 38);

            btnEditarAtencion.Height = 38;
            btnEditarAtencion.AutoSize = true;
            btnEditarAtencion.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnEditarAtencion.Padding = new Padding(12, 0, 12, 0);
            btnEditarAtencion.TextAlign = ContentAlignment.MiddleCenter;
            btnEditarAtencion.MinimumSize = new Size(130, 38);

            btnRegistrarLlegada.Height = 38;
            btnRegistrarLlegada.AutoSize = true;
            btnRegistrarLlegada.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnRegistrarLlegada.Padding = new Padding(12, 0, 12, 0);
            btnRegistrarLlegada.TextAlign = ContentAlignment.MiddleCenter;
            btnRegistrarLlegada.MinimumSize = new Size(150, 38);

            lblAtencionesDelDia.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            lblAtencionesDelDia.Location = new Point(margen, alturaMenu + 11);

            txtBuscaAtencion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscaAtencion.Location = new Point(margen, lblAtencionesDelDia.Bottom + 8);

            cmbFiltroEstado.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbFiltroEstado.Width = 151;

            txtBuscaAtencion.Width = this.ClientSize.Width - cmbFiltroEstado.Width - btnAgregarAtencion.Width - (margen * 2) - (espacioBotones * 2);
            
            cmbFiltroEstado.Location = new Point(txtBuscaAtencion.Right + espacioBotones, txtBuscaAtencion.Top);
            
            btnAgregarAtencion.Location = new Point(
                cmbFiltroEstado.Right + espacioBotones,
                txtBuscaAtencion.Top
            );

            dgvAtencionesDelDia.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvAtencionesDelDia.Location = new Point(margen, txtBuscaAtencion.Bottom + margen);
            dgvAtencionesDelDia.Size = new Size(
                this.ClientSize.Width - (margen * 2),
                this.ClientSize.Height - txtBuscaAtencion.Bottom - 38 - (margen * 3)
            );

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

            this.Resize += FormHomeSecretario_Resize;
        }
        private void dgvAtencionesDelDia_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAtencionesDelDia.SelectedRows.Count > 0)
            {
                btnEditarAtencion.Enabled = true;
                btnRegistrarLlegada.Enabled = true;
            }
            else
            {
                btnEditarAtencion.Enabled = false;
                btnRegistrarLlegada.Enabled = false;

            }
        }
        private void FormHomeSecretario_Resize(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                int margen = 15;
                int espacioBotones = 8;

                txtBuscaAtencion.Width = this.ClientSize.Width - cmbFiltroEstado.Width - btnAgregarAtencion.Width - (margen * 2) - (espacioBotones * 2);
                
                cmbFiltroEstado.Location = new Point(txtBuscaAtencion.Right + espacioBotones, txtBuscaAtencion.Top);
                btnAgregarAtencion.Location = new Point(
                    cmbFiltroEstado.Right + espacioBotones,
                    txtBuscaAtencion.Top
                );
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
                var turnosDelDia = await AtencionApiClient.GetByFechaRangeAsync(DateTime.Today.Date, DateTime.Today.Date.AddDays(1));
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las atenciones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfiguraDgv()
        {
            dgvAtencionesDelDia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

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
            dgvAtencionesDelDia.Columns["FechaHoraAtencion"].MinimumWidth = 130;
            dgvAtencionesDelDia.Columns["PacienteNombre"].MinimumWidth = 130;
            dgvAtencionesDelDia.Columns["PacienteDni"].MinimumWidth = 130;
            dgvAtencionesDelDia.Columns["OdontologoNombre"].MinimumWidth = 130;
            dgvAtencionesDelDia.Columns["Estado"].MinimumWidth = 130;
            dgvAtencionesDelDia.Columns["TipoAtencionDescripcion"].MinimumWidth = 130;
            dgvAtencionesDelDia.Columns["TipoAtencionDuracion"].MinimumWidth = 130;
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
                if (atencionSeleccionada != null && atencionSeleccionada.Estado != "Atendido")
                {
                    await AtencionApiClient.ActualizaLlegada(atencionSeleccionada.Id);
                    await ObtenerDatos();
                }
                else
                {
                    MessageBox.Show("La atencion ya fue completada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void cmbFiltroEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
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

        private async void btnAgregarAtencion_Click(object sender, EventArgs e)
        {
            FormAtencion formAtencion = new FormAtencion();
            formAtencion.ShowDialog();
            await ObtenerDatos();
        }
    }
}
