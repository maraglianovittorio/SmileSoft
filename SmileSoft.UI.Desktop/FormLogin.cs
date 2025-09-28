using DTO;
using SmileSoft.API.Clients;
using SmileSoft.UI.Desktop;
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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            ConfigurarEstilos();
        }
        private bool passwordVisible = false;


        private void ConfigurarEstilos()
        {
            // Estilo principal - Tema azul elegante
            this.BackColor = Color.FromArgb(240, 248, 255); // AliceBlue
            this.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            this.Text = "SmileSoft - Iniciar Sesión";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Estilo para botones (verificar que existen primero)
            if (btnLogin != null)
            {
                btnLogin.BackColor = Color.FromArgb(70, 130, 180); // SteelBlue
                btnLogin.ForeColor = Color.White;
                btnLogin.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                btnLogin.FlatStyle = FlatStyle.Flat;
                btnLogin.FlatAppearance.BorderSize = 0;
                btnLogin.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 149, 237); // CornflowerBlue
                btnLogin.Cursor = Cursors.Hand;
            }

            if (btnCancelar != null)
            {
                btnCancelar.BackColor = Color.FromArgb(220, 20, 60); // Crimson
                btnCancelar.ForeColor = Color.White;
                btnCancelar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                btnCancelar.FlatStyle = FlatStyle.Flat;
                btnCancelar.FlatAppearance.BorderSize = 0;
                btnCancelar.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 99, 71); // Tomato
                btnCancelar.Cursor = Cursors.Hand;
            }

            // Estilo para labels
            if (lblUsuario != null)
            {
                lblUsuario.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                lblUsuario.ForeColor = Color.FromArgb(25, 25, 112); // MidnightBlue
            }

            if (lblPassword != null)
            {
                lblPassword.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                lblPassword.ForeColor = Color.FromArgb(25, 25, 112); // MidnightBlue
            }

            if (lblTitulo != null)
            {
                lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
                lblTitulo.ForeColor = Color.FromArgb(25, 25, 112); // MidnightBlue
            }

            // Estilo para textboxes
            if (txtUsuario != null)
                txtUsuario.Font = new Font("Segoe UI", 11F);

            if (txtPassword != null)
                txtPassword.Font = new Font("Segoe UI", 11F);
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            // Validaciones básicas
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                MessageBox.Show("Por favor ingrese el nombre de usuario.", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuario.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Por favor ingrese la contraseña.", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            btnLogin.Enabled = false;
            btnCancelar.Enabled = false;
            btnLogin.Text = "Autenticando...";

            try
            {
                var loginResponse = await AuthApiClient.Login(txtUsuario.Text, txtPassword.Text);

                if (loginResponse != null && loginResponse.IsSuccess)
                {
                    MessageBox.Show($"Bienvenido {loginResponse.Username}", "Login Exitoso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    MostrarFormularioSegunRol(loginResponse.Rol, loginResponse.Username);
                    this.Hide();
                }
                else if (txtUsuario.Text=="Admin" && txtPassword.Text=="admin")
                {
                    // Credenciales de demo
                    MessageBox.Show("Bienvenido Admin (Demo)", "Login Exitoso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    MostrarFormularioSegunRol("ADMIN", "Admin (Demo)");
                    this.Hide();
                }
                else
                {
                    // Credenciales inválidas
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Error de autenticación",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                    txtUsuario.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error durante la autenticación: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtUsuario.Focus();
            }
            finally
            {
                // Rehabilitar botones
                btnLogin.Enabled = true;
                btnCancelar.Enabled = true;
                btnLogin.Text = "Iniciar Sesión";
            }
        }

        private void MostrarFormularioSegunRol(string rol, string username)
        {
            switch (rol.ToUpper())
            {
                case "ADMIN":
                    FormHomeSuperUsuario formHomeSU = new FormHomeSuperUsuario();
                    formHomeSU.Text = $"SmileSoft - Administrador ({username})";
                    formHomeSU.ShowDialog();
                    break;

                case "ODONTOLOGO":
                    // Por el momento, odontologo tiene las mismas funciones que secretario
                    FormHomeOdontologo formHomeOdontologo = new FormHomeOdontologo();
                    formHomeOdontologo.Text = $"SmileSoft - Odontólogo ({username})";
                    formHomeOdontologo.ShowDialog();
                    break;

                case "SECRETARIO":
                    FormHomeSecretario formHomeSecretario = new FormHomeSecretario();
                    formHomeSecretario.Text = $"SmileSoft - Secretario ({username})";
                    formHomeSecretario.ShowDialog();
                    break;

                default:
                    MessageBox.Show($"Rol '{rol}' no reconocido.",
                        "Error de configuración", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Application.Exit();
        }

        private void FormLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btnCancelar_Click(sender, e);
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void ImgOjoPassword_Click(object sender, EventArgs e)
        {
            passwordVisible = !passwordVisible;
            txtPassword.PasswordChar = passwordVisible ? '\0' : '●';

        }
    }
}
