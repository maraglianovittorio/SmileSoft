namespace SmileSoft.UI.Desktop
{
    partial class FormGetPacientes
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnGetPacientes = new Button();
            dvgPacientes = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dvgPacientes).BeginInit();
            SuspendLayout();
            // 
            // btnGetPacientes
            // 
            btnGetPacientes.Location = new Point(280, 407);
            btnGetPacientes.Name = "btnGetPacientes";
            btnGetPacientes.Size = new Size(125, 37);
            btnGetPacientes.TabIndex = 0;
            btnGetPacientes.Text = "Ver Pacientes";
            btnGetPacientes.UseVisualStyleBackColor = true;
            btnGetPacientes.Click += btnGetPacientes_Click_1;
            // 
            // dvgPacientes
            // 
            dvgPacientes.AllowDrop = true;
            dvgPacientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dvgPacientes.Location = new Point(12, 12);
            dvgPacientes.Name = "dvgPacientes";
            dvgPacientes.RowHeadersWidth = 62;
            dvgPacientes.Size = new Size(702, 369);
            dvgPacientes.TabIndex = 1;
            // 
            // FormGetPacientes
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(744, 456);
            Controls.Add(dvgPacientes);
            Controls.Add(btnGetPacientes);
            Name = "FormGetPacientes";
            Text = "FormGetPacientes";
            ((System.ComponentModel.ISupportInitialize)dvgPacientes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnGetPacientes;
        private DataGridView dvgPacientes;
    }
}
