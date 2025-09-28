namespace SmileSoft.WindowsForms
{
    partial class FormInicioAlternativo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInicioAlternativo));
            toolStripContainer1 = new ToolStripContainer();
            tableLayoutPanel1 = new TableLayoutPanel();
            dgvPrincipal = new DataGridView();
            btnVolver = new Button();
            btnEditarUsuario = new Button();
            btnBorrarUsuario = new Button();
            btnCrearUsuario = new Button();
            tbBuscadorUsuarios = new TextBox();
            tsAlternativo = new ToolStrip();
            tsbInicio = new ToolStripButton();
            tsbAtencion = new ToolStripButton();
            tsbUsuarios = new ToolStripButton();
            toolStripContainer1.ContentPanel.SuspendLayout();
            toolStripContainer1.TopToolStripPanel.SuspendLayout();
            toolStripContainer1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPrincipal).BeginInit();
            tsAlternativo.SuspendLayout();
            SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            toolStripContainer1.ContentPanel.Controls.Add(tableLayoutPanel1);
            toolStripContainer1.ContentPanel.Size = new Size(800, 425);
            toolStripContainer1.Dock = DockStyle.Fill;
            toolStripContainer1.Location = new Point(0, 0);
            toolStripContainer1.Name = "toolStripContainer1";
            toolStripContainer1.Size = new Size(800, 450);
            toolStripContainer1.TabIndex = 0;
            toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            toolStripContainer1.TopToolStripPanel.Controls.Add(tsAlternativo);
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(dgvPrincipal, 0, 1);
            tableLayoutPanel1.Controls.Add(btnVolver, 0, 2);
            tableLayoutPanel1.Controls.Add(btnEditarUsuario, 1, 2);
            tableLayoutPanel1.Controls.Add(btnBorrarUsuario, 2, 2);
            tableLayoutPanel1.Controls.Add(btnCrearUsuario, 2, 0);
            tableLayoutPanel1.Controls.Add(tbBuscadorUsuarios, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(800, 425);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvPrincipal
            // 
            dgvPrincipal.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tableLayoutPanel1.SetColumnSpan(dgvPrincipal, 3);
            dgvPrincipal.Dock = DockStyle.Fill;
            dgvPrincipal.Location = new Point(3, 32);
            dgvPrincipal.Name = "dgvPrincipal";
            dgvPrincipal.Size = new Size(794, 361);
            dgvPrincipal.TabIndex = 0;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(3, 399);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(75, 23);
            btnVolver.TabIndex = 1;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            // 
            // btnEditarUsuario
            // 
            btnEditarUsuario.Location = new Point(641, 399);
            btnEditarUsuario.Name = "btnEditarUsuario";
            btnEditarUsuario.Size = new Size(75, 23);
            btnEditarUsuario.TabIndex = 2;
            btnEditarUsuario.Text = "Editar";
            btnEditarUsuario.UseVisualStyleBackColor = true;
            // 
            // btnBorrarUsuario
            // 
            btnBorrarUsuario.Location = new Point(722, 399);
            btnBorrarUsuario.Name = "btnBorrarUsuario";
            btnBorrarUsuario.Size = new Size(75, 23);
            btnBorrarUsuario.TabIndex = 3;
            btnBorrarUsuario.Text = "Borrar";
            btnBorrarUsuario.UseVisualStyleBackColor = true;
            // 
            // btnCrearUsuario
            // 
            btnCrearUsuario.Location = new Point(722, 3);
            btnCrearUsuario.Name = "btnCrearUsuario";
            btnCrearUsuario.Size = new Size(75, 23);
            btnCrearUsuario.TabIndex = 4;
            btnCrearUsuario.Text = "Crear usuario";
            btnCrearUsuario.UseVisualStyleBackColor = true;
            // 
            // tbBuscadorUsuarios
            // 
            tableLayoutPanel1.SetColumnSpan(tbBuscadorUsuarios, 2);
            tbBuscadorUsuarios.Dock = DockStyle.Fill;
            tbBuscadorUsuarios.Location = new Point(3, 3);
            tbBuscadorUsuarios.Name = "tbBuscadorUsuarios";
            tbBuscadorUsuarios.Size = new Size(713, 23);
            tbBuscadorUsuarios.TabIndex = 5;
            // 
            // tsAlternativo
            // 
            tsAlternativo.AllowMerge = false;
            tsAlternativo.Dock = DockStyle.None;
            tsAlternativo.GripStyle = ToolStripGripStyle.Hidden;
            tsAlternativo.Items.AddRange(new ToolStripItem[] { tsbInicio, tsbAtencion, tsbUsuarios });
            tsAlternativo.Location = new Point(3, 0);
            tsAlternativo.Name = "tsAlternativo";
            tsAlternativo.Size = new Size(169, 25);
            tsAlternativo.TabIndex = 0;
            // 
            // tsbInicio
            // 
            tsbInicio.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsbInicio.ImageTransparentColor = Color.Magenta;
            tsbInicio.Name = "tsbInicio";
            tsbInicio.Size = new Size(40, 22);
            tsbInicio.Text = "Inicio";
            // 
            // tsbAtencion
            // 
            tsbAtencion.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsbAtencion.Image = (Image)resources.GetObject("tsbAtencion.Image");
            tsbAtencion.ImageTransparentColor = Color.Magenta;
            tsbAtencion.Name = "tsbAtencion";
            tsbAtencion.Size = new Size(70, 22);
            tsbAtencion.Text = "Atenciones";
            // 
            // tsbUsuarios
            // 
            tsbUsuarios.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsbUsuarios.Image = (Image)resources.GetObject("tsbUsuarios.Image");
            tsbUsuarios.ImageTransparentColor = Color.Magenta;
            tsbUsuarios.Name = "tsbUsuarios";
            tsbUsuarios.Size = new Size(56, 22);
            tsbUsuarios.Text = "Usuarios";
            tsbUsuarios.Click += tsbUsuarios_Click;
            // 
            // FormInicioAlternativo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(toolStripContainer1);
            IsMdiContainer = true;
            Name = "FormInicioAlternativo";
            Text = "FormInicioAlternativo";
            WindowState = FormWindowState.Maximized;
            toolStripContainer1.ContentPanel.ResumeLayout(false);
            toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            toolStripContainer1.TopToolStripPanel.PerformLayout();
            toolStripContainer1.ResumeLayout(false);
            toolStripContainer1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPrincipal).EndInit();
            tsAlternativo.ResumeLayout(false);
            tsAlternativo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ToolStripContainer toolStripContainer1;
        private ToolStrip tsAlternativo;
        private ToolStripButton tsbInicio;
        private TableLayoutPanel tableLayoutPanel1;
        private ToolStripButton tsbAtencion;
        private ToolStripButton tsbUsuarios;
        private DataGridView dgvPrincipal;
        private Button btnVolver;
        private Button btnEditarUsuario;
        private Button btnBorrarUsuario;
        private Button btnCrearUsuario;
        private TextBox tbBuscadorUsuarios;
    }
}