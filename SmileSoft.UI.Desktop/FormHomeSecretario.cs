using SmileSoft.API.Clients;
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
            FormHomeAtencion formHomeAtencion = new FormHomeAtencion();
            formHomeAtencion.ShowDialog();
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
            var turnosDelDia = await AtencionApiClient.GetByFechaRangeAsync(DateTime.Today, DateTime.Today.AddHours(23));
            dgvAtencionesDelDia.DataSource = turnosDelDia;
        }
    }
}
