using SmileSoft.WindowsForms;
using SmileSoft.API.Auth.WindowsForms;
using SmileSoft.API.Clients;
using SmileSoft.DTO;

namespace SmileSoft.UI.Desktop
{
    public partial class FormHomeSuperUsuario : Form
    {
        public FormHomeSuperUsuario()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            ConfigurarEstilos();
            this.ActiveControl = null;

        }
        private void ConfigurarEstilos()
        {
            this.BackColor = Color.FromArgb(240, 248, 255); // AliceBlue
            this.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            this.Text = "SmileSoft - Pagina Principal";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(800, 450); // Tamaño mínimo
            BtnCerrarSesion.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;


        }


        private async void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            var authService = new WindowsFormsAuthService();
            await authService.LogoutAsync();
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
            this.Close();
        }

        private void toolStripPaciente_Click(object sender, EventArgs e)
        {
            FormHomePaciente formHomePaciente = new FormHomePaciente();
            formHomePaciente.ShowDialog();
        }

        private void toolStripOS_Click(object sender, EventArgs e)
        {
            FormHomeOS formHomeOS = new FormHomeOS("ADMIN");
            formHomeOS.ShowDialog();
        }

        private void toolStripUsuarios_Click(object sender, EventArgs e)
        {
            FormHomeUsuario formUsuario = new FormHomeUsuario();
            formUsuario.ShowDialog();
        }

        private void toolStripTipoPlan_Click(object sender, EventArgs e)
        {
            FormHomeTipoPlan formTipoPlan = new FormHomeTipoPlan();
            formTipoPlan.ShowDialog();
        }

        private void toolStripTipoAtencion_Click(object sender, EventArgs e)
        {
            FormHomeTipoAtencion formTipoAtencion = new FormHomeTipoAtencion();
            formTipoAtencion.ShowDialog();
        }

        private void NuevaAtencion_Click(object sender, EventArgs e)
        {
            FormAtencion formAtencion = new FormAtencion();
            formAtencion.ShowDialog();
        }

        private void odontologosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHomeOdontologo formOdontologo = new FormHomeOdontologo();
            formOdontologo.ShowDialog();
        }

        private void tutoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHomeTutor formTutor = new FormHomeTutor();
            formTutor.ShowDialog();
        }

        private void atencionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHomeAtencion formAtencion = new FormHomeAtencion();
            formAtencion.ShowDialog();
        }

        private async void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                var request = new ReportePacientesRequestDTO
                {
                    IncluirSoloConOS = false
                };

                var pdfBytes = await ReporteApiClient.GenerarReportePacientesAsync(request);

                using (var saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "PDF Files|*.pdf";
                    saveDialog.FileName = $"Pacientes_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllBytes(saveDialog.FileName, pdfBytes);
                        MessageBox.Show("Reporte generado exitosamente", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Abrir PDF
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = saveDialog.FileName,
                            UseShellExecute = true
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar reporte: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void atencionesPorOdontólogoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private async void reporteAtencionesTSMI_Click(object sender, EventArgs e)
        {
            try
            {
                var request = new ReporteAtencionesHorarioRequestDTO
                {
                };

                var pdfBytes = await ReporteApiClient.GenerarReporteAtencionesHorarioAsync(request);

                using (var saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "PDF Files|*.pdf";
                    saveDialog.FileName = $"Atenciones_Horario_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                    saveDialog.Title = "Guardar Reporte de Atenciones por Horario";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllBytes(saveDialog.FileName, pdfBytes);
                        MessageBox.Show("Reporte de atenciones por horario generado exitosamente", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = saveDialog.FileName,
                            UseShellExecute = true
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar reporte de atenciones por horario: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
