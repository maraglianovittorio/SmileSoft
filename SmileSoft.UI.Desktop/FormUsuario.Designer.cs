namespace SmileSoft.UI.Desktop
{
    partial class FormUsuario
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
            lblNombrePaciente = new Label();
            lblDNIPaciente = new Label();
            lblApellidoPaciente = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            btnAgregarUsuario = new Button();
            btnEditarUsuario = new Button();
            lbNuevoUsuario = new Label();
            cbRol = new ComboBox();
            SuspendLayout();
            // 
            // lblNombrePaciente
            // 
            lblNombrePaciente.AutoSize = true;
            lblNombrePaciente.Location = new Point(146, 48);
            lblNombrePaciente.Margin = new Padding(2, 0, 2, 0);
            lblNombrePaciente.Name = "lblNombrePaciente";
            lblNombrePaciente.Size = new Size(109, 15);
            lblNombrePaciente.TabIndex = 0;
            lblNombrePaciente.Text = "Nombre de usuario";
            // 
            // lblDNIPaciente
            // 
            lblDNIPaciente.AutoSize = true;
            lblDNIPaciente.Location = new Point(231, 105);
            lblDNIPaciente.Margin = new Padding(2, 0, 2, 0);
            lblDNIPaciente.Name = "lblDNIPaciente";
            lblDNIPaciente.Size = new Size(24, 15);
            lblDNIPaciente.TabIndex = 3;
            lblDNIPaciente.Text = "Rol";
            // 
            // lblApellidoPaciente
            // 
            lblApellidoPaciente.AutoSize = true;
            lblApellidoPaciente.Location = new Point(188, 77);
            lblApellidoPaciente.Margin = new Padding(2, 0, 2, 0);
            lblApellidoPaciente.Name = "lblApellidoPaciente";
            lblApellidoPaciente.Size = new Size(67, 15);
            lblApellidoPaciente.TabIndex = 4;
            lblApellidoPaciente.Text = "Contraseña";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(270, 48);
            txtUsername.Margin = new Padding(2);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(124, 23);
            txtUsername.TabIndex = 8;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(270, 74);
            txtPassword.Margin = new Padding(2);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(124, 23);
            txtPassword.TabIndex = 9;
            // 
            // btnAgregarUsuario
            // 
            btnAgregarUsuario.Location = new Point(246, 289);
            btnAgregarUsuario.Margin = new Padding(2);
            btnAgregarUsuario.Name = "btnAgregarUsuario";
            btnAgregarUsuario.Size = new Size(83, 27);
            btnAgregarUsuario.TabIndex = 16;
            btnAgregarUsuario.Text = "Enviar";
            btnAgregarUsuario.UseVisualStyleBackColor = true;
            btnAgregarUsuario.Click += btnEnviar_Click;
            // 
            // btnEditarUsuario
            // 
            btnEditarUsuario.Location = new Point(334, 289);
            btnEditarUsuario.Margin = new Padding(2);
            btnEditarUsuario.Name = "btnEditarUsuario";
            btnEditarUsuario.Size = new Size(83, 27);
            btnEditarUsuario.TabIndex = 18;
            btnEditarUsuario.Text = "Editar";
            btnEditarUsuario.UseVisualStyleBackColor = true;
            btnEditarUsuario.Click += btnEditarPaciente_Click;
            // 
            // lbNuevoUsuario
            // 
            lbNuevoUsuario.AutoSize = true;
            lbNuevoUsuario.Font = new Font("Segoe UI", 16F);
            lbNuevoUsuario.Location = new Point(173, 7);
            lbNuevoUsuario.Name = "lbNuevoUsuario";
            lbNuevoUsuario.Size = new Size(208, 30);
            lbNuevoUsuario.TabIndex = 19;
            lbNuevoUsuario.Text = "Crear nuevo usuario";
            // 
            // cbRol
            // 
            cbRol.FormattingEnabled = true;
            cbRol.Items.AddRange(new object[] { "Admin", "Odontologo", "Secretario" });
            cbRol.Location = new Point(270, 102);
            cbRol.Name = "cbRol";
            cbRol.Size = new Size(124, 23);
            cbRol.TabIndex = 20;
            // 
            // FormUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(648, 335);
            Controls.Add(cbRol);
            Controls.Add(lbNuevoUsuario);
            Controls.Add(btnEditarUsuario);
            Controls.Add(btnAgregarUsuario);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(lblApellidoPaciente);
            Controls.Add(lblDNIPaciente);
            Controls.Add(lblNombrePaciente);
            Margin = new Padding(2);
            Name = "FormUsuario";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNombrePaciente;
        private Label lblDNIPaciente;
        private Label lblApellidoPaciente;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private TextBox txtRol;
        private Button btnAgregarUsuario;
        private Button btnEditarUsuario;
        private Label lbNuevoUsuario;
        private ComboBox cbRol;
    }
}