namespace SmileSoft.UI.Desktop
{
    partial class FormPaciente
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
            lblNroHC = new Label();
            lblTelefono = new Label();
            lblNroAfiliado = new Label();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtDNI = new TextBox();
            txtEmail = new TextBox();
            txtDireccion = new TextBox();
            txtTelefono = new TextBox();
            txtNroAfiliado = new TextBox();
            btnAgregarPaciente = new Button();
            lblEmail = new Label();
            txtNroHC = new TextBox();
            dtpFechaNacimiento = new DateTimePicker();
            btnEditarPaciente = new Button();
            lblOS = new Label();
            cmbTiposPlan = new ComboBox();
            tipoPlanBindingSource = new BindingSource(components);
            lblTipoPlan = new Label();
            btnAgregarTutor = new Button();
            lblTutor = new Label();
            txtTutor = new TextBox();
            cmbOS = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)tipoPlanBindingSource).BeginInit();
            SuspendLayout();
            // 
            // lblNombrePaciente
            // 
            lblNombrePaciente.AutoSize = true;
            lblNombrePaciente.Location = new Point(251, 73);
            lblNombrePaciente.Margin = new Padding(2, 0, 2, 0);
            lblNombrePaciente.Name = "lblNombrePaciente";
            lblNombrePaciente.Size = new Size(51, 15);
            lblNombrePaciente.TabIndex = 0;
            lblNombrePaciente.Text = "Nombre";
            // 
            // lblFechaNacimiento
            // 
            lblFechaNacimiento.AutoSize = true;
            lblFechaNacimiento.Location = new Point(251, 208);
            lblFechaNacimiento.Margin = new Padding(2, 0, 2, 0);
            lblFechaNacimiento.Name = "lblFechaNacimiento";
            lblFechaNacimiento.Size = new Size(103, 15);
            lblFechaNacimiento.TabIndex = 10;
            lblFechaNacimiento.Text = "Fecha Nacimiento";
            // 
            // lblDireccionPaciente
            // 
            lblDireccionPaciente.AutoSize = true;
            lblDireccionPaciente.Location = new Point(251, 183);
            lblDireccionPaciente.Margin = new Padding(2, 0, 2, 0);
            lblDireccionPaciente.Name = "lblDireccionPaciente";
            lblDireccionPaciente.Size = new Size(57, 15);
            lblDireccionPaciente.TabIndex = 8;
            lblDireccionPaciente.Text = "Dirección";
            // 
            // lblDNIPaciente
            // 
            lblDNIPaciente.AutoSize = true;
            lblDNIPaciente.Location = new Point(251, 131);
            lblDNIPaciente.Margin = new Padding(2, 0, 2, 0);
            lblDNIPaciente.Name = "lblDNIPaciente";
            lblDNIPaciente.Size = new Size(27, 15);
            lblDNIPaciente.TabIndex = 4;
            lblDNIPaciente.Text = "DNI";
            // 
            // lblApellidoPaciente
            // 
            lblApellidoPaciente.AutoSize = true;
            lblApellidoPaciente.Location = new Point(251, 103);
            lblApellidoPaciente.Margin = new Padding(2, 0, 2, 0);
            lblApellidoPaciente.Name = "lblApellidoPaciente";
            lblApellidoPaciente.Size = new Size(51, 15);
            lblApellidoPaciente.TabIndex = 2;
            lblApellidoPaciente.Text = "Apellido";
            // 
            // lblNroHC
            // 
            lblNroHC.AutoSize = true;
            lblNroHC.Location = new Point(251, 263);
            lblNroHC.Margin = new Padding(2, 0, 2, 0);
            lblNroHC.Name = "lblNroHC";
            lblNroHC.Size = new Size(47, 15);
            lblNroHC.TabIndex = 16;
            lblNroHC.Text = "Nro HC";
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(251, 236);
            lblTelefono.Margin = new Padding(2, 0, 2, 0);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(52, 15);
            lblTelefono.TabIndex = 12;
            lblTelefono.Text = "Teléfono";
            // 
            // lblNroAfiliado
            // 
            lblNroAfiliado.AutoSize = true;
            lblNroAfiliado.Location = new Point(248, 348);
            lblNroAfiliado.Margin = new Padding(2, 0, 2, 0);
            lblNroAfiliado.Name = "lblNroAfiliado";
            lblNroAfiliado.Size = new Size(92, 15);
            lblNroAfiliado.TabIndex = 14;
            lblNroAfiliado.Text = "Nro afiliado(OS)";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(377, 73);
            txtNombre.Margin = new Padding(2);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(124, 23);
            txtNombre.TabIndex = 0;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(377, 99);
            txtApellido.Margin = new Padding(2);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(124, 23);
            txtApellido.TabIndex = 1;
            // 
            // txtDNI
            // 
            txtDNI.Location = new Point(377, 127);
            txtDNI.Margin = new Padding(2);
            txtDNI.Name = "txtDNI";
            txtDNI.Size = new Size(124, 23);
            txtDNI.TabIndex = 2;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(377, 156);
            txtEmail.Margin = new Padding(2);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(124, 23);
            txtEmail.TabIndex = 3;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(377, 180);
            txtDireccion.Margin = new Padding(2);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(124, 23);
            txtDireccion.TabIndex = 4;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(377, 236);
            txtTelefono.Margin = new Padding(2);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(124, 23);
            txtTelefono.TabIndex = 6;
            // 
            // txtNroAfiliado
            // 
            txtNroAfiliado.Location = new Point(374, 348);
            txtNroAfiliado.Margin = new Padding(2);
            txtNroAfiliado.Name = "txtNroAfiliado";
            txtNroAfiliado.Size = new Size(124, 23);
            txtNroAfiliado.TabIndex = 10;
            // 
            // btnAgregarPaciente
            // 
            btnAgregarPaciente.Location = new Point(385, 429);
            btnAgregarPaciente.Margin = new Padding(2);
            btnAgregarPaciente.Name = "btnAgregarPaciente";
            btnAgregarPaciente.Size = new Size(83, 27);
            btnAgregarPaciente.TabIndex = 12;
            btnAgregarPaciente.Text = "Enviar";
            btnAgregarPaciente.UseVisualStyleBackColor = true;
            btnAgregarPaciente.Click += btnEnviar_Click;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(251, 159);
            lblEmail.Margin = new Padding(2, 0, 2, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(36, 15);
            lblEmail.TabIndex = 6;
            lblEmail.Text = "Email";
            // 
            // txtNroHC
            // 
            txtNroHC.Location = new Point(377, 263);
            txtNroHC.Margin = new Padding(2);
            txtNroHC.Name = "txtNroHC";
            txtNroHC.Size = new Size(124, 23);
            txtNroHC.TabIndex = 7;
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.Format = DateTimePickerFormat.Custom;
            dtpFechaNacimiento.Location = new Point(379, 207);
            dtpFechaNacimiento.Margin = new Padding(2);
            dtpFechaNacimiento.MaxDate = new DateTime(2030, 12, 31, 0, 0, 0, 0);
            dtpFechaNacimiento.MinDate = new DateTime(1930, 1, 1, 0, 0, 0, 0);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(123, 23);
            dtpFechaNacimiento.TabIndex = 5;
            dtpFechaNacimiento.Value = new DateTime(2025, 10, 19, 0, 0, 0, 0);
            dtpFechaNacimiento.Leave += dtpFechaNacimiento_Leave;
            // 
            // btnEditarPaciente
            // 
            btnEditarPaciente.Location = new Point(485, 429);
            btnEditarPaciente.Margin = new Padding(2);
            btnEditarPaciente.Name = "btnEditarPaciente";
            btnEditarPaciente.Size = new Size(83, 27);
            btnEditarPaciente.TabIndex = 13;
            btnEditarPaciente.Text = "Editar";
            btnEditarPaciente.UseVisualStyleBackColor = true;
            btnEditarPaciente.Click += btnEditarPaciente_Click;
            // 
            // lblOS
            // 
            lblOS.AutoSize = true;
            lblOS.Location = new Point(251, 290);
            lblOS.Name = "lblOS";
            lblOS.Size = new Size(67, 15);
            lblOS.TabIndex = 18;
            lblOS.Text = "Obra Social";
            // 
            // cmbTiposPlan
            // 
            cmbTiposPlan.FormattingEnabled = true;
            cmbTiposPlan.Location = new Point(377, 320);
            cmbTiposPlan.Name = "cmbTiposPlan";
            cmbTiposPlan.Size = new Size(121, 23);
            cmbTiposPlan.TabIndex = 9;
            // 
            // tipoPlanBindingSource
            // 
            tipoPlanBindingSource.DataSource = typeof(Dominio.TipoPlan);
            // 
            // lblTipoPlan
            // 
            lblTipoPlan.AutoSize = true;
            lblTipoPlan.Location = new Point(251, 320);
            lblTipoPlan.Name = "lblTipoPlan";
            lblTipoPlan.Size = new Size(56, 15);
            lblTipoPlan.TabIndex = 20;
            lblTipoPlan.Text = "Tipo Plan";
            // 
            // btnAgregarTutor
            // 
            btnAgregarTutor.Location = new Point(403, 474);
            btnAgregarTutor.Name = "btnAgregarTutor";
            btnAgregarTutor.Size = new Size(132, 26);
            btnAgregarTutor.TabIndex = 14;
            btnAgregarTutor.Text = "Agregar tutor";
            btnAgregarTutor.UseVisualStyleBackColor = true;
            btnAgregarTutor.Click += btnAgregarTutor_Click;
            // 
            // lblTutor
            // 
            lblTutor.AutoSize = true;
            lblTutor.Location = new Point(249, 376);
            lblTutor.Name = "lblTutor";
            lblTutor.Size = new Size(35, 15);
            lblTutor.TabIndex = 22;
            lblTutor.Text = "Tutor";
            // 
            // txtTutor
            // 
            txtTutor.Location = new Point(374, 376);
            txtTutor.Name = "txtTutor";
            txtTutor.ReadOnly = true;
            txtTutor.Size = new Size(121, 23);
            txtTutor.TabIndex = 11;
            // 
            // cmbOS
            // 
            cmbOS.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOS.FormattingEnabled = true;
            cmbOS.Location = new Point(377, 290);
            cmbOS.Name = "cmbOS";
            cmbOS.Size = new Size(121, 23);
            cmbOS.TabIndex = 8;
            cmbOS.SelectedIndexChanged += cmbOS_SelectedIndexChanged;
            // 
            // FormPaciente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(805, 555);
            Controls.Add(cmbOS);
            Controls.Add(txtTutor);
            Controls.Add(lblTutor);
            Controls.Add(btnAgregarTutor);
            Controls.Add(lblTipoPlan);
            Controls.Add(cmbTiposPlan);
            Controls.Add(lblOS);
            Controls.Add(btnEditarPaciente);
            Controls.Add(dtpFechaNacimiento);
            Controls.Add(txtNroHC);
            Controls.Add(lblEmail);
            Controls.Add(btnAgregarPaciente);
            Controls.Add(txtNroAfiliado);
            Controls.Add(txtTelefono);
            Controls.Add(txtDireccion);
            Controls.Add(txtEmail);
            Controls.Add(txtDNI);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Controls.Add(lblNroAfiliado);
            Controls.Add(lblTelefono);
            Controls.Add(lblNroHC);
            Controls.Add(lblApellidoPaciente);
            Controls.Add(lblDNIPaciente);
            Controls.Add(lblDireccionPaciente);
            Controls.Add(lblFechaNacimiento);
            Controls.Add(lblNombrePaciente);
            Margin = new Padding(2);
            Name = "FormPaciente";
            StartPosition = FormStartPosition.CenterParent;
            Load += FormPaciente_Load;
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
        private Label lblNroHC;
        private Label lblTelefono;
        private Label lblNroAfiliado;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtDNI;
        private TextBox txtEmail;
        private TextBox txtDireccion;
        private TextBox txtTelefono;
        private TextBox txtNroAfiliado;
        private Button btnAgregarPaciente;
        private Label lblEmail;
        private TextBox txtNroHC;
        private DateTimePicker dtpFechaNacimiento;
        private Button btnEditarPaciente;
        private Label lblOS;
        private ComboBox cmbTiposPlan;
        private BindingSource tipoPlanBindingSource;
        private Label lblTipoPlan;
        private Button btnAgregarTutor;
        private Label lblTutor;
        private TextBox txtTutor;
        private ComboBox cmbOS;
    }
}