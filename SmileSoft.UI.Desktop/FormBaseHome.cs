using System.Windows.Forms;
using System.Drawing;

namespace SmileSoft.UI.Desktop
{
    public class FormBaseHome : Form
    {
        public FormBaseHome()
        {
            // Configuraciones de ventana por defecto para todos los formularios "Home"
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = new Size(850, 500);
            this.BackColor = Color.FromArgb(240, 248, 255); // AliceBlue
            this.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
        }

        /// <summary>
        /// Configura el layout responsivo para un formulario Home estándar.
        /// </summary>
        /// <param name="dgv">El DataGridView principal del formulario.</param>
        /// <param name="txtBusqueda">El TextBox para la búsqueda.</param>
        /// <param name="btnAgregar">El botón para agregar nuevos registros.</param>
        /// <param name="btnEditar">El botón para editar.</param>
        /// <param name="btnBorrar">El botón para borrar.</param>
        /// <param name="btnVolver">El botón para volver o cerrar.</param>
        protected void ConfigurarLayoutResponsivo(DataGridView dgv, TextBox txtBusqueda, Button btnAgregar, Button btnEditar, Button btnBorrar, Button btnVolver)
        {
            // --- Márgenes y espaciado ---
            int margen = 20;
            int espacioBotones = 10;

            // --- Panel Superior (Búsqueda y Agregar) ---
            txtBusqueda.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBusqueda.Location = new Point(margen, margen);
            
            btnAgregar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            
            // Ajustar ancho del buscador para que no se solape con el botón Agregar
            txtBusqueda.Width = this.ClientSize.Width - btnAgregar.Width - (margen * 3);
            btnAgregar.Location = new Point(txtBusqueda.Right + espacioBotones, margen);

            // --- DataGridView (Centro) ---
            dgv.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgv.Location = new Point(margen, txtBusqueda.Bottom + margen);
            dgv.Size = new Size(
                this.ClientSize.Width - (margen * 2),
                this.ClientSize.Height - txtBusqueda.Height - btnVolver.Height - (margen * 4)
            );

            // --- Panel Inferior (Botones de Acción) ---
            btnVolver.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnVolver.Location = new Point(margen, this.ClientSize.Height - btnVolver.Height - margen);

            btnBorrar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnBorrar.Location = new Point(this.ClientSize.Width - btnBorrar.Width - margen, this.ClientSize.Height - btnBorrar.Height - margen);

            btnEditar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnEditar.Location = new Point(btnBorrar.Left - btnEditar.Width - espacioBotones, this.ClientSize.Height - btnEditar.Height - margen);
        }
    }
}