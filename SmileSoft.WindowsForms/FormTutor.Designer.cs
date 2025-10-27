namespace SmileSoft.UI.Desktop
{
    partial class FormTutor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblNombrePaciente = new Label();
            lblFechaNacimiento = new Label();
            lblDireccionPaciente = new Label();
            lblDNIPaciente = new Label();
            lblApellidoPaciente = new Label();
            lblTelefono = new Label();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtDNI = new TextBox();
            txtEmail = new TextBox();
            txtDireccion = new TextBox();
            txtTelefono = new TextBox();
            btnGuardarTutor = new Button();
            lblEmail = new Label();
            dtpFechaNacimiento = new DateTimePicker();
            btnEditarTutor = new Button();
            tipoPlanBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)tipoPlanBindingSource).BeginInit();
            SuspendLayout();
            // 
            // lblNombrePaciente
            // 
            lblNombrePaciente.AutoSize = true;
            lblNombrePaciente.Location = new Point(288, 92);
            lblNombrePaciente.Margin = new Padding(2, 0, 2, 0);
            lblNombrePaciente.Name = "lblNombrePaciente";
            lblNombrePaciente.Size = new Size(51, 15);
            lblNombrePaciente.TabIndex = 0;
            lblNombrePaciente.Text = "Nombre";
            // 
            // lblFechaNacimiento
            // 
            lblFechaNacimiento.AutoSize = true;
            lblFechaNacimiento.Location = new Point(288, 227);
            lblFechaNacimiento.Margin = new Padding(2, 0, 2, 0);
            lblFechaNacimiento.Name = "lblFechaNacimiento";
            lblFechaNacimiento.Size = new Size(103, 15);
            lblFechaNacimiento.TabIndex = 10;
            lblFechaNacimiento.Text = "Fecha Nacimiento";
            // 
            // lblDireccionPaciente
            // 
            lblDireccionPaciente.AutoSize = true;
            lblDireccionPaciente.Location = new Point(288, 202);
            lblDireccionPaciente.Margin = new Padding(2, 0, 2, 0);
            lblDireccionPaciente.Name = "lblDireccionPaciente";
            lblDireccionPaciente.Size = new Size(57, 15);
            lblDireccionPaciente.TabIndex = 8;
            lblDireccionPaciente.Text = "Dirección";
            // 
            // lblDNIPaciente
            // 
            lblDNIPaciente.AutoSize = true;
            lblDNIPaciente.Location = new Point(288, 150);
            lblDNIPaciente.Margin = new Padding(2, 0, 2, 0);
            lblDNIPaciente.Name = "lblDNIPaciente";
            lblDNIPaciente.Size = new Size(27, 15);
            lblDNIPaciente.TabIndex = 4;
            lblDNIPaciente.Text = "DNI";
            // 
            // lblApellidoPaciente
            // 
            lblApellidoPaciente.AutoSize = true;
            lblApellidoPaciente.Location = new Point(288, 122);
            lblApellidoPaciente.Margin = new Padding(2, 0, 2, 0);
            lblApellidoPaciente.Name = "lblApellidoPaciente";
            lblApellidoPaciente.Size = new Size(51, 15);
            lblApellidoPaciente.TabIndex = 2;
            lblApellidoPaciente.Text = "Apellido";
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(288, 255);
            lblTelefono.Margin = new Padding(2, 0, 2, 0);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(52, 15);
            lblTelefono.TabIndex = 12;
            lblTelefono.Text = "Teléfono";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(414, 92);
            txtNombre.Margin = new Padding(2);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(124, 23);
            txtNombre.TabIndex = 1;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(414, 118);
            txtApellido.Margin = new Padding(2);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(124, 23);
            txtApellido.TabIndex = 3;
            // 
            // txtDNI
            // 
            txtDNI.Location = new Point(414, 146);
            txtDNI.Margin = new Padding(2);
            txtDNI.Name = "txtDNI";
            txtDNI.Size = new Size(124, 23);
            txtDNI.TabIndex = 5;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(414, 175);
            txtEmail.Margin = new Padding(2);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(124, 23);
            txtEmail.TabIndex = 7;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(414, 199);
            txtDireccion.Margin = new Padding(2);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(124, 23);
            txtDireccion.TabIndex = 9;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(414, 255);
            txtTelefono.Margin = new Padding(2);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(124, 23);
            txtTelefono.TabIndex = 13;
            // 
            // btnGuardarTutor
            // 
            btnGuardarTutor.Location = new Point(394, 340);
            btnGuardarTutor.Margin = new Padding(2);
            btnGuardarTutor.Name = "btnGuardarTutor";
            btnGuardarTutor.Size = new Size(83, 27);
            btnGuardarTutor.TabIndex = 22;
            btnGuardarTutor.Text = "Guardar";
            btnGuardarTutor.UseVisualStyleBackColor = true;
            btnGuardarTutor.Click += btnEnviar_Click;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(288, 178);
            lblEmail.Margin = new Padding(2, 0, 2, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(36, 15);
            lblEmail.TabIndex = 6;
            lblEmail.Text = "Email";
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.Format = DateTimePickerFormat.Custom;
            dtpFechaNacimiento.Location = new Point(416, 226);
            dtpFechaNacimiento.Margin = new Padding(2);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(123, 23);
            dtpFechaNacimiento.TabIndex = 11;
            dtpFechaNacimiento.Value = new DateTime(2025, 1, 1, 0, 0, 0, 0);
            // 
            // btnEditarTutor
            // 
            btnEditarTutor.Location = new Point(494, 340);
            btnEditarTutor.Margin = new Padding(2);
            btnEditarTutor.Name = "btnEditarTutor";
            btnEditarTutor.Size = new Size(83, 27);
            btnEditarTutor.TabIndex = 23;
            btnEditarTutor.Text = "Editar";
            btnEditarTutor.UseVisualStyleBackColor = true;
            btnEditarTutor.Click += btnEditarPaciente_Click;
            // 
            // tipoPlanBindingSource
            // 
            tipoPlanBindingSource.DataSource = typeof(Dominio.TipoPlan);
            // 
            // FormTutor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(853, 556);
            Controls.Add(btnEditarTutor);
            Controls.Add(dtpFechaNacimiento);
            Controls.Add(lblEmail);
            Controls.Add(btnGuardarTutor);
            Controls.Add(txtTelefono);
            Controls.Add(txtDireccion);
            Controls.Add(txtEmail);
            Controls.Add(txtDNI);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Controls.Add(lblTelefono);
            Controls.Add(lblApellidoPaciente);
            Controls.Add(lblDNIPaciente);
            Controls.Add(lblDireccionPaciente);
            Controls.Add(lblFechaNacimiento);
            Controls.Add(lblNombrePaciente);
            Margin = new Padding(2);
            Name = "FormTutor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form Tutor";
            ((System.ComponentModel.ISupportInitialize)tipoPlanBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNombrePaciente;
        private Label lblFechaNacimiento;
        private Label lblDireccionPaciente;
        private Label lblDNIPaciente;
        private Label lblApellidoPaciente;
        private Label lblTelefono;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtDNI;
        private TextBox txtEmail;
        private TextBox txtDireccion;
        private TextBox txtTelefono;
        private Button btnGuardarTutor;
        private Label lblEmail;
        private DateTimePicker dtpFechaNacimiento;
        private Button btnEditarTutor;
        private BindingSource tipoPlanBindingSource;
    }
}