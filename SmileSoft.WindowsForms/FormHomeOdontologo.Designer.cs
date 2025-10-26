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
            dgvFormOdontologo.Location = new Point(33, 77);
            dgvFormOdontologo.Name = "dgvFormOdontologo";
            dgvFormOdontologo.ReadOnly = true;
            dgvFormOdontologo.RowHeadersWidth = 62;
            dgvFormOdontologo.Size = new Size(976, 312);
            dgvFormOdontologo.TabIndex = 0;
            dgvFormOdontologo.CellContentClick += dgvFormOdontologo_CellContentClick;
            dgvFormOdontologo.SelectionChanged += dgvFormHomeOdontologo_SelectionChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(675, -165);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(664, 29);
            textBox1.TabIndex = 1;
            // 
            // txtBuscarOdontologo
            // 
            txtBuscarOdontologo.Location = new Point(33, 29);
            txtBuscarOdontologo.Name = "txtBuscarOdontologo";
            txtBuscarOdontologo.Size = new Size(680, 29);
            txtBuscarOdontologo.TabIndex = 2;
            txtBuscarOdontologo.TextChanged += txtBuscarOdontologo_TextChanged;
            // 
            // lupaPng
            // 
            lupaPng.InitialImage = null;
            lupaPng.Location = new Point(720, 29);
            lupaPng.Name = "lupaPng";
            lupaPng.Size = new Size(30, 32);
            lupaPng.SizeMode = PictureBoxSizeMode.StretchImage;
            lupaPng.TabIndex = 3;
            lupaPng.TabStop = false;
            // 
            // btnAgregarOdontologo
            // 
            btnAgregarOdontologo.BackColor = SystemColors.MenuHighlight;
            btnAgregarOdontologo.ForeColor = SystemColors.ButtonHighlight;
            btnAgregarOdontologo.Location = new Point(807, -1);
            btnAgregarOdontologo.Name = "btnAgregarOdontologo";
            btnAgregarOdontologo.Size = new Size(211, 73);
            btnAgregarOdontologo.TabIndex = 4;
            btnAgregarOdontologo.Text = "Agregar Odontólogo";
            btnAgregarOdontologo.UseVisualStyleBackColor = false;
            btnAgregarOdontologo.Click += btnAgregarOdontologo_Click;
            // 
            // btnBorrarOdontologo
            // 
            btnBorrarOdontologo.BackColor = Color.Red;
            btnBorrarOdontologo.ForeColor = SystemColors.ButtonHighlight;
            btnBorrarOdontologo.Location = new Point(837, 395);
            btnBorrarOdontologo.Name = "btnBorrarOdontologo";
            btnBorrarOdontologo.Size = new Size(181, 77);
            btnBorrarOdontologo.TabIndex = 5;
            btnBorrarOdontologo.Text = "Borrar Odontólogo";
            btnBorrarOdontologo.UseVisualStyleBackColor = false;
            btnBorrarOdontologo.Click += btnBorrarOdontologo_Click;
            // 
            // btnEditarOdontologo
            // 
            btnEditarOdontologo.BackColor = Color.YellowGreen;
            btnEditarOdontologo.ForeColor = SystemColors.ButtonHighlight;
            btnEditarOdontologo.Location = new Point(643, 395);
            btnEditarOdontologo.Name = "btnEditarOdontologo";
            btnEditarOdontologo.Size = new Size(189, 77);
            btnEditarOdontologo.TabIndex = 6;
            btnEditarOdontologo.Text = "Editar Odontólogo";
            btnEditarOdontologo.UseVisualStyleBackColor = false;
            btnEditarOdontologo.Click += btnEditarOdontologo_Click;
            // 
            // btnVolver
            // 
            btnVolver.BackColor = SystemColors.ActiveCaption;
            btnVolver.Location = new Point(33, 395);
            btnVolver.Margin = new Padding(4, 4, 4, 4);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(171, 57);
            btnVolver.TabIndex = 7;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // FormHomeOdontologo
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1072, 645);
            Controls.Add(btnVolver);
            Controls.Add(btnEditarOdontologo);
            Controls.Add(btnBorrarOdontologo);
            Controls.Add(btnAgregarOdontologo);
            Controls.Add(lupaPng);
            Controls.Add(txtBuscarOdontologo);
            Controls.Add(textBox1);
            Controls.Add(dgvFormOdontologo);
            Font = new Font("Segoe UI", 12F);
            MinimumSize = new Size(722, 385);
            Name = "FormHomeOdontologo";
            StartPosition = FormStartPosition.CenterScreen;
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