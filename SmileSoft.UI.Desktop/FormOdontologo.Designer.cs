namespace SmileSoft.UI.Desktop
{
    partial class FormOdontologo
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
            lblNombreOdontologo = new Label();
            lblApellidoOdontologo = new Label();
            lblNroMatricula = new Label();
            lblEmail = new Label();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtNroMatricula = new TextBox();
            txtEmail = new TextBox();
            btnAgregarOdontologo = new Button();
            btnEditarOdontologo = new Button();
            lblDni = new Label();
            txtDni = new TextBox();
            label1 = new Label();
            dtpFechaNacimiento = new DateTimePicker();
            lblDireccion = new Label();
            txtDireccion = new TextBox();
            lblTelefono = new Label();
            txtTelefono = new TextBox();
            SuspendLayout();
            // 
            // lblNombreOdontologo
            // 
            lblNombreOdontologo.AutoSize = true;
            lblNombreOdontologo.Location = new Point(119, 40);
            lblNombreOdontologo.Margin = new Padding(2, 0, 2, 0);
            lblNombreOdontologo.Name = "lblNombreOdontologo";
            lblNombreOdontologo.Size = new Size(51, 15);
            lblNombreOdontologo.TabIndex = 0;
            lblNombreOdontologo.Text = "Nombre";
            // 
            // lblApellidoOdontologo
            // 
            lblApellidoOdontologo.AutoSize = true;
            lblApellidoOdontologo.Location = new Point(119, 70);
            lblApellidoOdontologo.Margin = new Padding(2, 0, 2, 0);
            lblApellidoOdontologo.Name = "lblApellidoOdontologo";
            lblApellidoOdontologo.Size = new Size(51, 15);
            lblApellidoOdontologo.TabIndex = 2;
            lblApellidoOdontologo.Text = "Apellido";
            // 
            // lblNroMatricula
            // 
            lblNroMatricula.AutoSize = true;
            lblNroMatricula.Location = new Point(119, 100);
            lblNroMatricula.Margin = new Padding(2, 0, 2, 0);
            lblNroMatricula.Name = "lblNroMatricula";
            lblNroMatricula.Size = new Size(83, 15);
            lblNroMatricula.TabIndex = 4;
            lblNroMatricula.Text = "Nro. Matrícula";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(119, 130);
            lblEmail.Margin = new Padding(2, 0, 2, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(36, 15);
            lblEmail.TabIndex = 6;
            lblEmail.Text = "Email";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(245, 40);
            txtNombre.Margin = new Padding(2);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(200, 23);
            txtNombre.TabIndex = 1;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(245, 70);
            txtApellido.Margin = new Padding(2);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(200, 23);
            txtApellido.TabIndex = 3;
            // 
            // txtNroMatricula
            // 
            txtNroMatricula.Location = new Point(245, 100);
            txtNroMatricula.Margin = new Padding(2);
            txtNroMatricula.Name = "txtNroMatricula";
            txtNroMatricula.Size = new Size(200, 23);
            txtNroMatricula.TabIndex = 5;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(245, 130);
            txtEmail.Margin = new Padding(2);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(200, 23);
            txtEmail.TabIndex = 7;
            // 
            // btnAgregarOdontologo
            // 
            btnAgregarOdontologo.Location = new Point(247, 292);
            btnAgregarOdontologo.Margin = new Padding(2);
            btnAgregarOdontologo.Name = "btnAgregarOdontologo";
            btnAgregarOdontologo.Size = new Size(83, 27);
            btnAgregarOdontologo.TabIndex = 14;
            btnAgregarOdontologo.Text = "Guardar";
            btnAgregarOdontologo.UseVisualStyleBackColor = true;
            btnAgregarOdontologo.Click += btnEnviar_Click;
            // 
            // btnEditarOdontologo
            // 
            btnEditarOdontologo.Location = new Point(347, 292);
            btnEditarOdontologo.Margin = new Padding(2);
            btnEditarOdontologo.Name = "btnEditarOdontologo";
            btnEditarOdontologo.Size = new Size(83, 27);
            btnEditarOdontologo.TabIndex = 15;
            btnEditarOdontologo.Text = "Editar";
            btnEditarOdontologo.UseVisualStyleBackColor = true;
            btnEditarOdontologo.Click += btnEditarOdontologo_Click;
            // 
            // lblDni
            // 
            lblDni.AutoSize = true;
            lblDni.Location = new Point(119, 215);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(27, 15);
            lblDni.TabIndex = 10;
            lblDni.Text = "DNI";
            lblDni.Click += lblDni_Click;
            // 
            // txtDni
            // 
            txtDni.Location = new Point(247, 212);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(200, 23);
            txtDni.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(119, 246);
            label1.Name = "label1";
            label1.Size = new Size(77, 15);
            label1.TabIndex = 12;
            label1.Text = "Fecha nacim.";
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.CustomFormat = "mm/hh/yyyy";
            dtpFechaNacimiento.Format = DateTimePickerFormat.Short;
            dtpFechaNacimiento.Location = new Point(247, 241);
            dtpFechaNacimiento.MaxDate = new DateTime(2030, 12, 31, 0, 0, 0, 0);
            dtpFechaNacimiento.MinDate = new DateTime(1930, 1, 1, 0, 0, 0, 0);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(200, 23);
            dtpFechaNacimiento.TabIndex = 13;
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Location = new Point(119, 159);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(57, 15);
            lblDireccion.TabIndex = 8;
            lblDireccion.Text = "Direccion";
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(245, 157);
            txtDireccion.Margin = new Padding(2);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(200, 23);
            txtDireccion.TabIndex = 9;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(119, 186);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(52, 15);
            lblTelefono.TabIndex = 16;
            lblTelefono.Text = "Telefono";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(245, 183);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(200, 23);
            txtTelefono.TabIndex = 17;
            // 
            // FormOdontologo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(650, 350);
            Controls.Add(txtTelefono);
            Controls.Add(lblTelefono);
            Controls.Add(txtDireccion);
            Controls.Add(lblDireccion);
            Controls.Add(dtpFechaNacimiento);
            Controls.Add(label1);
            Controls.Add(txtDni);
            Controls.Add(lblDni);
            Controls.Add(btnEditarOdontologo);
            Controls.Add(btnAgregarOdontologo);
            Controls.Add(txtEmail);
            Controls.Add(txtNroMatricula);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Controls.Add(lblEmail);
            Controls.Add(lblNroMatricula);
            Controls.Add(lblApellidoOdontologo);
            Controls.Add(lblNombreOdontologo);
            Margin = new Padding(2);
            Name = "FormOdontologo";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNombreOdontologo;
        private Label lblApellidoOdontologo;
        private Label lblNroMatricula;
        private Label lblEmail;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtNroMatricula;
        private TextBox txtEmail;
        private Button btnAgregarOdontologo;
        private Button btnEditarOdontologo;
        private Label lblDni;
        private TextBox txtDni;
        private Label label1;
        private DateTimePicker dtpFechaNacimiento;
        private Label lblDireccion;
        private TextBox txtDireccion;
        private Label lblTelefono;
        private TextBox txtTelefono;
    }
}