namespace SmileSoft.UI.Desktop
{
    partial class FormHomePaciente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHomePaciente));
            dgvFormPaciente = new DataGridView();
            textBox1 = new TextBox();
            txtBuscarPaciente = new TextBox();
            lupaPng = new PictureBox();
            pacienteBindingSource = new BindingSource(components);
            btnAgregarPaciente = new Button();
            btnBorrarPaciente = new Button();
            btnEditarPaciente = new Button();
            BtnVolver = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvFormPaciente).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lupaPng).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pacienteBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dgvFormPaciente
            // 
            dgvFormPaciente.AllowUserToAddRows = false;
            dgvFormPaciente.AllowUserToDeleteRows = false;
            dgvFormPaciente.AllowUserToOrderColumns = true;
            dgvFormPaciente.BackgroundColor = Color.PapayaWhip;
            dgvFormPaciente.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFormPaciente.Location = new Point(26, 55);
            dgvFormPaciente.Margin = new Padding(2);
            dgvFormPaciente.Name = "dgvFormPaciente";
            dgvFormPaciente.ReadOnly = true;
            dgvFormPaciente.RowHeadersWidth = 62;
            dgvFormPaciente.Size = new Size(759, 223);
            dgvFormPaciente.TabIndex = 0;
            dgvFormPaciente.SelectionChanged += dgvFormHome_SelectionChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(525, -118);
            textBox1.Margin = new Padding(2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(517, 23);
            textBox1.TabIndex = 1;
            // 
            // txtBuscarPaciente
            // 
            txtBuscarPaciente.Location = new Point(26, 21);
            txtBuscarPaciente.Margin = new Padding(2);
            txtBuscarPaciente.Name = "txtBuscarPaciente";
            txtBuscarPaciente.Size = new Size(530, 23);
            txtBuscarPaciente.TabIndex = 2;
            txtBuscarPaciente.TextChanged += txtBuscarPaciente_TextChanged;
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
            // btnAgregarPaciente
            // 
            btnAgregarPaciente.BackColor = SystemColors.MenuHighlight;
            btnAgregarPaciente.ForeColor = SystemColors.ButtonHighlight;
            btnAgregarPaciente.Location = new Point(628, 9);
            btnAgregarPaciente.Margin = new Padding(2);
            btnAgregarPaciente.Name = "btnAgregarPaciente";
            btnAgregarPaciente.Size = new Size(158, 43);
            btnAgregarPaciente.TabIndex = 4;
            btnAgregarPaciente.Text = "Agregar paciente";
            btnAgregarPaciente.UseVisualStyleBackColor = false;
            btnAgregarPaciente.Click += btnAgregarPaciente_Click;
            // 
            // btnBorrarPaciente
            // 
            btnBorrarPaciente.BackColor = Color.Red;
            btnBorrarPaciente.ForeColor = SystemColors.ButtonHighlight;
            btnBorrarPaciente.Location = new Point(651, 282);
            btnBorrarPaciente.Margin = new Padding(2);
            btnBorrarPaciente.Name = "btnBorrarPaciente";
            btnBorrarPaciente.Size = new Size(134, 42);
            btnBorrarPaciente.TabIndex = 5;
            btnBorrarPaciente.Text = "Borrar Paciente";
            btnBorrarPaciente.UseVisualStyleBackColor = false;
            btnBorrarPaciente.Click += BtnBorrarPaciente_Click;
            // 
            // btnEditarPaciente
            // 
            btnEditarPaciente.BackColor = Color.YellowGreen;
            btnEditarPaciente.ForeColor = SystemColors.ButtonHighlight;
            btnEditarPaciente.Location = new Point(513, 282);
            btnEditarPaciente.Margin = new Padding(2);
            btnEditarPaciente.Name = "btnEditarPaciente";
            btnEditarPaciente.Size = new Size(134, 42);
            btnEditarPaciente.TabIndex = 6;
            btnEditarPaciente.Text = "Editar Paciente";
            btnEditarPaciente.UseVisualStyleBackColor = false;
            btnEditarPaciente.Click += BtnEditarPaciente_Click;
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
            // FormHomePaciente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(803, 339);
            Controls.Add(BtnVolver);
            Controls.Add(btnEditarPaciente);
            Controls.Add(btnBorrarPaciente);
            Controls.Add(btnAgregarPaciente);
            Controls.Add(lupaPng);
            Controls.Add(txtBuscarPaciente);
            Controls.Add(textBox1);
            Controls.Add(dgvFormPaciente);
            Margin = new Padding(2);
            MinimumSize = new Size(565, 286);
            Name = "FormHomePaciente";
            Text = "FormHomePage";
            Load += FormHomePage_Load;
            ((System.ComponentModel.ISupportInitialize)dgvFormPaciente).EndInit();
            ((System.ComponentModel.ISupportInitialize)lupaPng).EndInit();
            ((System.ComponentModel.ISupportInitialize)pacienteBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvFormPaciente;
        private TextBox textBox1;
        private TextBox txtBuscarPaciente;
        private PictureBox lupaPng;
        private BindingSource pacienteBindingSource;
        private Button btnAgregarPaciente;
        private Button btnBorrarPaciente;
        private Button btnEditarPaciente;
        private Button BtnVolver;
    }
}