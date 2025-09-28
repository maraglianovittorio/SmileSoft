namespace SmileSoft.WindowsForms
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            lblTitulo = new Label();
            lblUsuario = new Label();
            txtUsuario = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            btnLogin = new Button();
            btnCancelar = new Button();
            imgOjoPassword = new PictureBox();
            lblUsuarioDemo = new Label();
            lblPassDemo = new Label();
            ((System.ComponentModel.ISupportInitialize)imgOjoPassword).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.Location = new Point(143, 31);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(111, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "SmileSoft";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblUsuario.Location = new Point(50, 92);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(67, 20);
            lblUsuario.TabIndex = 1;
            lblUsuario.Text = "Usuario:";
            // 
            // txtUsuario
            // 
            txtUsuario.Font = new Font("Segoe UI", 11F);
            txtUsuario.Location = new Point(50, 117);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(300, 27);
            txtUsuario.TabIndex = 2;
            txtUsuario.KeyDown += txtUsuario_KeyDown;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblPassword.Location = new Point(50, 162);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(92, 20);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Contraseña:";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 11F);
            txtPassword.Location = new Point(50, 187);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.Size = new Size(300, 27);
            txtPassword.TabIndex = 4;
            txtPassword.KeyDown += txtPassword_KeyDown;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(70, 130, 180);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(50, 250);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(140, 40);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Iniciar sesión";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(220, 20, 60);
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(210, 250);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(140, 40);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // imgOjoPassword
            // 
            imgOjoPassword.BackColor = Color.Transparent;
            imgOjoPassword.ErrorImage = (Image)resources.GetObject("imgOjoPassword.ErrorImage");
            imgOjoPassword.Image = (Image)resources.GetObject("imgOjoPassword.Image");
            imgOjoPassword.InitialImage = (Image)resources.GetObject("imgOjoPassword.InitialImage");
            imgOjoPassword.Location = new Point(322, 188);
            imgOjoPassword.Name = "imgOjoPassword";
            imgOjoPassword.Size = new Size(27, 25);
            imgOjoPassword.SizeMode = PictureBoxSizeMode.StretchImage;
            imgOjoPassword.TabIndex = 7;
            imgOjoPassword.TabStop = false;
            imgOjoPassword.Click += ImgOjoPassword_Click;
            // 
            // lblUsuarioDemo
            // 
            lblUsuarioDemo.AutoSize = true;
            lblUsuarioDemo.ForeColor = SystemColors.ControlDark;
            lblUsuarioDemo.Location = new Point(312, 147);
            lblUsuarioDemo.Name = "lblUsuarioDemo";
            lblUsuarioDemo.Size = new Size(43, 15);
            lblUsuarioDemo.TabIndex = 8;
            lblUsuarioDemo.Text = "Admin";
            // 
            // lblPassDemo
            // 
            lblPassDemo.AutoSize = true;
            lblPassDemo.ForeColor = SystemColors.ControlDark;
            lblPassDemo.Location = new Point(306, 216);
            lblPassDemo.Name = "lblPassDemo";
            lblPassDemo.Size = new Size(41, 15);
            lblPassDemo.TabIndex = 9;
            lblPassDemo.Text = "admin";
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 248, 255);
            ClientSize = new Size(400, 320);
            Controls.Add(lblPassDemo);
            Controls.Add(lblUsuarioDemo);
            Controls.Add(imgOjoPassword);
            Controls.Add(btnCancelar);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtUsuario);
            Controls.Add(lblUsuario);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SmileSoft - Login";
            KeyDown += FormLogin_KeyDown;
            ((System.ComponentModel.ISupportInitialize)imgOjoPassword).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblUsuario;
        private TextBox txtUsuario;
        private Label lblPassword;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnCancelar;
        private PictureBox imgOjoPassword;
        private Label lblUsuarioDemo;
        private Label lblPassDemo;
    }
}