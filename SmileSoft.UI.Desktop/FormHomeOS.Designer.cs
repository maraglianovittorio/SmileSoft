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
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nombreDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            obraSocialBindingSource = new BindingSource(components);
            txtBuscarOS = new TextBox();
            lupaPng = new PictureBox();
            btnAgregarOS = new Button();
            btnEditarOS = new Button();
            btnBorrarOS = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvFormOS).BeginInit();
            ((System.ComponentModel.ISupportInitialize)obraSocialBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lupaPng).BeginInit();
            SuspendLayout();
            // 
            // dgvFormOS
            // 
            dgvFormOS.AutoGenerateColumns = false;
            dgvFormOS.BackgroundColor = Color.PapayaWhip;
            dgvFormOS.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFormOS.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nombreDataGridViewTextBoxColumn });
            dgvFormOS.DataSource = obraSocialBindingSource;
            dgvFormOS.Location = new Point(20, 60);
            dgvFormOS.Margin = new Padding(2);
            dgvFormOS.Name = "dgvFormOS";
            dgvFormOS.RowHeadersWidth = 62;
            dgvFormOS.Size = new Size(690, 180);
            dgvFormOS.TabIndex = 0;
            dgvFormOS.SelectionChanged += dgvFormOS_SelectionChanged_1;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.MinimumWidth = 8;
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.Width = 150;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            nombreDataGridViewTextBoxColumn.MinimumWidth = 8;
            nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            nombreDataGridViewTextBoxColumn.Width = 150;
            // 
            // obraSocialBindingSource
            // 
            obraSocialBindingSource.DataSource = typeof(Dominio.ObraSocial);
            // 
            // txtBuscarOS
            // 
            txtBuscarOS.Location = new Point(20, 21);
            txtBuscarOS.Margin = new Padding(2);
            txtBuscarOS.Name = "txtBuscarOS";
            txtBuscarOS.Size = new Size(457, 23);
            txtBuscarOS.TabIndex = 1;
            txtBuscarOS.TextChanged += txtBuscarOS_TextChanged;
            // 
            // lupaPng
            // 
            lupaPng.Image = (Image)resources.GetObject("lupaPng.Image");
            lupaPng.InitialImage = (Image)resources.GetObject("lupaPng.InitialImage");
            lupaPng.Location = new Point(481, 21);
            lupaPng.Margin = new Padding(2);
            lupaPng.Name = "lupaPng";
            lupaPng.Size = new Size(23, 23);
            lupaPng.SizeMode = PictureBoxSizeMode.StretchImage;
            lupaPng.TabIndex = 4;
            lupaPng.TabStop = false;
            // 
            // btnAgregarOS
            // 
            btnAgregarOS.Location = new Point(552, 17);
            btnAgregarOS.Margin = new Padding(2);
            btnAgregarOS.Name = "btnAgregarOS";
            btnAgregarOS.Size = new Size(158, 29);
            btnAgregarOS.TabIndex = 5;
            btnAgregarOS.Text = "Agregar OS";
            btnAgregarOS.UseVisualStyleBackColor = true;
            btnAgregarOS.Click += btnAgregarOS_Click;
            // 
            // btnEditarOS
            // 
            btnEditarOS.Location = new Point(481, 244);
            btnEditarOS.Margin = new Padding(2);
            btnEditarOS.Name = "btnEditarOS";
            btnEditarOS.Size = new Size(112, 40);
            btnEditarOS.TabIndex = 6;
            btnEditarOS.Text = "Editar OS";
            btnEditarOS.UseVisualStyleBackColor = true;
            btnEditarOS.Click += btnEditarOS_Click;
            // 
            // btnBorrarOS
            // 
            btnBorrarOS.Location = new Point(598, 244);
            btnBorrarOS.Margin = new Padding(2);
            btnBorrarOS.Name = "btnBorrarOS";
            btnBorrarOS.Size = new Size(112, 40);
            btnBorrarOS.TabIndex = 8;
            btnBorrarOS.Text = "BorrarOS";
            btnBorrarOS.UseVisualStyleBackColor = true;
            btnBorrarOS.Click += btnBorrarOS_Click;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaption;
            button1.Location = new Point(20, 243);
            button1.Name = "button1";
            button1.Size = new Size(133, 41);
            button1.TabIndex = 10;
            button1.Text = "Volver";
            button1.UseVisualStyleBackColor = false;
            button1.Click += BtnVolver_Click;
            // 
            // FormHomeOS
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(752, 307);
            Controls.Add(button1);
            Controls.Add(btnBorrarOS);
            Controls.Add(btnEditarOS);
            Controls.Add(btnAgregarOS);
            Controls.Add(lupaPng);
            Controls.Add(txtBuscarOS);
            Controls.Add(dgvFormOS);
            Margin = new Padding(2);
            Name = "FormHomeOS";
            Text = "FormHomeOS";
            Load += FormHomeOS_Load;
            ((System.ComponentModel.ISupportInitialize)dgvFormOS).EndInit();
            ((System.ComponentModel.ISupportInitialize)obraSocialBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)lupaPng).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvFormOS;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn planesDataGridViewTextBoxColumn;
        private BindingSource obraSocialBindingSource;
        private TextBox txtBuscarOS;
        private PictureBox lupaPng;
        private Button btnAgregarOS;
        private Button btnEditarOS;
        private Button btnBorrarOS;
        private Button BtnVolver;
        private Button button1;
    }
}