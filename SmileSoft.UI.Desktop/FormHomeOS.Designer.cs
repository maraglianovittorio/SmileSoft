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
            textBox1 = new TextBox();
            lupaPng = new PictureBox();
            btnAgregarOS = new Button();
            btnEditarOS = new Button();
            btnBorrarOS = new Button();
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
            dgvFormOS.Location = new Point(12, 84);
            dgvFormOS.Name = "dgvFormOS";
            dgvFormOS.RowHeadersWidth = 62;
            dgvFormOS.Size = new Size(986, 300);
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
            // textBox1
            // 
            textBox1.Location = new Point(12, 28);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(704, 31);
            textBox1.TabIndex = 1;
            // 
            // lupaPng
            // 
            lupaPng.Image = (Image)resources.GetObject("lupaPng.Image");
            lupaPng.InitialImage = (Image)resources.GetObject("lupaPng.InitialImage");
            lupaPng.Location = new Point(722, 28);
            lupaPng.Name = "lupaPng";
            lupaPng.Size = new Size(38, 33);
            lupaPng.SizeMode = PictureBoxSizeMode.StretchImage;
            lupaPng.TabIndex = 4;
            lupaPng.TabStop = false;
            // 
            // btnAgregarOS
            // 
            btnAgregarOS.Location = new Point(819, 12);
            btnAgregarOS.Name = "btnAgregarOS";
            btnAgregarOS.Size = new Size(225, 49);
            btnAgregarOS.TabIndex = 5;
            btnAgregarOS.Text = "Agregar OS";
            btnAgregarOS.UseVisualStyleBackColor = true;
            // 
            // btnEditarOS
            // 
            btnEditarOS.Location = new Point(664, 400);
            btnEditarOS.Name = "btnEditarOS";
            btnEditarOS.Size = new Size(160, 66);
            btnEditarOS.TabIndex = 6;
            btnEditarOS.Text = "Editar OS";
            btnEditarOS.UseVisualStyleBackColor = true;
            // 
            // btnBorrarOS
            // 
            btnBorrarOS.Location = new Point(863, 400);
            btnBorrarOS.Name = "btnBorrarOS";
            btnBorrarOS.Size = new Size(160, 66);
            btnBorrarOS.TabIndex = 8;
            btnBorrarOS.Text = "BorrarOS";
            btnBorrarOS.UseVisualStyleBackColor = true;
            // 
            // FormHomeOS
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1056, 591);
            Controls.Add(btnBorrarOS);
            Controls.Add(btnEditarOS);
            Controls.Add(btnAgregarOS);
            Controls.Add(lupaPng);
            Controls.Add(textBox1);
            Controls.Add(dgvFormOS);
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
        private TextBox textBox1;
        private PictureBox lupaPng;
        private Button btnAgregarOS;
        private Button btnEditarOS;
        private Button btnBorrarOS;
    }
}