namespace SmileSoft.UI.Desktop
{
    partial class FormHomeTipoPlan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHomeTipoPlan));
            dgvFormTipoPlan = new DataGridView();
            textBox1 = new TextBox();
            txtBuscarTipoPlan = new TextBox();
            lupaPng = new PictureBox();
            tipoPlanBindingSource = new BindingSource(components);
            btnAgregarTipoPlan = new Button();
            btnBorrarTipoPlan = new Button();
            btnEditarTipoPlan = new Button();
            BtnVolver = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvFormTipoPlan).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lupaPng).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tipoPlanBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dgvFormTipoPlan
            // 
            dgvFormTipoPlan.AccessibleRole = AccessibleRole.None;
            dgvFormTipoPlan.AllowUserToAddRows = false;
            dgvFormTipoPlan.AllowUserToDeleteRows = false;
            dgvFormTipoPlan.AllowUserToOrderColumns = true;
            dgvFormTipoPlan.BackgroundColor = Color.PapayaWhip;
            dgvFormTipoPlan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFormTipoPlan.Location = new Point(26, 55);
            dgvFormTipoPlan.Margin = new Padding(2);
            dgvFormTipoPlan.Name = "dgvFormTipoPlan";
            dgvFormTipoPlan.ReadOnly = true;
            dgvFormTipoPlan.RowHeadersWidth = 62;
            dgvFormTipoPlan.Size = new Size(759, 223);
            dgvFormTipoPlan.TabIndex = 0;
            dgvFormTipoPlan.SelectionChanged += dgvFormHomeTipoPlan_SelectionChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(525, -118);
            textBox1.Margin = new Padding(2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(517, 23);
            textBox1.TabIndex = 1;
            // 
            // txtBuscarTipoPlan
            // 
            txtBuscarTipoPlan.Location = new Point(26, 21);
            txtBuscarTipoPlan.Margin = new Padding(2);
            txtBuscarTipoPlan.Name = "txtBuscarTipoPlan";
            txtBuscarTipoPlan.Size = new Size(530, 23);
            txtBuscarTipoPlan.TabIndex = 2;
            txtBuscarTipoPlan.TextChanged += txtBuscarTipoPlan_TextChanged;
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
            // tipoPlanBindingSource
            // 
            tipoPlanBindingSource.DataSource = typeof(Dominio.TipoPlan);
            // 
            // btnAgregarTipoPlan
            // 
            btnAgregarTipoPlan.BackColor = SystemColors.MenuHighlight;
            btnAgregarTipoPlan.ForeColor = SystemColors.ButtonHighlight;
            btnAgregarTipoPlan.Location = new Point(628, 9);
            btnAgregarTipoPlan.Margin = new Padding(2);
            btnAgregarTipoPlan.Name = "btnAgregarTipoPlan";
            btnAgregarTipoPlan.Size = new Size(158, 43);
            btnAgregarTipoPlan.TabIndex = 4;
            btnAgregarTipoPlan.Text = "Agregar tipo plan";
            btnAgregarTipoPlan.UseVisualStyleBackColor = false;
            btnAgregarTipoPlan.Click += btnAgregarTipoPlan_Click;
            // 
            // btnBorrarTipoPlan
            // 
            btnBorrarTipoPlan.BackColor = Color.Red;
            btnBorrarTipoPlan.ForeColor = SystemColors.ButtonHighlight;
            btnBorrarTipoPlan.Location = new Point(651, 282);
            btnBorrarTipoPlan.Margin = new Padding(2);
            btnBorrarTipoPlan.Name = "btnBorrarTipoPlan";
            btnBorrarTipoPlan.RightToLeft = RightToLeft.No;
            btnBorrarTipoPlan.Size = new Size(134, 42);
            btnBorrarTipoPlan.TabIndex = 5;
            btnBorrarTipoPlan.Text = "Borrar Tipo Plan";
            btnBorrarTipoPlan.UseVisualStyleBackColor = false;
            btnBorrarTipoPlan.Click += BtnBorrarTipoPlan_Click;
            // 
            // btnEditarTipoPlan
            // 
            btnEditarTipoPlan.BackColor = Color.YellowGreen;
            btnEditarTipoPlan.ForeColor = SystemColors.ButtonHighlight;
            btnEditarTipoPlan.Location = new Point(513, 282);
            btnEditarTipoPlan.Margin = new Padding(2);
            btnEditarTipoPlan.Name = "btnEditarTipoPlan";
            btnEditarTipoPlan.Size = new Size(134, 42);
            btnEditarTipoPlan.TabIndex = 6;
            btnEditarTipoPlan.Text = "Editar Tipo Plan";
            btnEditarTipoPlan.UseVisualStyleBackColor = false;
            btnEditarTipoPlan.Click += BtnEditarTipoPlan_Click;
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
            // FormHomeTipoPlan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(803, 339);
            Controls.Add(BtnVolver);
            Controls.Add(btnEditarTipoPlan);
            Controls.Add(btnBorrarTipoPlan);
            Controls.Add(btnAgregarTipoPlan);
            Controls.Add(lupaPng);
            Controls.Add(txtBuscarTipoPlan);
            Controls.Add(textBox1);
            Controls.Add(dgvFormTipoPlan);
            Margin = new Padding(2);
            MinimumSize = new Size(565, 286);
            Name = "FormHomeTipoPlan";
            Text = "FormHomeTipoPlan";
            Load += FormHomeTipoPlan_Load;
            ((System.ComponentModel.ISupportInitialize)dgvFormTipoPlan).EndInit();
            ((System.ComponentModel.ISupportInitialize)lupaPng).EndInit();
            ((System.ComponentModel.ISupportInitialize)tipoPlanBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvFormTipoPlan;
        private TextBox textBox1;
        private TextBox txtBuscarTipoPlan;
        private PictureBox lupaPng;
        private BindingSource tipoPlanBindingSource;
        private Button btnAgregarTipoPlan;
        private Button btnBorrarTipoPlan;
        private Button btnEditarTipoPlan;
        private Button BtnVolver;
    }
}