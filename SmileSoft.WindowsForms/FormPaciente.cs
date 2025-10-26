using SmileSoft.Dominio;
using System.Net.Http.Json;
using SmileSoft.API.Clients;
using SmileSoft.DTO;
using System.Threading.Tasks;
namespace SmileSoft.UI.Desktop
{
    public partial class FormPaciente : Form
    {
        private int? _idTutor = null;
        private string? _nombreTutor = null;
        private string? _direccionTutor = null;
        private string? _telefonoTutor = null;
        private string? _emailTutor = null;


        public FormPaciente()
        {

            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Text = "SmileSoft - Agregar Paciente";
            btnEditarPaciente.Visible = false;
            btnAgregarTutor.Visible = false;
            lblTutor.Visible = false;
            txtTutor.Visible = false;
            ConfigurarEstilos();
            //ConfigurarResponsive();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }
        public FormPaciente(int idPaciente)
        {

            InitializeComponent();
            this.Text = "SmileSoft - Editar Paciente";
            btnAgregarPaciente.Visible = false;
            btnEditarPaciente.Tag = idPaciente; // Guardar el ID del paciente en el botón
            btnAgregarTutor.Visible = false;
            lblTutor.Visible = false;
            txtTutor.Visible = false;
            dtpFechaNacimiento.Value = DateTime.Now; // Valor por defecto a 18 años atrás
            ConfigurarEstilos();
            ConfigurarResponsive();
            PopularFormPaciente(idPaciente);
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
            this.Resize += formPaciente_Resize;
        }

        private void formPaciente_Resize(object sender, EventArgs e)
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
                else if (control == btnAgregarPaciente) { originalX = 385; originalY = 477; }

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
            //si la fecha de nacimiento es < 16 años, mando una alerta y hago dar de alta un tutor
            if (dtpFechaNacimiento.Value > DateTime.Now.AddYears(-16) && _idTutor == null)
            {
                MessageBox.Show("El paciente es menor de 16 años, debe asignarle un tutor a este paciente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnAgregarTutor.Visible = true;
                errores.Add("• El paciente es menor de 16 años, debe asignarle un tutor.");
            }


            // Mostrar errores si los hay
            if (errores.Count > 0)
            {
                string mensaje = "Por favor corrija los siguientes errores:\n\n" + string.Join("\n", errores);
                MessageBox.Show(mensaje, "Errores de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private async Task PopularFormPaciente(int idPaciente)
        {

            LimpiarFormulario();
            try
            {
                var pacienteResponse = await PacienteApiClient.GetOneAsync(idPaciente);
                if (pacienteResponse != null)
                {
                    txtNombre.Text = pacienteResponse.Nombre;
                    txtApellido.Text = pacienteResponse.Apellido;
                    dtpFechaNacimiento.Value = pacienteResponse.FechaNacimiento;
                    txtDireccion.Text = pacienteResponse.Direccion;
                    txtEmail.Text = pacienteResponse.Email;
                    txtDNI.Text = pacienteResponse.NroDni;
                    txtNroHC.Text = pacienteResponse.NroHC;
                    txtTelefono.Text = pacienteResponse.Telefono;
                    txtNroAfiliado.Text = pacienteResponse.NroAfiliado;
                    if (pacienteResponse.TipoPlanId > 0)
                    {
                        var tipoPlan = await TipoPlanApiClient.GetOneAsync(pacienteResponse.TipoPlanId.Value);
                        if (tipoPlan != null)
                        {
                            var obraSocial = await ObraSocialApiClient.GetOneAsync(tipoPlan.ObraSocialId);
                            if (obraSocial != null)
                            {
                                cmbOS.DisplayMember = "Nombre";
                                cmbOS.SelectedValue = obraSocial.Id;
                                var tiposPlan = await TipoPlanApiClient.GetByObraSocialIdAsync(tipoPlan.ObraSocialId);
                                if (tiposPlan != null && tiposPlan.Count() > 0)
                                {
                                    cmbTiposPlan.DisplayMember = "Nombre";
                                    cmbTiposPlan.ValueMember = "Id";
                                    cmbTiposPlan.Enabled = true;
                                    cmbTiposPlan.DataSource = tiposPlan;
                                    cmbTiposPlan.SelectedValue = pacienteResponse.TipoPlanId;
                                }
                            }
                        }
                    }
                    _idTutor = pacienteResponse.TutorId;
                    if (_idTutor != null)
                    {
                        lblTutor.Visible = true;
                        txtTutor.Visible = true;
                        var tutorResponse = await PersonaApiClient.GetTutorById(_idTutor.Value);
                        txtTutor.Text = $"{tutorResponse.Nombre} {tutorResponse.Apellido}";
                    }



                }
                else
                {
                    MessageBox.Show($"Error al cargar los datos del paciente. Código: {MessageBoxIcon.Error}",
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
                    NroAfiliado = txtNroAfiliado.Text.Trim(),
                    TipoPlanId = cmbTiposPlan.SelectedValue != null ? (int?)cmbTiposPlan.SelectedValue : null,
                    TutorId = _idTutor
                };

                btnAgregarPaciente.Text = "Enviando...";
                btnAgregarPaciente.Enabled = false;

                await PacienteApiClient.CreateAsync(paciente);
                MessageBox.Show("Paciente creado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; // Indicar que se creo un paciente
                this.Close(); // Cerrar el formulario después del éxito


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnAgregarPaciente.Text = "Enviar";
                btnAgregarPaciente.Enabled = true;
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
                if (btnEditarPaciente.Tag is not int id)
                {
                    MessageBox.Show("Error al obtener el ID del paciente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

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
                    NroAfiliado = txtNroAfiliado.Text.Trim(),
                    TipoPlanId = cmbTiposPlan.SelectedValue != null ? (int?)cmbTiposPlan.SelectedValue : null,
                    TutorId = _idTutor
                };

                btnEditarPaciente.Text = "Enviando...";
                btnEditarPaciente.Enabled = false;

                await PacienteApiClient.UpdateAsync(paciente, (int)btnEditarPaciente.Tag);
                MessageBox.Show("Paciente editado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; // Indicar que se editó un paciente
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
                btnEditarPaciente.Text = "Enviar";
                btnEditarPaciente.Enabled = true;
            }

        }



        private void dtpFechaNacimiento_Leave(object sender, EventArgs e)
        {
            if (dtpFechaNacimiento.Value > DateTime.Now.AddYears(-16) && string.IsNullOrWhiteSpace(txtTutor.Text))
            {
                MessageBox.Show("El paciente es menor de 16 años, debe asignarle un tutor a este paciente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnAgregarTutor.Visible = true;
            }
            // si tiene más de 16 años, oculto el botón de agregar tutor
            else
            {
                btnAgregarTutor.Visible = false;
            }
        }
        private void btnAgregarTutor_Click(object sender, EventArgs e)
        {
            //FormTutor formTutor= new FormTutor();
            //formTutor.ShowDialog();
            using (var formTutor = new FormTutor())
            {
                var result = formTutor.ShowDialog();
                if (result == DialogResult.OK)
                {
                    lblTutor.Visible = true;
                    txtTutor.Visible = true;
                    _idTutor = formTutor.IdTutorCreado;
                    _nombreTutor = formTutor.NombreTutor;
                    _direccionTutor = formTutor.DireccionTutor;
                    _telefonoTutor = formTutor.TelefonoTutor;
                    _emailTutor = formTutor.EmailTutor;
                    txtTutor.Text = _nombreTutor;
                    txtEmail.Text = _emailTutor;
                    txtTelefono.Text = _telefonoTutor;
                    txtDireccion.Text = _direccionTutor;
                    btnAgregarTutor.Visible = false;
                    txtDireccion.ReadOnly = true;
                    txtTelefono.ReadOnly = true;
                    txtEmail.ReadOnly = true;
                    txtEmail.BackColor = System.Drawing.SystemColors.Control;
                    txtTelefono.BackColor = System.Drawing.SystemColors.Control;
                    txtDireccion.BackColor = System.Drawing.SystemColors.Control;
                    MessageBox.Show("Tutor asignado correctamente. Sus datos de contacto han sido agregados al paciente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se asignó ningún tutor.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private async void FormPaciente_Load(object sender, EventArgs e)
        {
            txtNroAfiliado.Enabled = false;
            cmbTiposPlan.Enabled = false;
            await CargarObrasSociales();
        }
        private async Task CargarObrasSociales()
        {
            try
            {
                var obrasSociales = await ObraSocialApiClient.GetAllAsync();
                if (obrasSociales != null && obrasSociales.Count() > 0)
                {
                    cmbOS.SelectedIndexChanged -= cmbOS_SelectedIndexChanged;
                    cmbOS.DisplayMember = "Nombre";
                    cmbOS.ValueMember = "Id";
                    cmbOS.DataSource = obrasSociales;
                    cmbOS.SelectedIndex = -1; // No seleccionar nada por defecto
                    cmbOS.SelectedIndexChanged += cmbOS_SelectedIndexChanged;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las obras sociales: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void cmbOS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbOS.SelectedIndex == -1)
            {
                return;
            }
            int selectedValue = (int)cmbOS.SelectedValue;
            int obraSocialId = selectedValue;
            if(obraSocialId > 0)    
            {
                txtNroAfiliado.Enabled = true;
                await CargarTiposPlan(obraSocialId);

            }
            else {                 
                cmbTiposPlan.Enabled = false;
                cmbTiposPlan.DataSource = null;
                txtNroAfiliado.Enabled = false;
                txtNroAfiliado.Clear();
            }
        }
        private async Task CargarTiposPlan(int obraSocialId)
        {
            try
            {
                var tiposPlan = await TipoPlanApiClient.GetByObraSocialIdAsync(obraSocialId);
                if (tiposPlan != null && tiposPlan.Count() > 0)
                {
                    cmbTiposPlan.DisplayMember = "Nombre";
                    cmbTiposPlan.ValueMember = "Id";
                    cmbTiposPlan.Enabled = true;
                    cmbTiposPlan.DataSource = tiposPlan;
                    cmbTiposPlan.SelectedIndex = -1; // No seleccionar nada por defecto
                }
                else
                {
                    cmbTiposPlan.DataSource = null;
                    cmbTiposPlan.Enabled = false;
                    MessageBox.Show($"No se encontraron tipos de plan para la Obra Social seleccionada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los tipos de plan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}


                      
