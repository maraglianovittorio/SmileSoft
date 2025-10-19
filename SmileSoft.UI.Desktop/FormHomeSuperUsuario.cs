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
    public partial class FormHomeSuperUsuario : Form
    {
        public FormHomeSuperUsuario()
        {
            InitializeComponent();
            ConfigurarEstilos();
            //btnMenuAlt.Visible = false; // Lo ocultamos ya que no tiene funcionalidad, es una prueba para entrega 3
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
                    btnPacientes.BackColor = Color.FromArgb(70, 130, 180); // SteelBlue
                    btnObraSocial.BackColor = Color.FromArgb(70, 130, 180); // Crimson
                    btnUsuarios.BackColor = Color.FromArgb(70, 130, 180); // MediumSeaGreen
                    btnTipoPlan.BackColor = Color.FromArgb(70, 130, 180); // MediumSeaGreen
                    btnTipoAtencion.BackColor = Color.FromArgb(70, 130, 180); // MediumSeaGreen
                    btn.ForeColor = Color.White;
                    btn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btnPacientes.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 149, 237); // CornflowerBlue
                    btnObraSocial.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 149, 237); // CornflowerBlue
                    btnUsuarios.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 149, 237); // CornflowerBlue
                    btn.Cursor = Cursors.Hand;
                }
            }
        }

        private void btnPacientes_Click(object sender, EventArgs e)
        {
            FormHomePaciente formHomePagePaciente = new FormHomePaciente();
            formHomePagePaciente.ShowDialog();
        }

        private void btnObraSocial_Click(object sender, EventArgs e)
        {
            FormHomeOS formHomeOS = new FormHomeOS();
            formHomeOS.ShowDialog();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            FormHomeUsuario formUsuario = new FormHomeUsuario();
            formUsuario.ShowDialog();
        }

        private void btnTipoPlan_Click(object sender, EventArgs e)
        {
            FormHomeTipoPlan formTipoPlan = new FormHomeTipoPlan();
            formTipoPlan.ShowDialog();
        }

        private void btnTipoAtencion_Click(object sender, EventArgs e)
        {
            FormHomeTipoAtencion formTipoAtencion = new FormHomeTipoAtencion();
            formTipoAtencion.ShowDialog();
        }

        //private void btnMenuAlt_Click(object sender, EventArgs e)
        //{
        //    FormInicioAdmin formInicioAlternativo = new FormInicioAdmin();
        //    formInicioAlternativo.ShowDialog();
        //}

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            this.Close();
            formLogin.Show();
        }

        private void toolStripPaciente_Click(object sender, EventArgs e)
        {
            FormHomePaciente formHomePaciente = new FormHomePaciente();
            formHomePaciente.ShowDialog();
        }

        private void toolStripOS_Click(object sender, EventArgs e)
        {
            FormHomeOS formHomeOS = new FormHomeOS();
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
    }
}
