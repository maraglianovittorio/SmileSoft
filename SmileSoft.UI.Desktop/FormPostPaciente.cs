using SmileSoft.Dominio;
using System.Net.Http.Json;
using DTO;
namespace SmileSoft.UI.Desktop
{
    public partial class FormPostPaciente : Form
    {
        private static readonly HttpClient httpClient = new HttpClient()
        {
            BaseAddress = new Uri("http://localhost:5279")

        };
        public FormPostPaciente()
        {
            InitializeComponent();
            ConfigurarEstilos();
            ConfigurarResponsive();
        }

        private void ConfigurarEstilos()
        {
            // Estilo verde moderno para POST
            this.BackColor = Color.FromArgb(245, 255, 250); // MintCream
            this.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            this.Text = "SmileSoft - Agregar Paciente";
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
                    if (lbl.Name == "lblNombrePaciente" || 
                        lbl.Name == "lblApellidoPaciente" || 
                        lbl.Name == "lblDNIPaciente" || 
                        lbl.Name == "lblNroHC")
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
            this.Resize += FormPostPaciente_Resize;
        }

        private void FormPostPaciente_Resize(object sender, EventArgs e)
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
                
                if (control == lblNombrePaciente) { originalX = 255; originalY = 65; }
                else if (control == txtNombre) { originalX = 435; originalY = 65; }
                else if (control == lblApellidoPaciente) { originalX = 255; originalY = 115; }
                else if (control == txtApellido) { originalX = 435; originalY = 109; }
                else if (control == lblDNIPaciente) { originalX = 255; originalY = 161; }
                else if (control == txtDNI) { originalX = 435; originalY = 155; }
                else if (control == lblEmail) { originalX = 255; originalY = 209; }
                else if (control == txtEmail) { originalX = 435; originalY = 203; }
                else if (control == lblDireccionPaciente) { originalX = 255; originalY = 249; }
                else if (control == txtDireccion) { originalX = 435; originalY = 243; }
                else if (control == lblFechaNacimiento) { originalX = 255; originalY = 290; }
                else if (control == dtpFechaNacimiento) { originalX = 437; originalY = 289; }
                else if (control == lblTelefono) { originalX = 255; originalY = 337; }
                else if (control == txtTelefono) { originalX = 435; originalY = 337; }
                else if (control == lblNroAfiliado) { originalX = 255; originalY = 380; }
                else if (control == txtNroAfiliado) { originalX = 435; originalY = 380; }
                else if (control == lblNroHC) { originalX = 255; originalY = 423; }
                else if (control == txtNroHC) { originalX = 435; originalY = 423; }
                else if (control == btnEnviar) { originalX = 385; originalY = 477; }

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
            txtDNI.Clear();
            txtEmail.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtNroAfiliado.Clear();
            txtNroHC.Clear();
            dtpFechaNacimiento.Value = DateTime.Now;
            
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

            if (string.IsNullOrWhiteSpace(txtDNI.Text))
                errores.Add("• El DNI es obligatorio");

            if (string.IsNullOrWhiteSpace(txtNroHC.Text))
                errores.Add("• El número de historia clínica es obligatorio");

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

            // Validar fecha de nacimiento
            if (dtpFechaNacimiento.Value > DateTime.Now)
                errores.Add("• La fecha de nacimiento no puede ser futura");

            if (dtpFechaNacimiento.Value < DateTime.Now.AddYears(-120))
                errores.Add("• La fecha de nacimiento no es válida");

            // Mostrar errores si los hay
            if (errores.Count > 0)
            {
                string mensaje = "Por favor corrija los siguientes errores:\n\n" + string.Join("\n", errores);
                MessageBox.Show(mensaje, "Errores de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            // Validar campos antes de enviar
            if (!ValidarCampos())
            {
                return;
            }

            try
            {
                PacienteDTO paciente = new PacienteDTO
                {
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(),
                    FechaNacimiento = dtpFechaNacimiento.Value,
                    Direccion = txtDireccion.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    NroDni = txtDNI.Text.Trim(),
                    NroHC = txtNroHC.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    NroAfiliado = txtNroAfiliado.Text.Trim()
                };

                btnEnviar.Text = "Enviando...";
                btnEnviar.Enabled = false;

                var response = httpClient.PostAsJsonAsync("/pacientes", paciente).Result;
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Paciente agregado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK; // Indicar que se agregó un paciente
                    this.Close(); // Cerrar el formulario después del éxito
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
                {
                    var errorContent = response.Content.ReadAsStringAsync().Result;
                    MessageBox.Show("Ya existe un paciente con ese número de historia clínica. Por favor use un número diferente.", 
                        "Historia clínica duplicada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show($"Error al agregar el paciente. Código: {response.StatusCode}", 
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnEnviar.Text = "Enviar";
                btnEnviar.Enabled = true;
            }
        }
    }
}
