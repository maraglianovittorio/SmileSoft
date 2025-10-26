namespace SmileSoft.UI.Desktop
{
    partial class FormHomeUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHomeUsuario));
            dgvFormUsuario = new DataGridView();
            textBox1 = new TextBox();
            txtBuscarUsuario = new TextBox();
            lupaPng = new PictureBox();
            usuarioBindingSource = new BindingSource(components);
            btnAgregarUsuario = new Button();
            btnBorrarUsuario = new Button();
            btnEditarUsuario = new Button();
            BtnVolver = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvFormUsuario).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lupaPng).BeginInit();
            ((System.ComponentModel.ISupportInitialize)usuarioBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dgvFormUsuario
            // 
            dgvFormUsuario.AllowUserToAddRows = false;
            dgvFormUsuario.AllowUserToDeleteRows = false;
            dgvFormUsuario.AllowUserToOrderColumns = true;
            dgvFormUsuario.BackgroundColor = Color.PapayaWhip;
            dgvFormUsuario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFormUsuario.Location = new Point(26, 55);
            dgvFormUsuario.Margin = new Padding(2);
            dgvFormUsuario.Name = "dgvFormUsuario";
            dgvFormUsuario.ReadOnly = true;
            dgvFormUsuario.RowHeadersWidth = 62;
            dgvFormUsuario.Size = new Size(759, 223);
            dgvFormUsuario.TabIndex = 0;
            dgvFormUsuario.SelectionChanged += dgvFormHome_SelectionChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(525, -118);
            textBox1.Margin = new Padding(2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(517, 23);
            textBox1.TabIndex = 1;
            // 
            // txtBuscarUsuario
            // 
            txtBuscarUsuario.Location = new Point(26, 21);
            txtBuscarUsuario.Margin = new Padding(2);
            txtBuscarUsuario.Name = "txtBuscarUsuario";
            txtBuscarUsuario.Size = new Size(530, 23);
            txtBuscarUsuario.TabIndex = 2;
            txtBuscarUsuario.TextChanged += txtBuscarUsuario_TextChanged;
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
            // usuarioBindingSource
            // 
            usuarioBindingSource.DataSource = typeof(Dominio.Usuario);
            // 
            // btnAgregarUsuario
            // 
            btnAgregarUsuario.BackColor = SystemColors.MenuHighlight;
            btnAgregarUsuario.ForeColor = SystemColors.ButtonHighlight;
            btnAgregarUsuario.Location = new Point(628, 9);
            btnAgregarUsuario.Margin = new Padding(2);
            btnAgregarUsuario.Name = "btnAgregarUsuario";
            btnAgregarUsuario.Size = new Size(158, 43);
            btnAgregarUsuario.TabIndex = 4;
            btnAgregarUsuario.Text = "Agregar usuario";
            btnAgregarUsuario.UseVisualStyleBackColor = false;
            btnAgregarUsuario.Click += btnAgregarUsuario_Click;
            // 
            // btnBorrarUsuario
            // 
            btnBorrarUsuario.BackColor = Color.Red;
            btnBorrarUsuario.ForeColor = SystemColors.ButtonHighlight;
            btnBorrarUsuario.Location = new Point(651, 282);
            btnBorrarUsuario.Margin = new Padding(2);
            btnBorrarUsuario.Name = "btnBorrarUsuario";
            btnBorrarUsuario.Size = new Size(134, 42);
            btnBorrarUsuario.TabIndex = 5;
            btnBorrarUsuario.Text = "Borrar Usuario";
            btnBorrarUsuario.UseVisualStyleBackColor = false;
            btnBorrarUsuario.Click += BtnBorrarUsuario_Click;
            // 
            // btnEditarUsuario
            // 
            btnEditarUsuario.BackColor = Color.YellowGreen;
            btnEditarUsuario.ForeColor = SystemColors.ButtonHighlight;
            btnEditarUsuario.Location = new Point(513, 282);
            btnEditarUsuario.Margin = new Padding(2);
            btnEditarUsuario.Name = "btnEditarUsuario";
            btnEditarUsuario.Size = new Size(134, 42);
            btnEditarUsuario.TabIndex = 6;
            btnEditarUsuario.Text = "Editar Usuario";
            btnEditarUsuario.UseVisualStyleBackColor = false;
            btnEditarUsuario.Click += BtnEditarUsuario_Click;
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
            // FormHomeUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(803, 339);
            Controls.Add(BtnVolver);
            Controls.Add(btnEditarUsuario);
            Controls.Add(btnBorrarUsuario);
            Controls.Add(btnAgregarUsuario);
            Controls.Add(lupaPng);
            Controls.Add(txtBuscarUsuario);
            Controls.Add(textBox1);
            Controls.Add(dgvFormUsuario);
            Margin = new Padding(2);
            MinimumSize = new Size(565, 286);
            Name = "FormHomeUsuario";
            Text = "FormHomePage";
            Load += FormHomePage_Load;
            ((System.ComponentModel.ISupportInitialize)dgvFormUsuario).EndInit();
            ((System.ComponentModel.ISupportInitialize)lupaPng).EndInit();
            ((System.ComponentModel.ISupportInitialize)usuarioBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvFormUsuario;
        private TextBox textBox1;
        private TextBox txtBuscarUsuario;
        private PictureBox lupaPng;
        private BindingSource usuarioBindingSource;
        private Button btnAgregarUsuario;
        private Button btnBorrarUsuario;
        private Button btnEditarUsuario;
        private Button BtnVolver;
    }
}