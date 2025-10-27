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
            lblUsername = new Label();
            lblRol = new Label();
            lblPassword = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            btnGuardarUsuario = new Button();
            btnEditarUsuario = new Button();
            lbNuevoUsuario = new Label();
            cbRol = new ComboBox();
            SuspendLayout();
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(241, 111);
            lblUsername.Margin = new Padding(2, 0, 2, 0);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(109, 15);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Nombre de usuario";
            // 
            // lblRol
            // 
            lblRol.AutoSize = true;
            lblRol.Location = new Point(359, 168);
            lblRol.Margin = new Padding(2, 0, 2, 0);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(24, 15);
            lblRol.TabIndex = 4;
            lblRol.Text = "Rol";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(301, 140);
            lblPassword.Margin = new Padding(2, 0, 2, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(67, 15);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Contraseña";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(398, 111);
            txtUsername.Margin = new Padding(2);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(124, 23);
            txtUsername.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(398, 137);
            txtPassword.Margin = new Padding(2);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(124, 23);
            txtPassword.TabIndex = 3;
            // 
            // btnGuardarUsuario
            // 
            btnGuardarUsuario.Location = new Point(338, 292);
            btnGuardarUsuario.Margin = new Padding(2);
            btnGuardarUsuario.Name = "btnGuardarUsuario";
            btnGuardarUsuario.Size = new Size(83, 27);
            btnGuardarUsuario.TabIndex = 6;
            btnGuardarUsuario.Text = "Guardar";
            btnGuardarUsuario.UseVisualStyleBackColor = true;
            btnGuardarUsuario.Click += btnEnviar_Click;
            // 
            // btnEditarUsuario
            // 
            btnEditarUsuario.Location = new Point(426, 292);
            btnEditarUsuario.Margin = new Padding(2);
            btnEditarUsuario.Name = "btnEditarUsuario";
            btnEditarUsuario.Size = new Size(83, 27);
            btnEditarUsuario.TabIndex = 7;
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
            lbNuevoUsuario.Size = new Size(0, 30);
            lbNuevoUsuario.TabIndex = 19;
            // 
            // cbRol
            // 
            cbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRol.FormattingEnabled = true;
            cbRol.Items.AddRange(new object[] { "Admin", "Secretario" });
            cbRol.Location = new Point(398, 165);
            cbRol.Name = "cbRol";
            cbRol.Size = new Size(124, 23);
            cbRol.TabIndex = 5;
            // 
            // FormUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(798, 426);
            Controls.Add(cbRol);
            Controls.Add(lbNuevoUsuario);
            Controls.Add(btnEditarUsuario);
            Controls.Add(btnGuardarUsuario);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(lblPassword);
            Controls.Add(lblRol);
            Controls.Add(lblUsername);
            Margin = new Padding(2);
            Name = "FormUsuario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form Usuario";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUsername;
        private Label lblRol;
        private Label lblPassword;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private TextBox txtRol;
        private Button btnGuardarUsuario;
        private Button btnEditarUsuario;
        private Label lbNuevoUsuario;
        private ComboBox cbRol;
    }
}