namespace SmileSoft.UI.Desktop
{
    partial class FormHomeSecretario
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
            BtnCerrarSesion = new Button();
            menuStrip1 = new MenuStrip();
            atencionesToolStripMenuItem = new ToolStripMenuItem();
            agregarAtencionToolStripMenuItem = new ToolStripMenuItem();
            verAtencionesToolStripMenuItem = new ToolStripMenuItem();
            pacientesToolStripMenuItem = new ToolStripMenuItem();
            tutoresToolStripMenuItem = new ToolStripMenuItem();
            OSToolStripMenuItem = new ToolStripMenuItem();
            dgvAtencionesDelDia = new DataGridView();
            atencionBindingSource = new BindingSource(components);
            lblAtencionesDelDia = new Label();
            btnRegistrarLlegada = new Button();
            btnEditarAtencion = new Button();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAtencionesDelDia).BeginInit();
            ((System.ComponentModel.ISupportInitialize)atencionBindingSource).BeginInit();
            SuspendLayout();
            // 
            // BtnCerrarSesion
            // 
            BtnCerrarSesion.BackColor = SystemColors.ActiveCaption;
            BtnCerrarSesion.Location = new Point(12, 329);
            BtnCerrarSesion.Name = "BtnCerrarSesion";
            BtnCerrarSesion.Size = new Size(133, 41);
            BtnCerrarSesion.TabIndex = 9;
            BtnCerrarSesion.Text = "Cerrar sesion";
            BtnCerrarSesion.UseVisualStyleBackColor = false;
            BtnCerrarSesion.Click += BtnCerrarSesion_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { atencionesToolStripMenuItem, pacientesToolStripMenuItem, tutoresToolStripMenuItem, OSToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(707, 24);
            menuStrip1.TabIndex = 10;
            menuStrip1.Text = "menuStrip1";
            // 
            // atencionesToolStripMenuItem
            // 
            atencionesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { agregarAtencionToolStripMenuItem, verAtencionesToolStripMenuItem });
            atencionesToolStripMenuItem.Name = "atencionesToolStripMenuItem";
            atencionesToolStripMenuItem.Size = new Size(78, 20);
            atencionesToolStripMenuItem.Text = "Atenciones";
            atencionesToolStripMenuItem.Click += atencionesToolStripMenuItem_Click;
            // 
            // agregarAtencionToolStripMenuItem
            // 
            agregarAtencionToolStripMenuItem.Name = "agregarAtencionToolStripMenuItem";
            agregarAtencionToolStripMenuItem.Size = new Size(167, 22);
            agregarAtencionToolStripMenuItem.Text = "Agregar Atencion";
            agregarAtencionToolStripMenuItem.Click += agregarAtencionToolStripMenuItem_Click;
            // 
            // verAtencionesToolStripMenuItem
            // 
            verAtencionesToolStripMenuItem.Name = "verAtencionesToolStripMenuItem";
            verAtencionesToolStripMenuItem.Size = new Size(167, 22);
            verAtencionesToolStripMenuItem.Text = "Ver Atenciones";
            verAtencionesToolStripMenuItem.Click += verAtencionesToolStripMenuItem_Click;
            // 
            // pacientesToolStripMenuItem
            // 
            pacientesToolStripMenuItem.Name = "pacientesToolStripMenuItem";
            pacientesToolStripMenuItem.Size = new Size(69, 20);
            pacientesToolStripMenuItem.Text = "Pacientes";
            pacientesToolStripMenuItem.Click += pacientesToolStripMenuItem_Click;
            // 
            // tutoresToolStripMenuItem
            // 
            tutoresToolStripMenuItem.Name = "tutoresToolStripMenuItem";
            tutoresToolStripMenuItem.Size = new Size(58, 20);
            tutoresToolStripMenuItem.Text = "Tutores";
            tutoresToolStripMenuItem.Click += tutoresToolStripMenuItem_Click;
            // 
            // OSToolStripMenuItem
            // 
            OSToolStripMenuItem.Name = "OSToolStripMenuItem";
            OSToolStripMenuItem.Size = new Size(95, 20);
            OSToolStripMenuItem.Text = "Obras Sociales";
            OSToolStripMenuItem.Click += oToolStripMenuItem_Click;
            // 
            // dgvAtencionesDelDia
            // 
            dgvAtencionesDelDia.BackgroundColor = Color.PapayaWhip;
            dgvAtencionesDelDia.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAtencionesDelDia.Location = new Point(12, 51);
            dgvAtencionesDelDia.Name = "dgvAtencionesDelDia";
            dgvAtencionesDelDia.Size = new Size(683, 266);
            dgvAtencionesDelDia.TabIndex = 11;
            // 
            // atencionBindingSource
            // 
            atencionBindingSource.DataSource = typeof(Dominio.Atencion);
            // 
            // lblAtencionesDelDia
            // 
            lblAtencionesDelDia.AutoSize = true;
            lblAtencionesDelDia.Font = new Font("Segoe UI", 13F);
            lblAtencionesDelDia.Location = new Point(12, 23);
            lblAtencionesDelDia.Name = "lblAtencionesDelDia";
            lblAtencionesDelDia.Size = new Size(157, 25);
            lblAtencionesDelDia.TabIndex = 12;
            lblAtencionesDelDia.Text = "Atenciones del dia";
            // 
            // btnRegistrarLlegada
            // 
            btnRegistrarLlegada.BackColor = Color.Gold;
            btnRegistrarLlegada.ForeColor = SystemColors.ButtonHighlight;
            btnRegistrarLlegada.Location = new Point(553, 322);
            btnRegistrarLlegada.Margin = new Padding(2);
            btnRegistrarLlegada.Name = "btnRegistrarLlegada";
            btnRegistrarLlegada.Size = new Size(143, 54);
            btnRegistrarLlegada.TabIndex = 13;
            btnRegistrarLlegada.Text = "Registrar Llegada";
            btnRegistrarLlegada.UseVisualStyleBackColor = false;
            btnRegistrarLlegada.Click += btnRegistrarLlegada_Click;
            // 
            // btnEditarAtencion
            // 
            btnEditarAtencion.BackColor = Color.YellowGreen;
            btnEditarAtencion.ForeColor = SystemColors.ButtonHighlight;
            btnEditarAtencion.Location = new Point(401, 323);
            btnEditarAtencion.Margin = new Padding(2);
            btnEditarAtencion.Name = "btnEditarAtencion";
            btnEditarAtencion.Size = new Size(134, 48);
            btnEditarAtencion.TabIndex = 14;
            btnEditarAtencion.Text = "Editar atencion";
            btnEditarAtencion.UseVisualStyleBackColor = false;
            btnEditarAtencion.Click += btnEditarAtencion_Click;
            // 
            // FormHomeSecretario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(707, 382);
            Controls.Add(btnEditarAtencion);
            Controls.Add(btnRegistrarLlegada);
            Controls.Add(lblAtencionesDelDia);
            Controls.Add(dgvAtencionesDelDia);
            Controls.Add(BtnCerrarSesion);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(2);
            Name = "FormHomeSecretario";
            Text = "FormHome";
            Load += FormHomeSecretario_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAtencionesDelDia).EndInit();
            ((System.ComponentModel.ISupportInitialize)atencionBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button BtnCerrarSesion;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem atencionesToolStripMenuItem;
        private ToolStripMenuItem pacientesToolStripMenuItem;
        private ToolStripMenuItem tutoresToolStripMenuItem;
        private ToolStripMenuItem OSToolStripMenuItem;
        private DataGridView dgvAtencionesDelDia;
        private BindingSource atencionBindingSource;
        private Label lblAtencionesDelDia;
        private ToolStripMenuItem agregarAtencionToolStripMenuItem;
        private Button btnRegistrarLlegada;
        private Button btnEditarAtencion;
        private ToolStripMenuItem verAtencionesToolStripMenuItem;
    }
}