namespace SmileSoft.UI.Desktop
{
    partial class FormHomeTutor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHomeTutor));
            dgvFormTutor = new DataGridView();
            textBox1 = new TextBox();
            txtBuscarTutor = new TextBox();
            lupaPng = new PictureBox();
            personaBindingSource = new BindingSource(components);
            btnAgregarTutor = new Button();
            btnBorrarTutor = new Button();
            btnEditarTutor = new Button();
            BtnVolver = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvFormTutor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lupaPng).BeginInit();
            ((System.ComponentModel.ISupportInitialize)personaBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dgvFormTutor
            // 
            dgvFormTutor.AllowUserToAddRows = false;
            dgvFormTutor.AllowUserToDeleteRows = false;
            dgvFormTutor.AllowUserToOrderColumns = true;
            dgvFormTutor.BackgroundColor = Color.PapayaWhip;
            dgvFormTutor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFormTutor.Location = new Point(26, 55);
            dgvFormTutor.Margin = new Padding(2);
            dgvFormTutor.Name = "dgvFormTutor";
            dgvFormTutor.ReadOnly = true;
            dgvFormTutor.RowHeadersWidth = 62;
            dgvFormTutor.Size = new Size(759, 223);
            dgvFormTutor.TabIndex = 0;
            dgvFormTutor.SelectionChanged += dgvFormHomeTutor_SelectionChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(525, -118);
            textBox1.Margin = new Padding(2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(517, 23);
            textBox1.TabIndex = 1;
            // 
            // txtBuscarTutor
            // 
            txtBuscarTutor.Location = new Point(26, 21);
            txtBuscarTutor.Margin = new Padding(2);
            txtBuscarTutor.Name = "txtBuscarTutor";
            txtBuscarTutor.Size = new Size(530, 23);
            txtBuscarTutor.TabIndex = 2;
            txtBuscarTutor.TextChanged += txtBuscarTutor_TextChanged;
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
            // personaBindingSource
            // 
            personaBindingSource.DataSource = typeof(Dominio.Persona);
            // 
            // btnAgregarTutor
            // 
            btnAgregarTutor.BackColor = SystemColors.MenuHighlight;
            btnAgregarTutor.ForeColor = SystemColors.ButtonHighlight;
            btnAgregarTutor.Location = new Point(628, 9);
            btnAgregarTutor.Margin = new Padding(2);
            btnAgregarTutor.Name = "btnAgregarTutor";
            btnAgregarTutor.Size = new Size(158, 43);
            btnAgregarTutor.TabIndex = 4;
            btnAgregarTutor.Text = "Agregar tutor";
            btnAgregarTutor.UseVisualStyleBackColor = false;
            btnAgregarTutor.Click += btnAgregarTutor_Click;
            // 
            // btnBorrarTutor
            // 
            btnBorrarTutor.BackColor = Color.Red;
            btnBorrarTutor.ForeColor = SystemColors.ButtonHighlight;
            btnBorrarTutor.Location = new Point(651, 282);
            btnBorrarTutor.Margin = new Padding(2);
            btnBorrarTutor.Name = "btnBorrarTutor";
            btnBorrarTutor.Size = new Size(134, 42);
            btnBorrarTutor.TabIndex = 5;
            btnBorrarTutor.Text = "Borrar Tutor";
            btnBorrarTutor.UseVisualStyleBackColor = false;
            btnBorrarTutor.Click += BtnBorrarTutor_Click;
            // 
            // btnEditarTutor
            // 
            btnEditarTutor.BackColor = Color.YellowGreen;
            btnEditarTutor.ForeColor = SystemColors.ButtonHighlight;
            btnEditarTutor.Location = new Point(513, 282);
            btnEditarTutor.Margin = new Padding(2);
            btnEditarTutor.Name = "btnEditarTutor";
            btnEditarTutor.Size = new Size(134, 42);
            btnEditarTutor.TabIndex = 6;
            btnEditarTutor.Text = "Editar Tutor";
            btnEditarTutor.UseVisualStyleBackColor = false;
            btnEditarTutor.Click += BtnEditarTutor_Click;
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
            // FormHomeTutor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(803, 339);
            Controls.Add(BtnVolver);
            Controls.Add(btnEditarTutor);
            Controls.Add(btnBorrarTutor);
            Controls.Add(btnAgregarTutor);
            Controls.Add(lupaPng);
            Controls.Add(txtBuscarTutor);
            Controls.Add(textBox1);
            Controls.Add(dgvFormTutor);
            Margin = new Padding(2);
            MinimumSize = new Size(565, 286);
            Name = "FormHomeTutor";
            Text = "FormHomePage";
            Load += FormHomeTutor_Load;
            ((System.ComponentModel.ISupportInitialize)dgvFormTutor).EndInit();
            ((System.ComponentModel.ISupportInitialize)lupaPng).EndInit();
            ((System.ComponentModel.ISupportInitialize)personaBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvFormTutor;
        private TextBox textBox1;
        private TextBox txtBuscarTutor;
        private PictureBox lupaPng;
        private BindingSource personaBindingSource;
        private Button btnAgregarTutor;
        private Button btnBorrarTutor;
        private Button btnEditarTutor;
        private Button BtnVolver;
    }
}