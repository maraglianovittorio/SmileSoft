namespace SmileSoft.UI.Desktop
{
    partial class FormHomeAtencion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHomeAtencion));
            dgvFormAtencion = new DataGridView();
            textBox1 = new TextBox();
            txtBuscarAtencion = new TextBox();
            lupaPng = new PictureBox();
            atencionBindingSource = new BindingSource(components);
            btnAgregarAtencion = new Button();
            btnCancelarAtencion = new Button();
            btnEditarAtencion = new Button();
            BtnVolver = new Button();
            btnFiltros = new Button();
            pnlFiltros = new Panel();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvFormAtencion).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lupaPng).BeginInit();
            ((System.ComponentModel.ISupportInitialize)atencionBindingSource).BeginInit();
            pnlFiltros.SuspendLayout();
            SuspendLayout();
            // 
            // dgvFormAtencion
            // 
            dgvFormAtencion.AllowUserToAddRows = false;
            dgvFormAtencion.AllowUserToDeleteRows = false;
            dgvFormAtencion.AllowUserToOrderColumns = true;
            dgvFormAtencion.BackgroundColor = Color.PapayaWhip;
            dgvFormAtencion.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFormAtencion.Location = new Point(26, 48);
            dgvFormAtencion.Margin = new Padding(2);
            dgvFormAtencion.Name = "dgvFormAtencion";
            dgvFormAtencion.ReadOnly = true;
            dgvFormAtencion.RowHeadersWidth = 62;
            dgvFormAtencion.Size = new Size(806, 269);
            dgvFormAtencion.TabIndex = 0;
            dgvFormAtencion.SelectionChanged += dgvFormHomeAtenciones_SelectionChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(525, -118);
            textBox1.Margin = new Padding(2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(517, 23);
            textBox1.TabIndex = 1;
            // 
            // txtBuscarAtencion
            // 
            txtBuscarAtencion.Location = new Point(26, 21);
            txtBuscarAtencion.Margin = new Padding(2);
            txtBuscarAtencion.Name = "txtBuscarAtencion";
            txtBuscarAtencion.Size = new Size(394, 23);
            txtBuscarAtencion.TabIndex = 2;
            txtBuscarAtencion.TextChanged += txtBuscarAtencion_TextChanged;
            // 
            // lupaPng
            // 
            lupaPng.Image = (Image)resources.GetObject("lupaPng.Image");
            lupaPng.InitialImage = (Image)resources.GetObject("lupaPng.InitialImage");
            lupaPng.Location = new Point(434, 21);
            lupaPng.Margin = new Padding(2);
            lupaPng.Name = "lupaPng";
            lupaPng.Size = new Size(23, 23);
            lupaPng.SizeMode = PictureBoxSizeMode.StretchImage;
            lupaPng.TabIndex = 3;
            lupaPng.TabStop = false;
            // 
            // atencionBindingSource
            // 
            atencionBindingSource.DataSource = typeof(Dominio.Atencion);
            // 
            // btnAgregarAtencion
            // 
            btnAgregarAtencion.BackColor = SystemColors.MenuHighlight;
            btnAgregarAtencion.ForeColor = SystemColors.ButtonHighlight;
            btnAgregarAtencion.Location = new Point(674, 1);
            btnAgregarAtencion.Margin = new Padding(2);
            btnAgregarAtencion.Name = "btnAgregarAtencion";
            btnAgregarAtencion.Size = new Size(158, 43);
            btnAgregarAtencion.TabIndex = 4;
            btnAgregarAtencion.Text = "Agregar atencion";
            btnAgregarAtencion.UseVisualStyleBackColor = false;
            btnAgregarAtencion.Click += btnAgregarAtencion_Click;
            // 
            // btnCancelarAtencion
            // 
            btnCancelarAtencion.BackColor = Color.Red;
            btnCancelarAtencion.ForeColor = SystemColors.ButtonHighlight;
            btnCancelarAtencion.Location = new Point(698, 321);
            btnCancelarAtencion.Margin = new Padding(2);
            btnCancelarAtencion.Name = "btnCancelarAtencion";
            btnCancelarAtencion.Size = new Size(134, 42);
            btnCancelarAtencion.TabIndex = 5;
            btnCancelarAtencion.Text = "Cancelar atencion";
            btnCancelarAtencion.UseVisualStyleBackColor = false;
            btnCancelarAtencion.Click += BtnBorrarAtencion_Click;
            // 
            // btnEditarAtencion
            // 
            btnEditarAtencion.BackColor = Color.YellowGreen;
            btnEditarAtencion.ForeColor = SystemColors.ButtonHighlight;
            btnEditarAtencion.Location = new Point(535, 321);
            btnEditarAtencion.Margin = new Padding(2);
            btnEditarAtencion.Name = "btnEditarAtencion";
            btnEditarAtencion.Size = new Size(134, 42);
            btnEditarAtencion.TabIndex = 6;
            btnEditarAtencion.Text = "Editar atencion";
            btnEditarAtencion.UseVisualStyleBackColor = false;
            btnEditarAtencion.Click += BtnEditarAtencion_Click;
            // 
            // BtnVolver
            // 
            BtnVolver.BackColor = SystemColors.ActiveCaption;
            BtnVolver.Location = new Point(26, 322);
            BtnVolver.Name = "BtnVolver";
            BtnVolver.Size = new Size(133, 41);
            BtnVolver.TabIndex = 7;
            BtnVolver.Text = "Volver";
            BtnVolver.UseVisualStyleBackColor = false;
            BtnVolver.Click += BtnVolver_Click;
            // 
            // btnFiltros
            // 
            btnFiltros.Location = new Point(579, 1);
            btnFiltros.Name = "btnFiltros";
            btnFiltros.Size = new Size(90, 43);
            btnFiltros.TabIndex = 8;
            btnFiltros.Text = "Filtros";
            btnFiltros.UseVisualStyleBackColor = true;
            btnFiltros.Click += btnFiltros_Click;
            // 
            // pnlFiltros
            // 
            pnlFiltros.BorderStyle = BorderStyle.FixedSingle;
            pnlFiltros.Controls.Add(button1);
            pnlFiltros.Location = new Point(579, 59);
            pnlFiltros.Name = "pnlFiltros";
            pnlFiltros.Size = new Size(272, 95);
            pnlFiltros.TabIndex = 9;
            pnlFiltros.Visible = false;
            // 
            // button1
            // 
            button1.Location = new Point(29, 15);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // FormHomeAtencion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(977, 558);
            Controls.Add(pnlFiltros);
            Controls.Add(btnFiltros);
            Controls.Add(BtnVolver);
            Controls.Add(btnEditarAtencion);
            Controls.Add(btnCancelarAtencion);
            Controls.Add(btnAgregarAtencion);
            Controls.Add(lupaPng);
            Controls.Add(txtBuscarAtencion);
            Controls.Add(textBox1);
            Controls.Add(dgvFormAtencion);
            Margin = new Padding(2);
            MinimumSize = new Size(565, 286);
            Name = "FormHomeAtencion";
            Text = "FormHomePage";
            Load += FormHomeAtenciones_Load;
            ((System.ComponentModel.ISupportInitialize)dgvFormAtencion).EndInit();
            ((System.ComponentModel.ISupportInitialize)lupaPng).EndInit();
            ((System.ComponentModel.ISupportInitialize)atencionBindingSource).EndInit();
            pnlFiltros.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvFormAtencion;
        private TextBox textBox1;
        private TextBox txtBuscarAtencion;
        private PictureBox lupaPng;
        private BindingSource atencionBindingSource;
        private Button btnAgregarAtencion;
        private Button btnCancelarAtencion;
        private Button btnEditarAtencion;
        private Button BtnVolver;
        private Button btnFiltros;
        private Panel pnlFiltros;
        private Button button1;
    }
}