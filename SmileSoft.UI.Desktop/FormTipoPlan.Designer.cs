namespace SmileSoft.UI.Desktop
{
    partial class FormTipoPlan
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
            lblNombreTipoPlan = new Label();
            btnGuardarTipoPlan = new Button();
            txtNombreTipoPlan = new TextBox();
            btnEditarTipoPlan = new Button();
            txtDescripcionTipoPlan = new TextBox();
            lblDescripcionTipoPlan = new Label();
            cmbObraSocial = new ComboBox();
            obraSocialBindingSource = new BindingSource(components);
            lblObraSocial = new Label();
            ((System.ComponentModel.ISupportInitialize)obraSocialBindingSource).BeginInit();
            SuspendLayout();
            // 
            // lblNombreTipoPlan
            // 
            lblNombreTipoPlan.AutoSize = true;
            lblNombreTipoPlan.Location = new Point(182, 23);
            lblNombreTipoPlan.Margin = new Padding(2, 0, 2, 0);
            lblNombreTipoPlan.Name = "lblNombreTipoPlan";
            lblNombreTipoPlan.Size = new Size(51, 15);
            lblNombreTipoPlan.TabIndex = 0;
            lblNombreTipoPlan.Text = "Nombre";
            // 
            // btnGuardarTipoPlan
            // 
            btnGuardarTipoPlan.Location = new Point(182, 211);
            btnGuardarTipoPlan.Margin = new Padding(2);
            btnGuardarTipoPlan.Name = "btnGuardarTipoPlan";
            btnGuardarTipoPlan.Size = new Size(79, 33);
            btnGuardarTipoPlan.TabIndex = 8;
            btnGuardarTipoPlan.Text = "Guardar";
            btnGuardarTipoPlan.UseVisualStyleBackColor = true;
            btnGuardarTipoPlan.Click += btnEnviarTipoPlan_Click;
            // 
            // txtNombreTipoPlan
            // 
            txtNombreTipoPlan.Location = new Point(302, 20);
            txtNombreTipoPlan.Margin = new Padding(2);
            txtNombreTipoPlan.Name = "txtNombreTipoPlan";
            txtNombreTipoPlan.Size = new Size(106, 23);
            txtNombreTipoPlan.TabIndex = 1;
            // 
            // btnEditarTipoPlan
            // 
            btnEditarTipoPlan.Location = new Point(302, 211);
            btnEditarTipoPlan.Margin = new Padding(2);
            btnEditarTipoPlan.Name = "btnEditarTipoPlan";
            btnEditarTipoPlan.Size = new Size(80, 33);
            btnEditarTipoPlan.TabIndex = 9;
            btnEditarTipoPlan.Text = "Editar";
            btnEditarTipoPlan.UseVisualStyleBackColor = true;
            btnEditarTipoPlan.Click += btnEditarTipoPlan_Click;
            // 
            // txtDescripcionTipoPlan
            // 
            txtDescripcionTipoPlan.Location = new Point(302, 56);
            txtDescripcionTipoPlan.Margin = new Padding(2);
            txtDescripcionTipoPlan.Name = "txtDescripcionTipoPlan";
            txtDescripcionTipoPlan.Size = new Size(106, 23);
            txtDescripcionTipoPlan.TabIndex = 3;
            // 
            // lblDescripcionTipoPlan
            // 
            lblDescripcionTipoPlan.AutoSize = true;
            lblDescripcionTipoPlan.Location = new Point(182, 56);
            lblDescripcionTipoPlan.Margin = new Padding(2, 0, 2, 0);
            lblDescripcionTipoPlan.Name = "lblDescripcionTipoPlan";
            lblDescripcionTipoPlan.Size = new Size(65, 15);
            lblDescripcionTipoPlan.TabIndex = 2;
            lblDescripcionTipoPlan.Text = "Descipcion";
            // 
            // cmbObraSocial
            // 
            cmbObraSocial.DataBindings.Add(new Binding("DataContext", obraSocialBindingSource, "Id", true));
            cmbObraSocial.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbObraSocial.FormattingEnabled = true;
            cmbObraSocial.Location = new Point(302, 94);
            cmbObraSocial.Margin = new Padding(2);
            cmbObraSocial.Name = "cmbObraSocial";
            cmbObraSocial.Size = new Size(200, 23);
            cmbObraSocial.TabIndex = 5;
            // 
            // obraSocialBindingSource
            // 
            obraSocialBindingSource.DataSource = typeof(Dominio.ObraSocial);
            // 
            // lblObraSocial
            // 
            lblObraSocial.AutoSize = true;
            lblObraSocial.Location = new Point(182, 94);
            lblObraSocial.Margin = new Padding(2, 0, 2, 0);
            lblObraSocial.Name = "lblObraSocial";
            lblObraSocial.Size = new Size(67, 15);
            lblObraSocial.TabIndex = 4;
            lblObraSocial.Text = "Obra Social";
            // 
            // FormTipoPlan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 270);
            Controls.Add(lblObraSocial);
            Controls.Add(cmbObraSocial);
            Controls.Add(lblDescripcionTipoPlan);
            Controls.Add(txtDescripcionTipoPlan);
            Controls.Add(btnEditarTipoPlan);
            Controls.Add(txtNombreTipoPlan);
            Controls.Add(btnGuardarTipoPlan);
            Controls.Add(lblNombreTipoPlan);
            Margin = new Padding(2);
            Name = "FormTipoPlan";
            Text = "FormOS";
            Load += FormTipoPlan_Load;
            ((System.ComponentModel.ISupportInitialize)obraSocialBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNombreTipoPlan;
        private Button btnGuardarTipoPlan;
        private TextBox txtNombreTipoPlan;
        private Button btnEditarTipoPlan;
        private TextBox txtDescripcionTipoPlan;
        private Label lblDescripcionTipoPlan;
        private ComboBox cmbObraSocial;
        private Label lblObraSocial;
        private BindingSource obraSocialBindingSource;
    }
}