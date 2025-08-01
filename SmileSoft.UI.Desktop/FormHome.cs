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
    public partial class FormHome : Form
    {
        public FormHome()
        {
            InitializeComponent();
            ConfigurarEstilos();
        }
        private void ConfigurarEstilos()
        {
            // Estilo verde moderno para POST
            this.BackColor = Color.FromArgb(245, 255, 250); // MintCream
            this.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(925, 558); // Tamaño mínimo
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
    }
}
