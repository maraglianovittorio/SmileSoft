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
            btnAgregarOdontologo.Location = new Point(245, 240);
            btnAgregarOdontologo.Margin = new Padding(2);
            btnAgregarOdontologo.Name = "btnAgregarOdontologo";
            btnAgregarOdontologo.Size = new Size(83, 27);
            btnAgregarOdontologo.TabIndex = 12;
            btnAgregarOdontologo.Text = "Enviar";
            btnAgregarOdontologo.UseVisualStyleBackColor = true;
            btnAgregarOdontologo.Click += btnEnviar_Click;
            // 
            // btnEditarOdontologo
            // 
            btnEditarOdontologo.Location = new Point(345, 240);
            btnEditarOdontologo.Margin = new Padding(2);
            btnEditarOdontologo.Name = "btnEditarOdontologo";
            btnEditarOdontologo.Size = new Size(83, 27);
            btnEditarOdontologo.TabIndex = 13;
            btnEditarOdontologo.Text = "Editar";
            btnEditarOdontologo.UseVisualStyleBackColor = true;
            btnEditarOdontologo.Click += btnEditarOdontologo_Click;
            // 
            // FormOdontologo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(650, 350);
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
    }
}