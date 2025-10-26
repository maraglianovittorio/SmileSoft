using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmileSoft.WindowsForms
{
    public partial class FormBaseHome : Form
    {
        public FormBaseHome()
        {
            InitializeComponent();
        }

        private void FormBaseHome_Load(object sender, System.EventArgs e)
        {

        }



        protected void ConfigurarLayoutResponsivo(DataGridView dgv, TextBox txtBusqueda, PictureBox lupa, Button btnAgregar, Button btnEditar, Button btnBorrar, Button btnVolver)
        {
            ConfigurarLayoutResponsivo(dgv, txtBusqueda, btnAgregar, btnEditar, btnBorrar, btnVolver);
            btnAgregar.Text = "Agregar";
            btnEditar.Text = "Editar";
            btnBorrar.Text = "Borrar";
            if (lupa != null)
            {
                int margen = 15;
                int espacioBotones = 3;

                lupa.Anchor = AnchorStyles.Top | AnchorStyles.Right;

                txtBusqueda.Width = this.ClientSize.Width - btnAgregar.Width - lupa.Width - (margen * 3) - (espacioBotones * 2);

                // Reposicionar el botón de agregar y la lupa en base al nuevo ancho del buscador
                btnAgregar.Location = new Point(txtBusqueda.Right + lupa.Width + (espacioBotones * 2), margen);
                lupa.Location = new Point(txtBusqueda.Right + espacioBotones, txtBusqueda.Top + (txtBusqueda.Height - lupa.Height) / 2);
            }
        }

        protected void ConfigurarLayoutResponsivo(DataGridView dgv, TextBox txtBusqueda, Button btnAgregar, Button btnEditar, Button btnBorrar, Button btnVolver)
        {
            var buttons = new[] { btnAgregar, btnEditar, btnBorrar, btnVolver };
            foreach (var btn in buttons)
            {
                btn.Height = 38; 
                btn.AutoSize = true; 
                btn.AutoSizeMode = AutoSizeMode.GrowAndShrink; 
                btn.Padding = new Padding(12, 0, 12, 0); 
                btn.TextAlign = ContentAlignment.MiddleCenter;
            }

            int margen = 15;
            int espacioBotones = 8;

            txtBusqueda.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBusqueda.Location = new Point(margen, margen);

            btnAgregar.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            txtBusqueda.Width = this.ClientSize.Width - btnAgregar.Width - (margen * 2) - espacioBotones;
            btnAgregar.Location = new Point(txtBusqueda.Right + espacioBotones, margen);

            dgv.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgv.Location = new Point(margen, txtBusqueda.Bottom + margen);
            dgv.Size = new Size(
                this.ClientSize.Width - (margen * 2),
                this.ClientSize.Height - txtBusqueda.Height - btnVolver.Height - (margen * 4)
            );

            btnVolver.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnVolver.Location = new Point(margen, this.ClientSize.Height - btnVolver.Height - margen);

            btnBorrar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnBorrar.Location = new Point(this.ClientSize.Width - btnBorrar.Width - margen, this.ClientSize.Height - btnBorrar.Height - margen);

            btnEditar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnEditar.Location = new Point(btnBorrar.Left - btnEditar.Width - espacioBotones, this.ClientSize.Height - btnEditar.Height - margen);
        }

        private void FormBaseHome_Load_1(object sender, EventArgs e)
        {
.
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = new Size(850, 500);
            this.BackColor = Color.FromArgb(240, 248, 255); // AliceBlue
            this.Font = new Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular);
        }
    }
}
