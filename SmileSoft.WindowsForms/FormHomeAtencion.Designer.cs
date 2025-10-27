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
            ((System.ComponentModel.ISupportInitialize)dgvFormAtencion).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lupaPng).BeginInit();
            ((System.ComponentModel.ISupportInitialize)atencionBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dgvFormAtencion
            // 
            dgvFormAtencion.AllowUserToAddRows = false;
            dgvFormAtencion.AllowUserToDeleteRows = false;
            dgvFormAtencion.AllowUserToOrderColumns = true;
            dgvFormAtencion.BackgroundColor = Color.PapayaWhip;
            dgvFormAtencion.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFormAtencion.Location = new Point(37, 80);
            dgvFormAtencion.Name = "dgvFormAtencion";
            dgvFormAtencion.ReadOnly = true;
            dgvFormAtencion.RowHeadersWidth = 62;
            dgvFormAtencion.Size = new Size(1151, 448);
            dgvFormAtencion.TabIndex = 0;
            dgvFormAtencion.SelectionChanged += dgvFormHomeAtenciones_SelectionChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(750, -197);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(737, 31);
            textBox1.TabIndex = 1;
            // 
            // txtBuscarAtencion
            // 
            txtBuscarAtencion.Location = new Point(37, 35);
            txtBuscarAtencion.Name = "txtBuscarAtencion";
            txtBuscarAtencion.Size = new Size(561, 31);
            txtBuscarAtencion.TabIndex = 2;
            txtBuscarAtencion.TextChanged += txtBuscarAtencion_TextChanged;
            // 
            // lupaPng
            // 
            lupaPng.Image = (Image)resources.GetObject("lupaPng.Image");
            lupaPng.InitialImage = (Image)resources.GetObject("lupaPng.InitialImage");
            lupaPng.Location = new Point(620, 35);
            lupaPng.Name = "lupaPng";
            lupaPng.Size = new Size(33, 38);
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
            btnAgregarAtencion.Location = new Point(963, 2);
            btnAgregarAtencion.Name = "btnAgregarAtencion";
            btnAgregarAtencion.Size = new Size(226, 72);
            btnAgregarAtencion.TabIndex = 4;
            btnAgregarAtencion.Text = "Agregar atencion";
            btnAgregarAtencion.UseVisualStyleBackColor = false;
            btnAgregarAtencion.Click += btnAgregarAtencion_Click;
            // 
            // btnCancelarAtencion
            // 
            btnCancelarAtencion.BackColor = Color.Red;
            btnCancelarAtencion.ForeColor = SystemColors.ButtonHighlight;
            btnCancelarAtencion.Location = new Point(997, 535);
            btnCancelarAtencion.Name = "btnCancelarAtencion";
            btnCancelarAtencion.Size = new Size(191, 70);
            btnCancelarAtencion.TabIndex = 5;
            btnCancelarAtencion.Text = "Cancelar atencion";
            btnCancelarAtencion.UseVisualStyleBackColor = false;
            btnCancelarAtencion.Click += BtnBorrarAtencion_Click;
            // 
            // btnEditarAtencion
            // 
            btnEditarAtencion.BackColor = Color.YellowGreen;
            btnEditarAtencion.ForeColor = SystemColors.ButtonHighlight;
            btnEditarAtencion.Location = new Point(764, 535);
            btnEditarAtencion.Name = "btnEditarAtencion";
            btnEditarAtencion.Size = new Size(191, 70);
            btnEditarAtencion.TabIndex = 6;
            btnEditarAtencion.Text = "Editar atencion";
            btnEditarAtencion.UseVisualStyleBackColor = false;
            btnEditarAtencion.Click += BtnEditarAtencion_Click;
            // 
            // BtnVolver
            // 
            BtnVolver.BackColor = SystemColors.ActiveCaption;
            BtnVolver.Location = new Point(37, 537);
            BtnVolver.Margin = new Padding(4, 5, 4, 5);
            BtnVolver.Name = "BtnVolver";
            BtnVolver.Size = new Size(190, 68);
            BtnVolver.TabIndex = 7;
            BtnVolver.Text = "Volver";
            BtnVolver.UseVisualStyleBackColor = false;
            BtnVolver.Click += BtnVolver_Click;
            // 
            // FormHomeAtencion
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1396, 930);
            Controls.Add(BtnVolver);
            Controls.Add(btnEditarAtencion);
            Controls.Add(btnCancelarAtencion);
            Controls.Add(btnAgregarAtencion);
            Controls.Add(lupaPng);
            Controls.Add(txtBuscarAtencion);
            Controls.Add(textBox1);
            Controls.Add(dgvFormAtencion);
            MinimumSize = new Size(798, 439);
            Name = "FormHomeAtencion";
            Text = "FormHomePage";
            Load += FormHomeAtenciones_Load;
            ((System.ComponentModel.ISupportInitialize)dgvFormAtencion).EndInit();
            ((System.ComponentModel.ISupportInitialize)lupaPng).EndInit();
            ((System.ComponentModel.ISupportInitialize)atencionBindingSource).EndInit();
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
    }
}