namespace SmileSoft.UI.Desktop
{
    partial class FormHomeOS
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHomeOS));
            dgvFormOS = new DataGridView();
            textBox1 = new TextBox();
            txtBuscarOS = new TextBox();
            lupaPng = new PictureBox();
            pacienteBindingSource = new BindingSource(components);
            btnAgregarOS = new Button();
            btnBorrarOS = new Button();
            btnEditarOS = new Button();
            BtnVolver = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvFormOS).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lupaPng).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pacienteBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dgvFormOS
            // 
            dgvFormOS.AllowUserToAddRows = false;
            dgvFormOS.AllowUserToDeleteRows = false;
            dgvFormOS.AllowUserToOrderColumns = true;
            dgvFormOS.BackgroundColor = Color.PapayaWhip;
            dgvFormOS.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFormOS.Location = new Point(26, 55);
            dgvFormOS.Margin = new Padding(2);
            dgvFormOS.Name = "dgvFormOS";
            dgvFormOS.ReadOnly = true;
            dgvFormOS.RowHeadersWidth = 62;
            dgvFormOS.Size = new Size(759, 223);
            dgvFormOS.TabIndex = 0;
            dgvFormOS.SelectionChanged += dgvFormHomeOS_SelectionChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(525, -118);
            textBox1.Margin = new Padding(2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(517, 23);
            textBox1.TabIndex = 1;
            // 
            // txtBuscarOS
            // 
            txtBuscarOS.Location = new Point(26, 21);
            txtBuscarOS.Margin = new Padding(2);
            txtBuscarOS.Name = "txtBuscarOS";
            txtBuscarOS.Size = new Size(530, 23);
            txtBuscarOS.TabIndex = 2;
            txtBuscarOS.TextChanged += txtBuscarOS_TextChanged;
            // 
            // lupaPng
            // 
            lupaPng.Image = (Image)resources.GetObject("lupaPng.Image");
            lupaPng.InitialImage = (Image)resources.GetObject("lupaPng.InitialImage");
            lupaPng.Location = new Point(560, 21);
            lupaPng.Margin = new Padding(2);
            lupaPng.Name = "lupaPng";
            lupaPng.Size = new Size(23, 23);
            lupaPng.SizeMode = PictureBoxSizeMode.StretchImage;
            lupaPng.TabIndex = 3;
            lupaPng.TabStop = false;
            // 
            // pacienteBindingSource
            // 
            pacienteBindingSource.DataSource = typeof(Dominio.Paciente);
            // 
            // btnAgregarOS
            // 
            btnAgregarOS.BackColor = SystemColors.MenuHighlight;
            btnAgregarOS.ForeColor = SystemColors.ButtonHighlight;
            btnAgregarOS.Location = new Point(628, 9);
            btnAgregarOS.Margin = new Padding(2);
            btnAgregarOS.Name = "btnAgregarOS";
            btnAgregarOS.Size = new Size(158, 43);
            btnAgregarOS.TabIndex = 4;
            btnAgregarOS.Text = "Agregar OS";
            btnAgregarOS.UseVisualStyleBackColor = false;
            btnAgregarOS.Click += btnAgregarOS_Click;
            // 
            // btnBorrarOS
            // 
            btnBorrarOS.BackColor = Color.Red;
            btnBorrarOS.ForeColor = SystemColors.ButtonHighlight;
            btnBorrarOS.Location = new Point(651, 282);
            btnBorrarOS.Margin = new Padding(2);
            btnBorrarOS.Name = "btnBorrarOS";
            btnBorrarOS.RightToLeft = RightToLeft.No;
            btnBorrarOS.Size = new Size(134, 42);
            btnBorrarOS.TabIndex = 5;
            btnBorrarOS.Text = "Borrar OS";
            btnBorrarOS.UseVisualStyleBackColor = false;
            btnBorrarOS.Click += BtnBorrarOS_Click;
            // 
            // btnEditarOS
            // 
            btnEditarOS.BackColor = Color.YellowGreen;
            btnEditarOS.ForeColor = SystemColors.ButtonHighlight;
            btnEditarOS.Location = new Point(513, 282);
            btnEditarOS.Margin = new Padding(2);
            btnEditarOS.Name = "btnEditarOS";
            btnEditarOS.Size = new Size(134, 42);
            btnEditarOS.TabIndex = 6;
            btnEditarOS.Text = "Editar OS";
            btnEditarOS.UseVisualStyleBackColor = false;
            btnEditarOS.Click += BtnEditarOS_Click;
            // 
            // BtnVolver
            // 
            BtnVolver.BackColor = SystemColors.ActiveCaption;
            BtnVolver.Location = new Point(26, 282);
            BtnVolver.Name = "BtnVolver";
            BtnVolver.Size = new Size(133, 41);
            BtnVolver.TabIndex = 7;
            BtnVolver.Text = "Volver";
            BtnVolver.UseVisualStyleBackColor = false;
            BtnVolver.Click += BtnVolver_Click;
            // 
            // FormHomeOS
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(803, 339);
            Controls.Add(BtnVolver);
            Controls.Add(btnEditarOS);
            Controls.Add(btnBorrarOS);
            Controls.Add(btnAgregarOS);
            Controls.Add(lupaPng);
            Controls.Add(txtBuscarOS);
            Controls.Add(textBox1);
            Controls.Add(dgvFormOS);
            Margin = new Padding(2);
            MinimumSize = new Size(565, 286);
            Name = "FormHomeOS";
            Text = "FormHomeOS";
            WindowState = FormWindowState.Maximized;
            Load += FormHomeOS_Load;
            ((System.ComponentModel.ISupportInitialize)dgvFormOS).EndInit();
            ((System.ComponentModel.ISupportInitialize)lupaPng).EndInit();
            ((System.ComponentModel.ISupportInitialize)pacienteBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvFormOS;
        private TextBox textBox1;
        private TextBox txtBuscarOS;
        private PictureBox lupaPng;
        private BindingSource pacienteBindingSource;
        private Button btnAgregarOS;
        private Button btnBorrarOS;
        private Button btnEditarOS;
        private Button BtnVolver;
    }
}