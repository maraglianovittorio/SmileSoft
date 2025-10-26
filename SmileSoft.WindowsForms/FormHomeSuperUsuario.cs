using SmileSoft.WindowsForms;
using SmileSoft.API.Auth.WindowsForms;

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
            // Estilo principal - Tema azul elegante
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
    }
}
