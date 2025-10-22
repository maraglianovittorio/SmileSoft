namespace SmileSoft.UI.Desktop
{
    partial class FormOS
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
            lblNombreOS = new Label();
            btnGuardarOS = new Button();
            txtNombreOS = new TextBox();
            btnEditarOS = new Button();
            SuspendLayout();
            // 
            // lblNombreOS
            // 
            lblNombreOS.AutoSize = true;
            lblNombreOS.Location = new Point(182, 91);
            lblNombreOS.Margin = new Padding(2, 0, 2, 0);
            lblNombreOS.Name = "lblNombreOS";
            lblNombreOS.Size = new Size(51, 15);
            lblNombreOS.TabIndex = 0;
            lblNombreOS.Text = "Nombre";
            // 
            // btnGuardarOS
            // 
            btnGuardarOS.Location = new Point(182, 211);
            btnGuardarOS.Margin = new Padding(2, 2, 2, 2);
            btnGuardarOS.Name = "btnGuardarOS";
            btnGuardarOS.Size = new Size(79, 33);
            btnGuardarOS.TabIndex = 1;
            btnGuardarOS.Text = "Guardar";
            btnGuardarOS.UseVisualStyleBackColor = true;
            btnGuardarOS.Click += btnEnviarOS_Click;
            // 
            // txtNombreOS
            // 
            txtNombreOS.Location = new Point(302, 91);
            txtNombreOS.Margin = new Padding(2, 2, 2, 2);
            txtNombreOS.Name = "txtNombreOS";
            txtNombreOS.Size = new Size(106, 23);
            txtNombreOS.TabIndex = 2;
            // 
            // btnEditarOS
            // 
            btnEditarOS.Location = new Point(302, 211);
            btnEditarOS.Margin = new Padding(2, 2, 2, 2);
            btnEditarOS.Name = "btnEditarOS";
            btnEditarOS.Size = new Size(80, 33);
            btnEditarOS.TabIndex = 3;
            btnEditarOS.Text = "Editar";
            btnEditarOS.UseVisualStyleBackColor = true;
            btnEditarOS.Click += btnEditarOS_Click;
            // 
            // FormOS
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 270);
            Controls.Add(btnEditarOS);
            Controls.Add(txtNombreOS);
            Controls.Add(btnGuardarOS);
            Controls.Add(lblNombreOS);
            Margin = new Padding(2, 2, 2, 2);
            Name = "FormOS";
            Text = "FormOS";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNombreOS;
        private Button btnAgregarOS;
        private TextBox txtNombreOS;
        private Button btnEditarOS;
        private Button btnGuardarOS;
    }
}