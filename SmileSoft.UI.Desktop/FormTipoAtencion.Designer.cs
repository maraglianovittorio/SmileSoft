namespace SmileSoft.UI.Desktop
{
    partial class FormTipoAtencion
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
            btnAgregarTipoAtencion = new Button();
            btnEditarTipoAtencion = new Button();
            txtDescripcionTipoAtencion = new TextBox();
            lblDescripcionTipoAtencion = new Label();
            obraSocialBindingSource = new BindingSource(components);
            lblDuracionTipoAtencion = new Label();
            mskTxtDuracion = new MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)obraSocialBindingSource).BeginInit();
            SuspendLayout();
            // 
            // btnAgregarTipoAtencion
            // 
            btnAgregarTipoAtencion.Location = new Point(182, 211);
            btnAgregarTipoAtencion.Margin = new Padding(2);
            btnAgregarTipoAtencion.Name = "btnAgregarTipoAtencion";
            btnAgregarTipoAtencion.Size = new Size(79, 33);
            btnAgregarTipoAtencion.TabIndex = 4;
            btnAgregarTipoAtencion.Text = "Enviar";
            btnAgregarTipoAtencion.UseVisualStyleBackColor = true;
            btnAgregarTipoAtencion.Click += btnEnviarTipoAtencion_Click;
            // 
            // btnEditarTipoAtencion
            // 
            btnEditarTipoAtencion.Location = new Point(302, 211);
            btnEditarTipoAtencion.Margin = new Padding(2);
            btnEditarTipoAtencion.Name = "btnEditarTipoAtencion";
            btnEditarTipoAtencion.Size = new Size(80, 33);
            btnEditarTipoAtencion.TabIndex = 5;
            btnEditarTipoAtencion.Text = "Editar";
            btnEditarTipoAtencion.UseVisualStyleBackColor = true;
            btnEditarTipoAtencion.Click += btnEditarTipoAtencion_Click;
            // 
            // txtDescripcionTipoAtencion
            // 
            txtDescripcionTipoAtencion.Location = new Point(302, 32);
            txtDescripcionTipoAtencion.Margin = new Padding(2);
            txtDescripcionTipoAtencion.Name = "txtDescripcionTipoAtencion";
            txtDescripcionTipoAtencion.Size = new Size(106, 23);
            txtDescripcionTipoAtencion.TabIndex = 1;
            // 
            // lblDescripcionTipoAtencion
            // 
            lblDescripcionTipoAtencion.AutoSize = true;
            lblDescripcionTipoAtencion.Location = new Point(182, 32);
            lblDescripcionTipoAtencion.Margin = new Padding(2, 0, 2, 0);
            lblDescripcionTipoAtencion.Name = "lblDescripcionTipoAtencion";
            lblDescripcionTipoAtencion.Size = new Size(65, 15);
            lblDescripcionTipoAtencion.TabIndex = 0;
            lblDescripcionTipoAtencion.Text = "Descipcion";
            // 
            // obraSocialBindingSource
            // 
            obraSocialBindingSource.DataSource = typeof(Dominio.ObraSocial);
            // 
            // lblDuracionTipoAtencion
            // 
            lblDuracionTipoAtencion.AutoSize = true;
            lblDuracionTipoAtencion.Location = new Point(182, 71);
            lblDuracionTipoAtencion.Margin = new Padding(2, 0, 2, 0);
            lblDuracionTipoAtencion.Name = "lblDuracionTipoAtencion";
            lblDuracionTipoAtencion.Size = new Size(55, 15);
            lblDuracionTipoAtencion.TabIndex = 2;
            lblDuracionTipoAtencion.Text = "Duracion";
            // 
            // mskTxtDuracion
            // 
            mskTxtDuracion.Location = new Point(302, 71);
            mskTxtDuracion.Name = "mskTxtDuracion";
            mskTxtDuracion.Size = new Size(106, 23);
            mskTxtDuracion.TabIndex = 6;
            // 
            // FormTipoAtencion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 270);
            Controls.Add(mskTxtDuracion);
            Controls.Add(lblDuracionTipoAtencion);
            Controls.Add(lblDescripcionTipoAtencion);
            Controls.Add(txtDescripcionTipoAtencion);
            Controls.Add(btnEditarTipoAtencion);
            Controls.Add(btnAgregarTipoAtencion);
            Margin = new Padding(2);
            Name = "FormTipoAtencion";
            Text = "FormOS";
            ((System.ComponentModel.ISupportInitialize)obraSocialBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnAgregarTipoAtencion;
        private Button btnEditarTipoAtencion;
        private TextBox txtDescripcionTipoAtencion;
        private Label lblDescripcionTipoAtencion;
        private BindingSource obraSocialBindingSource;
        private Label lblDuracionTipoAtencion;
        private MaskedTextBox mskTxtDuracion;
    }
}