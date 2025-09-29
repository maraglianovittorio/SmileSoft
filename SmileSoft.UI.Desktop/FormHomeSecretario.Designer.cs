namespace SmileSoft.UI.Desktop
{
    partial class FormHomeSecretario
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
            btnPacientes = new Button();
            BtnCerrarSesion = new Button();
            SuspendLayout();
            // 
            // btnPacientes
            // 
            btnPacientes.Location = new Point(139, 67);
            btnPacientes.Margin = new Padding(2);
            btnPacientes.Name = "btnPacientes";
            btnPacientes.Size = new Size(109, 46);
            btnPacientes.TabIndex = 0;
            btnPacientes.Text = "Pacientes";
            btnPacientes.UseVisualStyleBackColor = true;
            btnPacientes.Click += btnPacientes_Click;
            // 
            // BtnCerrarSesion
            // 
            BtnCerrarSesion.BackColor = SystemColors.ActiveCaption;
            BtnCerrarSesion.Location = new Point(544, 263);
            BtnCerrarSesion.Name = "BtnCerrarSesion";
            BtnCerrarSesion.Size = new Size(133, 41);
            BtnCerrarSesion.TabIndex = 9;
            BtnCerrarSesion.Text = "Cerrar sesion";
            BtnCerrarSesion.UseVisualStyleBackColor = false;
            BtnCerrarSesion.Click += BtnCerrarSesion_Click;
            // 
            // FormHomeSecretario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(701, 316);
            Controls.Add(BtnCerrarSesion);
            Controls.Add(btnPacientes);
            Margin = new Padding(2);
            Name = "FormHomeSecretario";
            Text = "FormHome";
            ResumeLayout(false);
        }

        #endregion

        private Button btnPacientes;
        private Button BtnCerrarSesion;
    }
}