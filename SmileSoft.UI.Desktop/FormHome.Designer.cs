namespace SmileSoft.UI.Desktop
{
    partial class FormHome
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
            btnObraSocial = new Button();
            SuspendLayout();
            // 
            // btnPacientes
            // 
            btnPacientes.Location = new Point(46, 57);
            btnPacientes.Margin = new Padding(2, 2, 2, 2);
            btnPacientes.Name = "btnPacientes";
            btnPacientes.Size = new Size(109, 46);
            btnPacientes.TabIndex = 0;
            btnPacientes.Text = "Pacientes";
            btnPacientes.UseVisualStyleBackColor = true;
            btnPacientes.Click += btnPacientes_Click;
            // 
            // btnObraSocial
            // 
            btnObraSocial.Location = new Point(234, 57);
            btnObraSocial.Margin = new Padding(2, 2, 2, 2);
            btnObraSocial.Name = "btnObraSocial";
            btnObraSocial.Size = new Size(111, 46);
            btnObraSocial.TabIndex = 1;
            btnObraSocial.Text = "Obra Social";
            btnObraSocial.UseVisualStyleBackColor = true;
            btnObraSocial.Click += btnObraSocial_Click;
            // 
            // FormHome
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(394, 177);
            Controls.Add(btnObraSocial);
            Controls.Add(btnPacientes);
            Margin = new Padding(2, 2, 2, 2);
            Name = "FormHome";
            Text = "FormHome";
            ResumeLayout(false);
        }

        #endregion

        private Button btnPacientes;
        private Button btnObraSocial;
    }
}