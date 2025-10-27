using SmileSoft.DTO;
using SmileSoft.API.Clients;
using System.Data;
using SmileSoft.WindowsForms;



namespace SmileSoft.UI.Desktop
{
    public partial class FormHomeUsuario : FormBaseHome
    {
        private static readonly HttpClient httpClient = new HttpClient()
        {
            BaseAddress = new Uri("http://localhost:54145")

        };
        private List<UsuarioDTO> usuarios = new();
        public FormHomeUsuario()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            ConfigurarEstilos();
            ConfigurarLayoutResponsivo(dgvFormUsuario, txtBuscarUsuario, lupaPng, btnAgregarUsuario, btnEditarUsuario, btnBorrarUsuario, BtnVolver);
            //ConfigurarResponsive();
        }

        private void ConfigurarEstilos()
        {
            // Estilo principal
            this.BackColor = Color.FromArgb(240, 248, 255); // AliceBlue
            this.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            this.Text = "SmileSoft - Página Principal";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(800, 450); // Tamaño mínimo

            // Estilo para botones
            foreach (Control control in this.Controls)
            {
                if (control is Button btn)
                {
                    btnAgregarUsuario.BackColor = Color.FromArgb(70, 130, 180); // SteelBlue
                    btnBorrarUsuario.BackColor = Color.FromArgb(220, 20, 60); // Crimson
                    btnEditarUsuario.BackColor = Color.FromArgb(34, 139, 34); // ForestGreen
                    btn.ForeColor = Color.White;
                    btn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btnAgregarUsuario.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 149, 237); // CornflowerBlue
                    btnBorrarUsuario.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 99, 71); // Tomato
                    btnEditarUsuario.FlatAppearance.MouseOverBackColor = Color.FromArgb(144, 238, 144); // LightGreen
                    btn.Cursor = Cursors.Hand;
                }
            }
        }

        private void ConfigurarResponsive()
        {
            // Hacer que el formulario sea redimensionable
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;

            // Configurar anclajes para que los botones se mantengan centrados

            // Manejar el evento de redimensionado para centrar los botones
            this.Resize += FormHomePage_Resize;
        }

        private void FormHomePage_Resize(object sender, EventArgs e)
        {
            // Centrar los botones horizontalmente y verticalmente
            int buttonWidth = 112;
            int buttonHeight = 47;
            int spacing = 60; // Espacio entre botones
            int totalWidth = (buttonWidth * 4) + (spacing * 3);

            int startX = (this.ClientSize.Width - totalWidth) / 2;
            int centerY = this.ClientSize.Height / 2;
        }

        private async Task ObtenerDatos()
        {
            try
            {
                var usuarioResponse = await UsuarioApiClient.GetAllAsync();
                if (usuarioResponse != null && usuarioResponse.Count() > 0 )
                {
                    dgvFormUsuario.DataSource = usuarioResponse;
                    usuarios = (List<UsuarioDTO>)usuarioResponse;
                    ConfiguraDgv();
                }
                else
                {
                    dgvFormUsuario.DataSource = null;
                    usuarios.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los usuarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void ConfiguraDgv()
        {
            dgvFormUsuario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvFormUsuario.Columns["Id"].Visible = false;
        }

        private async void FormHomePage_Load(object sender, EventArgs e)
        {
            btnBorrarUsuario.Enabled = false;
            btnEditarUsuario.Enabled = false;

            await ObtenerDatos();
        }

        private void txtBuscarUsuario_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscarUsuario.Text.ToLower();
            if (!string.IsNullOrWhiteSpace(filtro))
            {
                var filtrados = usuarios.Where(u => u.Username.ToLower().Contains(filtro) ).ToList();
                dgvFormUsuario.DataSource = filtrados;
            }
            else
            {
                dgvFormUsuario.DataSource = usuarios;

            }
            ConfiguraDgv();

        }

        private async void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            FormUsuario formUsuario = new FormUsuario();
            formUsuario.ShowDialog();
            await ObtenerDatos();
        }



        private void dgvFormHome_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvFormUsuario.SelectedRows.Count > 0)
            {
                btnEditarUsuario.Enabled = true;
                btnBorrarUsuario.Enabled = true;
            }
            else
            {
                btnEditarUsuario.Enabled = false;
                btnBorrarUsuario.Enabled = false;

            }
        }

        private async void BtnEditarUsuario_Click(object sender, EventArgs e)
        {
            if (dgvFormUsuario.SelectedRows.Count > 0)
            {
                var usuarioSeleccionado = new UsuarioUpdateDTO
                {
                    Id = (dgvFormUsuario.SelectedRows[0].DataBoundItem as UsuarioDTO).Id,
                    Username = (dgvFormUsuario.SelectedRows[0].DataBoundItem as UsuarioDTO).Username,
                    Rol = (dgvFormUsuario.SelectedRows[0].DataBoundItem as UsuarioDTO).Rol
                };
                if (usuarioSeleccionado != null)
                {
                    FormUsuario formUsuario = new FormUsuario(usuarioSeleccionado.Id);
                    formUsuario.ShowDialog();   
                    await ObtenerDatos();
                }
            }
        }

        private async void BtnBorrarUsuario_Click(object sender, EventArgs e)
        {
            if (dgvFormUsuario.SelectedRows.Count > 0)
            {
                var usuarioSeleccionado = dgvFormUsuario.SelectedRows[0].DataBoundItem as UsuarioDTO;
                if (usuarioSeleccionado != null)
                {
                    var confirmResult = MessageBox.Show("¿Estás seguro de que deseas eliminar este usuario?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirmResult == DialogResult.Yes)
                    {
                        await UsuarioApiClient.DeleteAsync(usuarioSeleccionado.Id);
                        MessageBox.Show("Usuario eliminado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await ObtenerDatos();
                    }
                }
            }
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
