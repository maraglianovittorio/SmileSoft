using SmileSoft.Dominio;
using System.Net.Http.Json;
using SmileSoft.API.Clients;
using DTO;
using System.Threading.Tasks;

namespace SmileSoft.UI.Desktop
{
    public partial class FormOdontologo : Form
    {
        public FormOdontologo()
        {
            InitializeComponent();
            this.Text = "SmileSoft - Agregar Odontólogo";
            btnEditarOdontologo.Visible = false;
            ConfigurarEstilos();
            ConfigurarResponsive();
        }

        public FormOdontologo(int idOdontologo)
        {
            InitializeComponent();
            this.Text = "SmileSoft - Editar Odontólogo";
            btnAgregarOdontologo.Visible = false;
            btnEditarOdontologo.Tag = idOdontologo; // Guardar el ID del odontólogo en el botón
            ConfigurarEstilos();
            ConfigurarResponsive();
            PopularFormOdontologo(idOdontologo);
        }

        private void ConfigurarEstilos()
        {
            // Estilo verde moderno
            this.BackColor = Color.FromArgb(245, 255, 250); // MintCream
            this.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(650, 500); // Tamaño mínimo

            // Estilo para labels
            foreach (Control control in this.Controls)
            {
                if (control is Label lbl)
                {
                    lbl.ForeColor = Color.FromArgb(34, 139, 34); // ForestGreen
                    lbl.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

                    // Marcar campos obligatorios con asterisco
                    if (lbl.Name == "lblNombreOdontologo" ||
                        lbl.Name == "lblApellidoOdontologo" ||
                        lbl.Name == "lblNroMatricula" ||
                        lbl.Name == "lblDni" ||
                        lbl.Name == "lblDireccion" ||
                        lbl.Name == "lblTelefono" ||
                        lbl.Name == "lblEmail")
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
            this.Resize += formOdontologo_Resize;
        }

        private void formOdontologo_Resize(object sender, EventArgs e)
        {
            // Centrar todos los controles manteniendo sus posiciones relativas
            int centerX = this.ClientSize.Width / 2;
            int centerY = this.ClientSize.Height / 2;

            // Calcular offset desde el centro original (650x500)
            int originalCenterX = 650 / 2;
            int originalCenterY = 500 / 2;

            foreach (Control control in this.Controls)
            {
                // Obtener posición original relativa al centro
                int originalX = 0, originalY = 0;

                if (control == lblNombreOdontologo) { originalX = 119; originalY = 40; }
                else if (control == txtNombre) { originalX = 245; originalY = 40; }
                else if (control == lblApellidoOdontologo) { originalX = 119; originalY = 70; }
                else if (control == txtApellido) { originalX = 245; originalY = 70; }
                else if (control == lblNroMatricula) { originalX = 119; originalY = 100; }
                else if (control == txtNroMatricula) { originalX = 245; originalY = 100; }
                else if (control == lblEmail) { originalX = 119; originalY = 130; }
                else if (control == txtEmail) { originalX = 245; originalY = 130; }
                //else if (control == lblUsername) { originalX = 119; originalY = 160; }
                //else if (control == txtUsername) { originalX = 245; originalY = 160; }
                //else if (control == lblPassword) { originalX = 119; originalY = 190; }
                //else if (control == txtPassword) { originalX = 245; originalY = 190; }
                else if (control == btnAgregarOdontologo) { originalX = 245; originalY = 240; }
                else if (control == btnEditarOdontologo) { originalX = 345; originalY = 240; }

                // Calcular nueva posición manteniendo la proporción
                int offsetX = originalX - originalCenterX;
                int offsetY = originalY - originalCenterY;

                control.Location = new Point(centerX + offsetX, centerY + offsetY);
            }
        }

        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtNroMatricula.Clear();
            txtEmail.Clear();
            //txtUsername.Clear();
            //txtPassword.Clear();

            // Enfocar el primer campo
            txtNombre.Focus();
        }

        private bool ValidarCampos()
        {
            var errores = new List<string>();

            // Validar campos obligatorios
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
                errores.Add("• El nombre es obligatorio");

            if (string.IsNullOrWhiteSpace(txtApellido.Text))
                errores.Add("• El apellido es obligatorio");

            if (string.IsNullOrWhiteSpace(txtNroMatricula.Text))
                errores.Add("• El número de matrícula es obligatorio");

            //if (string.IsNullOrWhiteSpace(txtUsername.Text))
            //    errores.Add("• El nombre de usuario es obligatorio");

            // Validar formato de email si se proporciona
            if (!string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                try
                {
                    var email = new System.Net.Mail.MailAddress(txtEmail.Text);
                }
                catch
                {
                    errores.Add("• El formato del email no es válido");
                }
            }

            //// Validar password solo en modo agregar
            //if (btnAgregarOdontologo.Visible && string.IsNullOrWhiteSpace(txtPassword.Text))
            //{
            //    errores.Add("• La contraseña es obligatoria");
            //}

            // Mostrar errores si los hay
            if (errores.Count > 0)
            {
                string mensaje = "Por favor corrija los siguientes errores:\n\n" + string.Join("\n", errores);
                MessageBox.Show(mensaje, "Errores de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private async Task PopularFormOdontologo(int idOdontologo)
        {
            LimpiarFormulario();
            try
            {
                var odontologoResponse = await OdontologoApiClient.GetOneAsync(idOdontologo);
                if (odontologoResponse != null)
                {
                    txtNombre.Text = odontologoResponse.Nombre;
                    txtApellido.Text = odontologoResponse.Apellido;
                    txtNroMatricula.Text = odontologoResponse.NroMatricula;
                    txtEmail.Text = odontologoResponse.Email;
                    txtTelefono.Text = odontologoResponse.Telefono;
                    txtDireccion.Text = odontologoResponse.Direccion;
                    txtDni.Text = odontologoResponse.NroDni;
                    dtpFechaNacimiento.Value = odontologoResponse.FechaNacimiento;

                    //txtUsername.Text = odontologoResponse.Username;
                }
                else
                {
                    MessageBox.Show($"Error al cargar los datos del odontólogo. Código: {MessageBoxIcon.Error}",
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
                OdontologoDTO odontologo = new OdontologoDTO
                {
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(),
                    NroMatricula = txtNroMatricula.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Direccion = txtDireccion.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    NroDni = txtDni.Text.Trim(),
                    FechaNacimiento = dtpFechaNacimiento.Value,
                    //Username = txtUsername.Text.Trim(),
                    //Password = txtPassword.Text.Trim()
                };

                btnAgregarOdontologo.Text = "Enviando...";
                btnAgregarOdontologo.Enabled = false;

                await OdontologoApiClient.CreateAsync(odontologo);
                MessageBox.Show("Odontólogo creado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; // Indicar que se creó un odontólogo
                this.Close(); // Cerrar el formulario después del éxito
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnAgregarOdontologo.Text = "Enviar";
                btnAgregarOdontologo.Enabled = true;
            }
        }

        private async void btnEditarOdontologo_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                return;
            }

            try
            {
                if (btnEditarOdontologo.Tag is not int id)
                {
                    MessageBox.Show("Error al obtener el ID del odontólogo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                OdontologoDTO odontologo = new OdontologoDTO
                {
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(),
                    NroMatricula = txtNroMatricula.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Direccion = txtDireccion.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    NroDni = txtDni.Text.Trim(),
                    FechaNacimiento = dtpFechaNacimiento.Value,
                    //Username = txtUsername.Text.Trim(),
                    //Password = string.IsNullOrWhiteSpace(txtPassword.Text) ? "" : txtPassword.Text.Trim()
                };

                btnEditarOdontologo.Text = "Enviando...";
                btnEditarOdontologo.Enabled = false;

                await OdontologoApiClient.UpdateAsync(odontologo, (int)btnEditarOdontologo.Tag);
                MessageBox.Show("Odontólogo editado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; // Indicar que se editó un odontólogo
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
                btnEditarOdontologo.Text = "Enviar";
                btnEditarOdontologo.Enabled = true;
            }
        }

        private void lblDni_Click(object sender, EventArgs e)
        {

        }
    }
}
