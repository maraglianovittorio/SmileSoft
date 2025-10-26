using SmileSoft.Dominio;
using System.Net.Http.Json;
using SmileSoft.API.Clients;
using DTO;
using System.Threading.Tasks;
namespace SmileSoft.UI.Desktop
{
    public partial class FormUsuario : Form
    {


        public FormUsuario()
        {

            InitializeComponent();
            this.Text = "SmileSoft - Agregar Usuario";
            btnEditarUsuario.Visible = false;
            ConfigurarEstilos();
            ConfigurarResponsive();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }
        public FormUsuario(int idUsuario)
        {

            InitializeComponent();
            this.Text = "SmileSoft - Editar Usuario";
            btnGuardarUsuario.Visible = false;
            btnEditarUsuario.Tag = idUsuario; // Guardar el ID del usuario en el botón
            ConfigurarEstilos();
            ConfigurarResponsive();
            PopularFormUsuario(idUsuario);
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }

        private void ConfigurarEstilos()
        {
            // Estilo verde moderno para POST
            this.BackColor = Color.FromArgb(245, 255, 250); // MintCream
            this.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(925, 558); // Tamaño mínimo

            // Estilo para labels
            foreach (Control control in this.Controls)
            {
                if (control is Label lbl)
                {
                    lbl.ForeColor = Color.FromArgb(34, 139, 34); // ForestGreen
                    lbl.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

                    // Marcar campos obligatorios con asterisco
                    if (lbl.Name == "lblUsername" ||
                        lbl.Name == "lblPassword" ||
                        lbl.Name == "lblRol")
                    {
                        lbl.Text = lbl.Text.TrimEnd(':') + " *";
                        lbl.ForeColor = Color.FromArgb(220, 20, 60); // Crimson para campos obligatorios
                    }
                }
                else if (control is TextBox txt)
                {
                    txt.BackColor = Color.White;
                    txt.BorderStyle = BorderStyle.FixedSingle;
                    txt.Font = new Font("Segoe UI", 9F);
                }
                else if (control is Button btn)
                {
                    btn.BackColor = Color.FromArgb(60, 179, 113); // MediumSeaGreen
                    btn.ForeColor = Color.White;
                    btn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(46, 125, 50); // Darker green
                    btn.Cursor = Cursors.Hand;
                }
                else if (control is DateTimePicker dtp)
                {
                    dtp.Font = new Font("Segoe UI", 9F);
                }
            }
        }

        private void ConfigurarResponsive()
        {
            // Hacer que el formulario sea redimensionable
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;

            // Configurar anclajes para mantener la estructura centrada
            foreach (Control control in this.Controls)
            {
                control.Anchor = AnchorStyles.None;
            }

            // Manejar el evento de redimensionado para mantener todo centrado
            this.Resize += formUsuario_Resize;
        }

        private void formUsuario_Resize(object sender, EventArgs e)
        {
            // Centrar todos los controles manteniendo sus posiciones relativas
            int centerX = this.ClientSize.Width / 2;
            int centerY = this.ClientSize.Height / 2;

            // Calcular offset desde el centro original (925x558)
            int originalCenterX = 925 / 2;
            int originalCenterY = 558 / 2;

            foreach (Control control in this.Controls)
            {
                // Obtener posición original relativa al centro
                int originalX = 0, originalY = 0;

                if (control == lblUsername) { originalX = 255; originalY = 65; }
                else if (control == txtUsername) { originalX = 435; originalY = 65; }
                else if (control == lblPassword) { originalX = 255; originalY = 115; }
                else if (control == txtPassword) { originalX = 435; originalY = 109; }
                else if (control == lblRol) { originalX = 255; originalY = 161; }
                else if (control == txtRol) { originalX = 435; originalY = 155; }
                else if (control == btnGuardarUsuario) { originalX = 385; originalY = 477; }

                // Calcular nueva posición manteniendo la proporción
                int offsetX = originalX - originalCenterX;
                int offsetY = originalY - originalCenterY;

                control.Location = new Point(centerX + offsetX, centerY + offsetY);
            }
        }

        private void LimpiarFormulario()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            cbRol.SelectedIndex = -1;

            // Enfocar el primer campo
            txtUsername.Focus();
        }

        private bool ValidarCampos()
        {
            var errores = new List<string>();

            // Validar campos obligatorios
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
                errores.Add("• El username es obligatorio");

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
                errores.Add("• El password es obligatorio");

            if (string.IsNullOrWhiteSpace(cbRol.Text))
                errores.Add("• El rol es obligatorio");

            //if (cbRol.Text.ToUpper() != "ADMIN" && cbRol.Text.ToUpper() != "ODONTOLOGO" && cbRol.Text.ToUpper() != "SECRETARIO")
            //    errores.Add("• El rol debe ser 'Admin', 'Odontologo', o 'Secretario'");
            // Mostrar errores si los hay
            if (errores.Count > 0)
            {
                string mensaje = "Por favor corrija los siguientes errores:\n\n" + string.Join("\n", errores);
                MessageBox.Show(mensaje, "Errores de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private async Task PopularFormUsuario(int idUsuario)
        {

            LimpiarFormulario();
            try
            {
                var usuarioResponse = await UsuarioApiClient.GetOneAsync(idUsuario);
                if (usuarioResponse != null)
                {
                    txtUsername.Text = usuarioResponse.Username;
                    txtPassword.Text = usuarioResponse.PasswordHash;
                    cbRol.Text = usuarioResponse.Rol;


                }
                else
                {
                    MessageBox.Show($"Error al cargar los datos del usuario. Código: {MessageBoxIcon.Error}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void btnEnviar_Click(object sender, EventArgs e)
        {
            // Validar campos antes de enviar
            if (!ValidarCampos())
            {
                return;
            }

            try
            {
                UsuarioCreateDTO user = new UsuarioCreateDTO
                {
                    Username = txtUsername.Text.Trim(),
                    Password = txtPassword.Text.Trim(),
                    Rol = cbRol.Text.Trim(),
                };

                btnGuardarUsuario.Text = "Enviando...";
                btnGuardarUsuario.Enabled = false;

                await UsuarioApiClient.CreateAsync(user);
                MessageBox.Show("Usuario creado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; // Indicar que se creo un usuario
                this.Close(); // Cerrar el formulario después del éxito


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnGuardarUsuario.Text = "Enviar";
                btnGuardarUsuario.Enabled = true;
            }
        }

        private async void btnEditarPaciente_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                return;
            }

            try
            {
                if (btnEditarUsuario.Tag is not int id)
                {
                    MessageBox.Show("Error al obtener el ID del usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                UsuarioUpdateDTO user = new UsuarioUpdateDTO
                {
                    Username = txtUsername.Text.Trim(),
                    Password = txtPassword.Text.Trim(),
                    Rol = cbRol.Text.Trim(),
                };

                btnEditarUsuario.Text = "Enviando...";
                btnEditarUsuario.Enabled = false;

                await UsuarioApiClient.UpdateAsync(user, (int)btnEditarUsuario.Tag);
                MessageBox.Show("Usuario editado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; // Indicar que se editó un usuario 
                this.Close(); // Cerrar el formulario después del éxito
            }
            catch (HttpRequestException httpEx)
            {
                MessageBox.Show($"Error de conexión: {httpEx.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnEditarUsuario.Text = "Enviar";
                btnEditarUsuario.Enabled = true;
            }

        }

    }
}

                      
