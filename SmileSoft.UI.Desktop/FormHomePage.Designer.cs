namespace SmileSoft.UI.Desktop
{
    partial class FormHomePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHomePage));
            dgvFormHome = new DataGridView();
            textBox1 = new TextBox();
            txtBuscarPaciente = new TextBox();
            lupaPng = new PictureBox();
            pacienteBindingSource = new BindingSource(components);
            pacienteBindingSource1 = new BindingSource(components);
            btnAgregarPaciente = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvFormHome).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lupaPng).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pacienteBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pacienteBindingSource1).BeginInit();
            SuspendLayout();
            // 
            // dgvFormHome
            // 
            dgvFormHome.AllowUserToAddRows = false;
            dgvFormHome.AllowUserToDeleteRows = false;
            dgvFormHome.AllowUserToOrderColumns = true;
            dgvFormHome.BackgroundColor = Color.PapayaWhip;
            dgvFormHome.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFormHome.Location = new Point(12, 81);
            dgvFormHome.Name = "dgvFormHome";
            dgvFormHome.ReadOnly = true;
            dgvFormHome.RowHeadersWidth = 62;
            dgvFormHome.Size = new Size(1102, 441);
            dgvFormHome.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(750, -197);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(737, 31);
            textBox1.TabIndex = 1;
            // 
            // txtBuscarPaciente
            // 
            txtBuscarPaciente.Location = new Point(12, 22);
            txtBuscarPaciente.Name = "txtBuscarPaciente";
            txtBuscarPaciente.Size = new Size(756, 31);
            txtBuscarPaciente.TabIndex = 2;
            txtBuscarPaciente.TextChanged += txtBuscarPaciente_TextChanged;
            // 
            // lupaPng
            // 
            lupaPng.Image = (Image)resources.GetObject("lupaPng.Image");
            lupaPng.InitialImage = (Image)resources.GetObject("lupaPng.InitialImage");
            lupaPng.Location = new Point(774, 22);
            lupaPng.Name = "lupaPng";
            lupaPng.Size = new Size(38, 33);
            lupaPng.SizeMode = PictureBoxSizeMode.StretchImage;
            lupaPng.TabIndex = 3;
            lupaPng.TabStop = false;
            // 
            // pacienteBindingSource
            // 
            pacienteBindingSource.DataSource = typeof(Dominio.Paciente);
            // 
            // pacienteBindingSource1
            // 
            pacienteBindingSource1.DataSource = typeof(Dominio.Paciente);
            // 
            // btnAgregarPaciente
            // 
            btnAgregarPaciente.BackColor = SystemColors.MenuHighlight;
            btnAgregarPaciente.ForeColor = SystemColors.ButtonHighlight;
            btnAgregarPaciente.Location = new Point(871, 2);
            btnAgregarPaciente.Name = "btnAgregarPaciente";
            btnAgregarPaciente.Size = new Size(225, 71);
            btnAgregarPaciente.TabIndex = 4;
            btnAgregarPaciente.Text = "Agregar paciente";
            btnAgregarPaciente.UseVisualStyleBackColor = false;
            btnAgregarPaciente.Click += btnAgregarPaciente_Click;
            // 
            // FormHomePage
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1126, 521);
            Controls.Add(btnAgregarPaciente);
            Controls.Add(lupaPng);
            Controls.Add(txtBuscarPaciente);
            Controls.Add(textBox1);
            Controls.Add(dgvFormHome);
            MinimumSize = new Size(800, 450);
            Name = "FormHomePage";
            Text = "FormHomePage";
            Load += FormHomePage_Load;
            ((System.ComponentModel.ISupportInitialize)dgvFormHome).EndInit();
            ((System.ComponentModel.ISupportInitialize)lupaPng).EndInit();
            ((System.ComponentModel.ISupportInitialize)pacienteBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)pacienteBindingSource1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvFormHome;
        private TextBox textBox1;
        private TextBox txtBuscarPaciente;
        private PictureBox lupaPng;
        private BindingSource pacienteBindingSource1;
        private BindingSource pacienteBindingSource;
        private Button btnAgregarPaciente;
    }
}