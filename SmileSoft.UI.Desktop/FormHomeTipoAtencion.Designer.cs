namespace SmileSoft.UI.Desktop
{
    partial class FormHomeTipoAtencion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHomeTipoAtencion));
            dgvFormTipoAtencion = new DataGridView();
            textBox1 = new TextBox();
            txtBuscarTipoAtencion = new TextBox();
            lupaPng = new PictureBox();
            tipoAtencionBindingSource = new BindingSource(components);
            btnAgregarTipoAtencion = new Button();
            btnBorrarTipoAtencion = new Button();
            btnEditarTipoAtencion = new Button();
            BtnVolver = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvFormTipoAtencion).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lupaPng).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tipoAtencionBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dgvFormTipoAtencion
            // 
            dgvFormTipoAtencion.AccessibleRole = AccessibleRole.None;
            dgvFormTipoAtencion.AllowUserToAddRows = false;
            dgvFormTipoAtencion.AllowUserToDeleteRows = false;
            dgvFormTipoAtencion.AllowUserToOrderColumns = true;
            dgvFormTipoAtencion.BackgroundColor = Color.PapayaWhip;
            dgvFormTipoAtencion.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFormTipoAtencion.Location = new Point(26, 55);
            dgvFormTipoAtencion.Margin = new Padding(2);
            dgvFormTipoAtencion.Name = "dgvFormTipoAtencion";
            dgvFormTipoAtencion.ReadOnly = true;
            dgvFormTipoAtencion.RowHeadersWidth = 62;
            dgvFormTipoAtencion.Size = new Size(759, 223);
            dgvFormTipoAtencion.TabIndex = 0;
            dgvFormTipoAtencion.SelectionChanged += dgvFormHomeTipoAtencion_SelectionChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(525, -118);
            textBox1.Margin = new Padding(2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(517, 23);
            textBox1.TabIndex = 1;
            // 
            // txtBuscarTipoAtencion
            // 
            txtBuscarTipoAtencion.Location = new Point(26, 21);
            txtBuscarTipoAtencion.Margin = new Padding(2);
            txtBuscarTipoAtencion.Name = "txtBuscarTipoAtencion";
            txtBuscarTipoAtencion.Size = new Size(530, 23);
            txtBuscarTipoAtencion.TabIndex = 2;
            txtBuscarTipoAtencion.TextChanged += txtBuscarTipoAtencion_TextChanged;
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
            // tipoAtencionBindingSource
            // 
            tipoAtencionBindingSource.DataSource = typeof(Dominio.TipoAtencion);
            // 
            // btnAgregarTipoAtencion
            // 
            btnAgregarTipoAtencion.BackColor = SystemColors.MenuHighlight;
            btnAgregarTipoAtencion.ForeColor = SystemColors.ButtonHighlight;
            btnAgregarTipoAtencion.Location = new Point(627, 1);
            btnAgregarTipoAtencion.Margin = new Padding(2);
            btnAgregarTipoAtencion.Name = "btnAgregarTipoAtencion";
            btnAgregarTipoAtencion.Size = new Size(158, 60);
            btnAgregarTipoAtencion.TabIndex = 4;
            btnAgregarTipoAtencion.Text = "Agregar tipo atencion";
            btnAgregarTipoAtencion.UseVisualStyleBackColor = false;
            btnAgregarTipoAtencion.Click += btnAgregarTipoAtencion_Click;
            // 
            // btnBorrarTipoAtencion
            // 
            btnBorrarTipoAtencion.BackColor = Color.Red;
            btnBorrarTipoAtencion.ForeColor = SystemColors.ButtonHighlight;
            btnBorrarTipoAtencion.Location = new Point(651, 282);
            btnBorrarTipoAtencion.Margin = new Padding(2);
            btnBorrarTipoAtencion.Name = "btnBorrarTipoAtencion";
            btnBorrarTipoAtencion.RightToLeft = RightToLeft.No;
            btnBorrarTipoAtencion.Size = new Size(134, 56);
            btnBorrarTipoAtencion.TabIndex = 5;
            btnBorrarTipoAtencion.Text = "Borrar Tipo Atencion";
            btnBorrarTipoAtencion.UseVisualStyleBackColor = false;
            btnBorrarTipoAtencion.Click += BtnBorrarTipoAtencion_Click;
            // 
            // btnEditarTipoAtencion
            // 
            btnEditarTipoAtencion.BackColor = Color.YellowGreen;
            btnEditarTipoAtencion.ForeColor = SystemColors.ButtonHighlight;
            btnEditarTipoAtencion.Location = new Point(513, 282);
            btnEditarTipoAtencion.Margin = new Padding(2);
            btnEditarTipoAtencion.Name = "btnEditarTipoAtencion";
            btnEditarTipoAtencion.Size = new Size(134, 56);
            btnEditarTipoAtencion.TabIndex = 6;
            btnEditarTipoAtencion.Text = "Editar Tipo Atencion";
            btnEditarTipoAtencion.UseVisualStyleBackColor = false;
            btnEditarTipoAtencion.Click += BtnEditarTipoAtencion_Click;
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
            // FormHomeTipoAtencion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(803, 339);
            Controls.Add(BtnVolver);
            Controls.Add(btnEditarTipoAtencion);
            Controls.Add(btnBorrarTipoAtencion);
            Controls.Add(btnAgregarTipoAtencion);
            Controls.Add(lupaPng);
            Controls.Add(txtBuscarTipoAtencion);
            Controls.Add(textBox1);
            Controls.Add(dgvFormTipoAtencion);
            Margin = new Padding(2);
            MinimumSize = new Size(565, 286);
            Name = "FormHomeTipoAtencion";
            Text = "FormHomeTipoAtencion";
            Load += FormHomeTipoAtencion_Load;
            ((System.ComponentModel.ISupportInitialize)dgvFormTipoAtencion).EndInit();
            ((System.ComponentModel.ISupportInitialize)lupaPng).EndInit();
            ((System.ComponentModel.ISupportInitialize)tipoAtencionBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvFormTipoAtencion;
        private TextBox textBox1;
        private TextBox txtBuscarTipoAtencion;
        private PictureBox lupaPng;
        private BindingSource tipoAtencionBindingSource;
        private Button btnAgregarTipoAtencion;
        private Button btnBorrarTipoAtencion;
        private Button btnEditarTipoAtencion;
        private Button BtnVolver;
    }
}