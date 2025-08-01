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
            btnAgregarOS = new Button();
            txtNombreOS = new TextBox();
            SuspendLayout();
            // 
            // lblNombreOS
            // 
            lblNombreOS.AutoSize = true;
            lblNombreOS.Location = new Point(260, 152);
            lblNombreOS.Name = "lblNombreOS";
            lblNombreOS.Size = new Size(78, 25);
            lblNombreOS.TabIndex = 0;
            lblNombreOS.Text = "Nombre";
            // 
            // btnAgregarOS
            // 
            btnAgregarOS.Location = new Point(339, 352);
            btnAgregarOS.Name = "btnAgregarOS";
            btnAgregarOS.Size = new Size(112, 34);
            btnAgregarOS.TabIndex = 1;
            btnAgregarOS.Text = "Enviar";
            btnAgregarOS.UseVisualStyleBackColor = true;
            btnAgregarOS.Click += btnEnviarOS_Click;
            // 
            // txtNombreOS
            // 
            txtNombreOS.Location = new Point(431, 152);
            txtNombreOS.Name = "txtNombreOS";
            txtNombreOS.Size = new Size(150, 31);
            txtNombreOS.TabIndex = 2;
            // 
            // FormOS
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtNombreOS);
            Controls.Add(btnAgregarOS);
            Controls.Add(lblNombreOS);
            Name = "FormOS";
            Text = "FormOS";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNombreOS;
        private Button btnAgregarOS;
        private TextBox txtNombreOS;
    }
}