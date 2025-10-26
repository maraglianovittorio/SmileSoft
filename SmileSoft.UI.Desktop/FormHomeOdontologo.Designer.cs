namespace SmileSoft.UI.Desktop
{
    partial class FormHomeOdontologo
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
            dgvFormOdontologo = new DataGridView();
            textBox1 = new TextBox();
            txtBuscarOdontologo = new TextBox();
            lupaPng = new PictureBox();
            odontologoBindingSource = new BindingSource(components);
            btnAgregarOdontologo = new Button();
            btnBorrarOdontologo = new Button();
            btnEditarOdontologo = new Button();
            btnVolver = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvFormOdontologo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lupaPng).BeginInit();
            ((System.ComponentModel.ISupportInitialize)odontologoBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dgvFormOdontologo
            // 
            dgvFormOdontologo.AllowUserToAddRows = false;
            dgvFormOdontologo.AllowUserToDeleteRows = false;
            dgvFormOdontologo.AllowUserToOrderColumns = true;
            dgvFormOdontologo.BackgroundColor = Color.PapayaWhip;
            dgvFormOdontologo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFormOdontologo.Location = new Point(26, 55);
            dgvFormOdontologo.Margin = new Padding(2);
            dgvFormOdontologo.Name = "dgvFormOdontologo";
            dgvFormOdontologo.ReadOnly = true;
            dgvFormOdontologo.RowHeadersWidth = 62;
            dgvFormOdontologo.Size = new Size(759, 223);
            dgvFormOdontologo.TabIndex = 0;
            dgvFormOdontologo.CellContentClick += dgvFormOdontologo_CellContentClick;
            dgvFormOdontologo.SelectionChanged += dgvFormHomeOdontologo_SelectionChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(525, -118);
            textBox1.Margin = new Padding(2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(517, 23);
            textBox1.TabIndex = 1;
            // 
            // txtBuscarOdontologo
            // 
            txtBuscarOdontologo.Location = new Point(26, 21);
            txtBuscarOdontologo.Margin = new Padding(2);
            txtBuscarOdontologo.Name = "txtBuscarOdontologo";
            txtBuscarOdontologo.Size = new Size(530, 23);
            txtBuscarOdontologo.TabIndex = 2;
            txtBuscarOdontologo.TextChanged += txtBuscarOdontologo_TextChanged;
            // 
            // lupaPng
            // 
            lupaPng.InitialImage = null;
            lupaPng.Location = new Point(560, 21);
            lupaPng.Margin = new Padding(2);
            lupaPng.Name = "lupaPng";
            lupaPng.Size = new Size(23, 23);
            lupaPng.SizeMode = PictureBoxSizeMode.StretchImage;
            lupaPng.TabIndex = 3;
            lupaPng.TabStop = false;
            // 
            // odontologoBindingSource
            // 
            odontologoBindingSource.DataSource = typeof(Dominio.Odontologo);
            // 
            // btnAgregarOdontologo
            // 
            btnAgregarOdontologo.BackColor = SystemColors.MenuHighlight;
            btnAgregarOdontologo.ForeColor = SystemColors.ButtonHighlight;
            btnAgregarOdontologo.Location = new Point(628, -1);
            btnAgregarOdontologo.Margin = new Padding(2);
            btnAgregarOdontologo.Name = "btnAgregarOdontologo";
            btnAgregarOdontologo.Size = new Size(164, 52);
            btnAgregarOdontologo.TabIndex = 4;
            btnAgregarOdontologo.Text = "Agregar Odontólogo";
            btnAgregarOdontologo.UseVisualStyleBackColor = false;
            btnAgregarOdontologo.Click += btnAgregarOdontologo_Click;
            // 
            // btnBorrarOdontologo
            // 
            btnBorrarOdontologo.BackColor = Color.Red;
            btnBorrarOdontologo.ForeColor = SystemColors.ButtonHighlight;
            btnBorrarOdontologo.Location = new Point(651, 282);
            btnBorrarOdontologo.Margin = new Padding(2);
            btnBorrarOdontologo.Name = "btnBorrarOdontologo";
            btnBorrarOdontologo.Size = new Size(141, 55);
            btnBorrarOdontologo.TabIndex = 5;
            btnBorrarOdontologo.Text = "Borrar Odontólogo";
            btnBorrarOdontologo.UseVisualStyleBackColor = false;
            btnBorrarOdontologo.Click += btnBorrarOdontologo_Click;
            // 
            // btnEditarOdontologo
            // 
            btnEditarOdontologo.BackColor = Color.YellowGreen;
            btnEditarOdontologo.ForeColor = SystemColors.ButtonHighlight;
            btnEditarOdontologo.Location = new Point(500, 282);
            btnEditarOdontologo.Margin = new Padding(2);
            btnEditarOdontologo.Name = "btnEditarOdontologo";
            btnEditarOdontologo.Size = new Size(147, 55);
            btnEditarOdontologo.TabIndex = 6;
            btnEditarOdontologo.Text = "Editar Odontólogo";
            btnEditarOdontologo.UseVisualStyleBackColor = false;
            btnEditarOdontologo.Click += btnEditarOdontologo_Click;
            // 
            // btnVolver
            // 
            btnVolver.BackColor = SystemColors.ActiveCaption;
            btnVolver.Location = new Point(26, 282);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(133, 41);
            btnVolver.TabIndex = 7;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // FormHomeOdontologo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(803, 339);
            Controls.Add(btnVolver);
            Controls.Add(btnEditarOdontologo);
            Controls.Add(btnBorrarOdontologo);
            Controls.Add(btnAgregarOdontologo);
            Controls.Add(lupaPng);
            Controls.Add(txtBuscarOdontologo);
            Controls.Add(textBox1);
            Controls.Add(dgvFormOdontologo);
            Margin = new Padding(2);
            MinimumSize = new Size(565, 286);
            Name = "FormHomeOdontologo";
            Text = "FormHomeOdontologo";
            WindowState = FormWindowState.Maximized;
            Load += FormHomeOdontologo_Load;
            ((System.ComponentModel.ISupportInitialize)dgvFormOdontologo).EndInit();
            ((System.ComponentModel.ISupportInitialize)lupaPng).EndInit();
            ((System.ComponentModel.ISupportInitialize)odontologoBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvFormOdontologo;
        private TextBox textBox1;
        private TextBox txtBuscarOdontologo;
        private PictureBox lupaPng;
        private BindingSource odontologoBindingSource;
        private Button btnAgregarOdontologo;
        private Button btnBorrarOdontologo;
        private Button btnEditarOdontologo;
        private Button btnVolver;
    }
}